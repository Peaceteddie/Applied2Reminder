using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;


public static class DevExtensions
{
    static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve
    };

    public static T Inspect<T>(this T obj) where T : class?
    {
        switch (obj)
        {
            case string stringValue:
                Console.WriteLine(stringValue);
                break;
            case IEnumerable enumerableValue:
                foreach (var item in enumerableValue)
                    try
                    {
                        Console.WriteLine(JsonSerializer.Serialize(item, options));
                    }
                    catch
                    {
                        Console.WriteLine(item);

                    }
                break;
            default:
                try
                {
                    Console.WriteLine(JsonSerializer.Serialize(obj, options));
                }
                catch
                {
                    Console.WriteLine(obj);
                }
                break;
        }

        return obj;
    }
}