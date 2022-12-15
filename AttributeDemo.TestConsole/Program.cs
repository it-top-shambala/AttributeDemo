using AttributeDemo.AttributeLib;
using AttributeDemo.TestConsole;

var test = new TestClass { Str = "S", Digit = 5, List = new List<string> { "first", "second", string.Empty } };

await UniversalSerializer.SerializeAsync(test);

await test.SerializeToJsonAsync("test_2.json");
await test.SerializeToXmlAsync("test_2.xml");
