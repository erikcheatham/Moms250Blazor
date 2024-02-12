using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moms250Blazor.Common;
using Moms250Blazor.Data;
using Moms250Blazor.Data.Repository;
using Microsoft.Extensions.Options;

namespace Moms250Blazor.Services;

public interface IAzureBlobService
{
    string GetBlobContainerName(FILEBLOBS blob);
    BlobContainerClient GetContainer(string containerName);
    Task<List<Attachment>> GetDocumentsFromDB(int assignmentId);
    Task<List<Attachment>> GetDocumentsFromAzure(FILEBLOBS blob);
    Task<bool> UploadFileToBlobAsync(FILEBLOBS blob, string strFileName, string contentType, Stream fileStream);
    Task<bool> UploadAssignmentFileToBlobAsync(FILEBLOBS blob, int assignmentId, string strFileName, string contentType, Stream fileStream);
    Task<bool> DeleteFileFromBlobAsync(FILEBLOBS blob, string strFileName);
    string GetBlobSASTOkenByFile(string fileName);
    string StripPaths(string file);
    string StripFile(string file);
    //Task<byte[]?> GetFileBytes(FILEBLOBS blob, string fileName);
    //Task<Stream> GetFileStream(FILEBLOBS blob, string fileName);
    //Task MergeFolders(FILEBLOBS srcBlob, string sourceMask, FILEBLOBS destBlob, string destMask);
    //Task<List<IListBlobItem>> FileList(FILEBLOBS srcBlob, string sourceMask);
    //Task EmptyFolder(FILEBLOBS srcBlob, string sourceMask);
}

public class AzureBlobService(IOptions<AzureBlobStorageConfig> storageConfig, ILogger<AzureBlobService> logger, IAttachmentsRepo attr, IExceptionLogRepo eLog) : IAzureBlobService
{
    private readonly string _AzureAccount = storageConfig.Value.AzureAccount ?? "";
    private readonly string _AzureStorage = storageConfig.Value.AzureStorage ?? "";
    //private readonly string _AzureEndpoint;
    private readonly ILogger<AzureBlobService> _logger = logger;
    private readonly IAttachmentsRepo _attr = attr;
    private IExceptionLogRepo _eLog = eLog;

