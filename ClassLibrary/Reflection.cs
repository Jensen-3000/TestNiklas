using System.Data.SqlTypes;
using System.Reflection;

namespace ClassLibrary;

public class Reflection
{

    public string ReflectionInsertInto(object obj)
    {
        var type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        string table = type.Name;
        string columns = "";
        string values = "";

        foreach (var property in properties)
        {
            if (property.Name != "Id")
            {
                columns += $"{property.Name}, ";
                values += $"'{property.GetValue(obj)}', ";
            }
        }
        columns = columns.TrimEnd(',', ' ');
        values = values.TrimEnd(',', ' ');

        string sql = $"INSERT INTO {table} ({columns}) VALUES ({values})";
        // Maybe use ToLower() as the table names could be a different case, compared to the Db
        return sql;
    }

    //public string ReflectionInsertInto(List<Bus> buses)
    //{
    //    //var type = bus.GetType();
    //    //PropertyInfo[] properties = type.GetProperties();

    //    string table = "";
    //    string columns = "";
    //    string values = "";
    //    string sql = "";

    //    foreach (var bus in buses)
    //    {
    //        bus.GetType().GetProperties();
    //        var items = bus.GetType();
    //        var busprop = items.GetProperties();

    //        foreach (var item in busprop)
    //        {
    //            if (item.Name != "Id")
    //            {
    //                columns += $"{item.Name}, ";
    //                values += $"'{item.GetValue(bus)}', ";
    //            }
    //        }

    //        table = items.Name;
    //        columns = columns.TrimEnd(',', ' ');
    //        values = values.TrimEnd(',', ' ');

    //        sql = $"INSERT INTO {table} ({columns}) VALUES ({values})";
    //    }
    //    return sql;
    //    // Maybe use ToLower() as the table names could be a different case, compared to the Db

    //}

    public string ReflectionInsertInto(List<Bus> obj)
    {
        string table = "";
        string sql = "";
        string columns = "";
        string values = "";
        string value = "";

        foreach (var item in obj)
        {
            var type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();

            table = type.Name;

            foreach (var property in properties)
            {
                if (property.Name != "Id")
                {
                    columns += $"{property.Name}, ";
                    values += $"'{property.GetValue(item)}', ";
                }
            }
        }
        columns = columns.TrimEnd(',', ' ');
        values = values.TrimEnd(',', ' ');

        // Maybe use ToLower() as the table names could be a different case, compared to the Db
        sql = $"INSERT INTO {table} ({columns}) VALUES ({values})";
        return sql;
    }
}
