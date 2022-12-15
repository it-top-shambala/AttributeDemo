using AttributeDemo.AttributeLib.Attributes;

namespace AttributeDemo.TestConsole;

[Json("test_class")]
[Xml("test_class")]
public class TestClass
{
    public string Str { get; set; }
    public int Digit { get; set; }
    public List<string> List { get; set; }
}
