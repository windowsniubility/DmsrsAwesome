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
    var argument = new Argument<string>();

    argument.Name = "f1";

    cmd.AddArgument(argument);
    var argument1 = new Argument<string>();
    argument1.Description = "f2";
    cmd.AddArgument(argument1);

    Console.WriteLine(cmd);
  }
  class MyOption : Argument<string>
  {
    
  }
}
