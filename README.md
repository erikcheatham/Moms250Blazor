# Moms250Blazor
Public DAR Blazor Demo (.NET 8)

To run this application on your computer you will need several things first

1) You need to create an empty database on your machine and name it Moms250Blazor and replace the ###### sections in the appsettings file with your database and configuration names, users & passwords.  (Not sharing mine!) Now you have two paths to creating the objects in the database.

1a) Either run the script I have in the SQL folder of the project called ProdDB_Backup.  I have commented out the parts that deal with creating the database, especially useful to not deal with compatibility/versioning.  If you decide to create the cloud database in Azure, I recommend the Basic tier of $5.00 / month, it's the only cost you will incur from this project if you deploy it to the cloud.  (Create the database server before the database in Azure)

1b) Your second option is to use the EFCore Migrations I have inside the project and create the database code first, but you'll still need to have SQL server installed first for this approach.  Just open Nuget Package Manager Console and run this command Update-Database -context ApplicationDbContext -> the ProdDB_Backup script above will add these migration rows to the EF_Migrations table for you if you go with the first option
![image](https://github.com/erikcheatham/Moms250Blazor/assets/751184/1df3cdec-a2f7-48b4-ae6f-cc27e190b410)


2)  In case the NuGet packages are not carried over here is the handful needed for this project along with their versions on the right hand side
![image](https://github.com/erikcheatham/Moms250Blazor/assets/751184/6128d6dc-cef4-4566-924e-4dac0d233ae9)

3)  If you don't set up a SendGrid email account then comment out my Transient Email Sender in Program.cs - builder.Services.AddTransient<IEmailSender, EmailSender>();
and then uncomment the Singleton EmailSender that was boilerplate when the project was created, you will also need to go and uncomment out the dependency injection cases in the components and comment out mine also
Just search for these in the project to uncomment `@* @inject IEmailSender<ApplicationUser> EmailSender *@`
and then search for these to comment out @inject IEmailSender es

4)  Lastly after you create your first user, manually update [dbo].[AspNetUsers] like so for full access

  update [dbo].[AspNetUsers]
  set SeniorCoordinator = 1,
		NationalChair = 1
  where UserName = 'yourUsername'

email me if you have any issues: erikcheatham@gmail.com


