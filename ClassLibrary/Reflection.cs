using System.Reflection;

namespace ClassLibrary;

public class Reflection
{
    public string ReflectionInsertInto(Bus obj)
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

    public string ReflectionInsertInto(List<Bus> obj, bool useId)
    {
        string table = "";
        string sql = "";
        string columns = "";
        string values = "";

        foreach (var item in obj)
        {
            var type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();

            table = type.Name;
            values += "(";
            foreach (var property in properties)
            {
                if (property.Name != "Id" || useId)
                {
                    if (!columns.Contains(property.Name))
                        columns += $"{property.Name}, ";
                    values += $"'{property.GetValue(item)}', ";
                }
            }
            values = values.TrimEnd(',', ' ');
            values += "),";
        }
        columns = columns.TrimEnd(',', ' ');
        values = values.TrimEnd(',');
        // Maybe use ToLower() as the table names could be a different case, compared to the Db
        sql = $"INSERT INTO {table} ({columns}) VALUES {values}";
        return sql;
    }
}
