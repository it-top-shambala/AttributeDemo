namespace AttributeDemo.AttributeLib.Attributes;

public class XmlAttribute : Attribute
{
    public string FileName { get; init; }

    public XmlAttribute(string fileName)
    {
        FileName = fileName;
    }
}
