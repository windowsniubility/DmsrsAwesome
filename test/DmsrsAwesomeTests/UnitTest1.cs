using System.CommandLine;

namespace DmsrsAwesomeTests;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void TestMethod1()
  {
    var cmd = new Command("fsutil");
    cmd.AddCommand(new Command("hardlink"));
    cmd.AddArgument(new Argument<string>()
    {
      Name = "f1"
    });
    cmd.AddArgument(new Argument<string> { Description = "f2" });

    Console.WriteLine(cmd);
  }
  class MyOption : Argument<string>
  {
    
  }
}
