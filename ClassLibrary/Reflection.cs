using System.Reflection;

namespace ClassLibrary;

public class Reflection
{
    public string ReflectionInsertInto(List<Bus> bus)
    {
        var type = bus.GetType();
        PropertyInfo[] properties = type.GetProperties();

        string table = type.Name;
        string columns = "";
        string values = "";

        foreach (var property in properties)
        {
            if (property.Name != "Id")
            {
                columns += $"{property.Name}, ";
                values += $"'{property.GetValue(bus)}', ";
            }
        }
        columns = columns.TrimEnd(',', ' ');
        values = values.TrimEnd(',', ' ');

        string sql = $"INSERT INTO {table} ({columns}) VALUES ({values})";
        // Maybe use ToLower() as the table names could be a different case, compared to the Db
        return sql;
    }
}
