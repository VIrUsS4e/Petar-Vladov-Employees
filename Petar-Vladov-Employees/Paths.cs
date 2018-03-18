using System;
using System.IO;

public class Paths
{
    public string GetFile()
    {
        Console.WriteLine("Enter the location of your file (including the file's name and extension):");
        var file = Console.ReadLine();

        while (!File.Exists(file))
        {
            Program.WriteRed($@"The path you entered does not exists. Please enter the full path of your file.{Environment.NewLine}e.g: ""D:\Folder Name\Second Folder\File Name.txt""");
            file = Console.ReadLine();
        }

        return file;
    }

}
