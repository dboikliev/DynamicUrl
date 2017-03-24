using System;

namespace DynamicUrl.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic root = new DynamicUrl("http://my.test.com/api");
            var url = root.SomeThing[1].Dynamic["bla"];
            Console.WriteLine(url);
        }
    }
}
