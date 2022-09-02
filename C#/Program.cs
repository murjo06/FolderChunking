using System;
using System.IO;

internal class Program {
    public static void Main(string[] args) {
        Chunker chunker = new Chunker(@"/Users/markmarjanovic/Desktop/Files/FolderChunking", @"/Users/markmarjanovic/Desktop/Files/test");
        Console.WriteLine(new DirectoryInfo(@"/Users/markmarjanovic/Desktop/Files/FolderChunking"));
    }
}