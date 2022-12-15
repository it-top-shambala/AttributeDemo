namespace AttributeDemo.AttributeLib.Attributes;

public class JsonAttribute : Attribute
{
    public string FileName { get; init; }

    public JsonAttribute(string fileName)
    {
        FileName = fileName;
    }
}
