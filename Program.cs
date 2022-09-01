using System;
using System.IO;

internal class Program {
    public static void Main(string[] args) {
        DirectoryInfo dict = new DirectoryInfo(@"/Users/markmarjanovic/Desktop/Files/FolderChunking");
        Console.WriteLine(Chunker.DirectorySize(dict));
    }
}