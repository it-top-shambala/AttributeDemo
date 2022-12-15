using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;
using AttributeDemo.AttributeLib.Attributes;

namespace AttributeDemo.AttributeLib;

public static class UniversalSerializer
{
    public static async Task SerializeAsync(object obj)
    {
        var objType = obj.GetType();
        var attributes = objType.GetCustomAttributes();
        foreach (var attribute in attributes)
        {
            string fileName;
            switch (attribute)
            {
                case JsonAttribute jsonAttribute:
                    fileName = $"{jsonAttribute.FileName}.json";
                    await SerializeToJsonAsync(fileName, obj);
                    break;
                case XmlAttribute xmlAttribute:
                    fileName = $"{xmlAttribute.FileName}.xml";
                    await SerializeToXmlAsync(fileName, obj);
                    break;
            }
        }
    }

    private static async Task SerializeToJsonAsync(string fileName, object obj)
    {
        await using var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
        await JsonSerializer.SerializeAsync(file, obj);
    }

    private static async Task SerializeToXmlAsync(string fileName, object obj)
    {
        var xmlSerializer = new XmlSerializer(obj.GetType());
        await using var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
        xmlSerializer.Serialize(file, obj);
    }
}
