# DynamicUrl
A small project experimenting with DynamicObject for generating urls.

### Example:

#### Usage:

Instantiate a dynamic variable of DynamicUrl with your base url as a parameter. 
Every property which is called will be translated to /property-name.
Indexer properties can also be used for extending the url with things which cannot be expressed as a member call.

```csharp
dynamic root = new DynamicUrl("http://my.test.com/api");
var url = root.SomeThing[1].Dynamic["bla"];
Console.WriteLine(url);
```

#### Result:

```
http://my.test.com/api/some-thing/1/dynamic/bla
```
