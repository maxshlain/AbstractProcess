using System.Diagnostics;

namespace AbstractProcess.UnitTests;

public class LegacyApplication
{
    public int PingServer(string host)
    {
        var process = new Process();
        process.StartInfo.FileName = "ping";
        process.StartInfo.Arguments = $"-c 1 {host}";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        
        process.Start();
        
        // Read and print the output
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        
        process.WaitForExit();
        
        return process.ExitCode;
    }
}



public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var app = new LegacyApplication();
        var result = app.PingServer("127.0.0.1", 123);
        Assert.Equal(0, result);
    }
}