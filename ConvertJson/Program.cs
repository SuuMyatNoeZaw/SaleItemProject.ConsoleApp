// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Drawing;

Console.WriteLine("Hello, World!");

var blog = new BlogModel
{
    Id = 1,
    Author = "Justin",
    Title = "Days",
    Content = "Have a Sweet Day.",
};
string jsonStr=JsonConvert.SerializeObject(blog,Formatting.Indented);
Console.WriteLine(jsonStr);
Console.ReadLine();
public class BlogModel
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
