// See https://aka.ms/new-console-template for more information
using EasySaveConsole.Models;
using System.Security.Cryptography;

// Walk through the list of files in the directory and print names of the files.
string[] files = Directory.GetFiles(@"C:\share\Music");

// Instance FileModel array with files array
FileModel[] fileModels = new FileModel[files.Length];

// Loop through files array
for (int i = 0; i < files.Length; i++)
{
    // Create new FileModel with file path
    fileModels[i] = new FileModel(files[i]);
    // Print hash
    Console.WriteLine(fileModels[i].Hash);
}