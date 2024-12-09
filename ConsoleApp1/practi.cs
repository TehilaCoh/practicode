//fib bundle --output D:\folder\bundleFile.txt

using System.CommandLine;

var bundleCommand = new Command("bundle", "bundle code files to a single file ");
var bundleOption = new Option<FileInfo>("--output", "File path and name");
bundleCommand.AddOption(bundleOption);
bundleCommand.SetHandler((output) => {
    try { 
    File.Create(output.FullName);
    }
    catch (DirectoryNotFoundException ex) {
     Console.WriteLine("Erro: File path is invalid"); 
    }
    Console.WriteLine("File was created"); 
}, bundleOption);
var rootCommand = new RootCommand("Root command for file bundler CLI ");
rootCommand.AddCommand(bundleCommand);
rootCommand.InvokeAsync(args);