    public string GetBlobContainerName(FILEBLOBS blob)
    {
        string retVal = blob switch
        {
            //No need to separate the blobs accordingly
            FILEBLOBS.DOCUMENTS => "ilstatdocuments",
            FILEBLOBS.IMAGES => "images",
            FILEBLOBS.THUMBNAILS => "thumbnails",
            FILEBLOBS.VIDEOS => "videos",
            FILEBLOBS.SOUNDS => "sounds",
            FILEBLOBS.POWERPOINTS => "powerpoints",
            FILEBLOBS.PACKAGES => "packages",
            _ => throw new Exception("Unknown Blob Name Requested"),
        };
        return retVal;
    }
    public BlobContainerClient GetContainer(string containerName)
    {
        try
        {
            var credential = new StorageSharedKeyCredential(_AzureAccount, _AzureStorage);
            var bloblUrl = $"https://{_AzureAccount}.blob.core.windows.net";
            var client = new BlobServiceClient(new Uri(bloblUrl), credential);
            return client.GetBlobContainerClient(containerName);
            //var container = new BlobContainerClient(_AzureEndpoint, GetBlobName(blob));
            //var storageCredentials = new StorageCredentials(_AzureAccount, _AzureStorage);
            //var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            //var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            //var container = cloudBlobClient.GetContainerReference(GetBlobName(blob));
            //await container.CreateIfNotExistsAsync();

            //return container;
        }
        catch (Exception ex)
        {
            Data.ExceptionLog el = new Data.ExceptionLog()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };
            _eLog.AddExceptionLogAsync(el, "System");
            _logger?.LogError(message: $"Error in AzureBlobService - GetContainer(ContainerName: {containerName})", ex);
            throw;
        }
    }
    public async Task<List<Attachment>> GetDocumentsFromDB(int assignmentId)
    {
        var docs = await _attr.GetAssignmentAttachmentsAsync(assignmentId);

        return docs;
    }
    public async Task<List<Attachment>> GetDocumentsFromAzure(FILEBLOBS blob)
    {
        var docs = new List<Attachment>();
        var container = GetContainer(GetBlobContainerName(blob));
        var docBlobs = container.GetBlobsAsync();

        await foreach (var item in docBlobs)
        {
            var blobClient = container.GetBlobClient(item.Name);
            _ = blobClient.Uri.ToString();
            docs.Add(new Attachment { Name = item.Name, Type = new FileInfo(item.Name).Extension });
        }

        return docs;
    }
    public async Task<bool> UploadFileToBlobAsync(FILEBLOBS blob, string strFileName, string contentType, Stream fileStream)
    {
        try
        {
            //var fileStream = new MemoryStream();
            //using (fileStream);

            //using FileStream uploadFile = File.OpenRead(strFileName);

            //File.openfileread(strFileName);

            //await strFileName.CopyToAsync(fileStream);
            //fileStream.Seek(0, SeekOrigin.Begin);
            //var blob = await _azureBlobServiceBO.GetContainer(FILEBLOBS.PACKAGES);
            //var srcBR = blob.GetBlockBlobReference(package.Id.ToString().ToLower());
            //await srcBR.UploadFromStreamAsync(fileStream);

            var container = GetContainer(GetBlobContainerName(blob));
            //if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            //    await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var blobClient = container.GetBlobClient(strFileName);

            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });

            //var urlString = blobClient.Uri.ToString();

            return true;
        }
        catch (Exception ex)
        {
            Data.ExceptionLog el = new Data.ExceptionLog()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };
            await _eLog.AddExceptionLogAsync(el, "System");
            _logger?.LogError(ex?.ToString());
            throw;
        }
    }
    public async Task<bool> UploadAssignmentFileToBlobAsync(FILEBLOBS blob, int assignmentId, string strFileName, string contentType, Stream fileStream)
    {
        try
        {
            var container = GetContainer(GetBlobContainerName(blob));
            //if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            //    await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            var blobClient = container.GetBlobClient(strFileName);

            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });

            //var urlString = blobClient.Uri.ToString();

            var updateDB = await _attr.UpdateAttachmentAsync(new Attachment { AssignmentId = assignmentId, Name = strFileName, Type = new FileInfo(strFileName).Extension });

            return true;
        }
        catch (Exception ex)
        {
            Data.ExceptionLog el = new Data.ExceptionLog()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };
            await _eLog.AddExceptionLogAsync(el, "System");
            _logger?.LogError(ex?.ToString());
            throw;
        }
    }
    public async Task<bool> DeleteFileFromBlobAsync(FILEBLOBS blob, string strFileName)
    {
        try
        {
            var container = GetContainer(GetBlobContainerName(blob));
            //var createResponse = await container.CreateIfNotExistsAsync();
            //if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            //    await container.SetAccessPolicyAsync(PublicAccessType.Blob);

            var blobClient = container.GetBlobClient(strFileName);

            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            return true;
        }
        catch (Exception ex)
        {
            Data.ExceptionLog el = new Data.ExceptionLog()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };
            await _eLog.AddExceptionLogAsync(el, "System");
            _logger?.LogError(ex?.ToString());
            throw;
        }
    }

    public string GetBlobSASTOkenByFile(string fileName)
    {
        try
        {
            var azureStorageAccount = _AzureAccount;
            var azureStorageAccessKey = _AzureStorage;
            Azure.Storage.Sas.BlobSasBuilder blobSasBuilder = new()
            {
                BlobContainerName = GetBlobContainerName(FILEBLOBS.DOCUMENTS),
                BlobName = fileName,
                ExpiresOn = DateTime.UtcNow.AddMinutes(2),//Let SAS token expire after 5 minutes.
            };
            blobSasBuilder.SetPermissions(Azure.Storage.Sas.BlobSasPermissions.Read);//User will only be able to read the blob and it's properties
            var sasToken = blobSasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(azureStorageAccount,
                azureStorageAccessKey)).ToString();
            return sasToken;
        }
        catch (Exception ex)
        {
            Data.ExceptionLog el = new Data.ExceptionLog()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };
            _eLog.AddExceptionLogAsync(el, "System");
            _logger?.LogError(ex?.ToString());
            throw;
        }
    }
    public string StripPaths(string file)
    {
        if (file.Contains('/'))
        {
            _ = file[(file.LastIndexOf("/") + 1)..];
        }
        if (file.Contains('\\'))
        {
            _ = file[(file.LastIndexOf("\\") + 1)..];
        }
        return file;
    }
    public string StripFile(string file)
    {
        string targetPath = file;
        if (targetPath.Contains('/'))
        {
            targetPath = targetPath[..targetPath.LastIndexOf("/")];
        }
        if (targetPath.Contains('\\'))
        {
            targetPath = targetPath[..targetPath.LastIndexOf("\\")];
        }
        return targetPath;
    }
    //public async Task<byte[]?> GetFileBytes(FILEBLOBS blob, string fileName)
    //{
    //    var srcContainer = await GetContainer(blob);
    //    var dstBR = srcContainer.GetBlockBlobClient(fileName);
    //    if (!await srcContainer.ExistsAsync())
    //    {
    //        return null;
    //    }
    //    //await dstBR.FetchAttributesAsync();
    //    await dstBR.GetPropertiesAsync();
    //    if (dstBR.Length == -1)
    //    {
    //        return null;
    //    }
    //    byte[] data = new byte[dstBR.Properties.Length];
    //    await dstBR.DownloadToByteArrayAsync(data, 0);
    //    return data;
    //}
    //public async Task<Stream> GetFileStream(FILEBLOBS blob, string fileName)
    //{
    //    var srcContainer = await GetContainer(blob);
    //    var dstBR = srcContainer.GetBlockBlobClient(fileName);
    //    Stream data = new MemoryStream();
    //    await dstBR.DownloadToStreamAsync(data);
    //    return data;
    //}
    //public async Task MergeFolders(FILEBLOBS srcBlob, string sourceMask, FILEBLOBS destBlob, string destMask)
    //{
    //    var srcContainer = await GetContainer(srcBlob);
    //    var dstContainer = await GetContainer(destBlob);
    //    List<IListBlobItem> files = await FileList(srcBlob, sourceMask);
    //    if (files != null && files.Count > 0)
    //    {
    //        foreach (var file in files)
    //        {
    //            CloudBlockBlob blob = (CloudBlockBlob)file;
    //            byte[] data = new byte[blob.Properties.Length];
    //            await blob.DownloadToByteArrayAsync(data, 0);
    //            string name = StripPaths(blob.Name);
    //            var dstBR = dstContainer.GetBlockBlobReference(string.Concat(destMask, "/", name));
    //            await dstBR.UploadFromByteArrayAsync(data, 0, (int)blob.Properties.Length);
    //        }
    //    }
    //}
    //public async Task<List<IListBlobItem>> FileList(FILEBLOBS srcBlob, string sourceMask)
    //{
    //    var srcContainer = await GetContainer(srcBlob);
    //    List<IListBlobItem> files = new List<IListBlobItem>();
    //    BlobContinuationToken continuationToken = null;
    //    do
    //    {
    //        var listingResult = await srcContainer.ListBlobsSegmentedAsync(sourceMask, true, BlobListingDetails.Copy, null, continuationToken, null, null);
    //        continuationToken = listingResult.ContinuationToken;
    //        files.AddRange(listingResult.Results);
    //    }
    //    while (continuationToken != null);
    //    return files;
    //}
    //public async Task EmptyFolder(FILEBLOBS srcBlob, string sourceMask)
    //{
    //    var srcContainer = await GetContainer(srcBlob);
    //    List<IListBlobItem> files = new List<IListBlobItem>();
    //    BlobContinuationToken continuationToken = null;
    //    do
    //    {
    //        var listingResult = await srcContainer.ListBlobsSegmentedAsync(sourceMask, true, BlobListingDetails.Copy, null, continuationToken, null, null);
    //        continuationToken = listingResult.ContinuationToken;
    //        files.AddRange(listingResult.Results);
    //    }
    //    while (continuationToken != null);
    //    foreach (var file in files)
    //    {
    //        CloudBlockBlob blob = (CloudBlockBlob)file;
    //        if (!blob.Name.ToLower().Contains("do not delete"))
    //        {
    //            await blob.DeleteIfExistsAsync();
    //        }
    //    }
    //}
}