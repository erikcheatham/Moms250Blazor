using System.Data;
using System.Reflection;

namespace Moms250Blazor.Common;

public static class DataHelper
{
    public static DataTable CreateDataTable<T>(IEnumerable<T> list)
    {
        Type type = typeof(T);
        var properties = type.GetProperties();

        DataTable dataTable = new DataTable();
        foreach (PropertyInfo info in properties)
        {
            dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
        }

        foreach (T entity in list)
        {
            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(entity);
            }

            dataTable.Rows.Add(values);
        }

        return dataTable;
    }
    public static DataTable CreateAssignmentDataTable<T>(IEnumerable<T> list)
    {
        Type type = typeof(T);
        var properties = type.GetProperties();

        DataTable dataTable = new DataTable();
        foreach (PropertyInfo info in properties)
        {
            dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
        }

        foreach (T entity in list)
        {
            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(entity);
            }
            dataTable.Rows.Add(values);
        }

        string[] columnsToRemove = { "Id", "Attachments", "Volunteers" };

        foreach (string x in columnsToRemove)
        {
            if (dataTable.Columns.Contains(x))
                dataTable.Columns.Remove(x);
        }

        return dataTable;
    }
}
