using System;
using System.IO;

public class Chunker {
    public string from;
    public string to;

    public Chunker(string from, string to) {
        from = from;
        to = to;
    }

    public void StartChonk() {

    }

    public static long DirectorySize(DirectoryInfo directory) {
        long size = 0;
        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo file in files) {
            size += file.Length;
        }
        DirectoryInfo[] directories = directory.GetDirectories();
        foreach (DirectoryInfo directoryInfo in directories) {
            size += DirectorySize(directoryInfo);
        }
        return size;
    }
}