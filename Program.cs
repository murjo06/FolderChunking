using System;
using System.IO;

internal class Program {
    public static void Main(string[] args) {
        Chunker chunker = new Chunker(@"/Users/markmarjanovic/Desktop/Files/FolderChunking", @"/Users/markmarjanovic/Desktop/Files/test");
        Console.Write("Please enter the source location: ");
        string source = Console.ReadLine();
        Console.Write("Please enter the target location: ");
        string target = Console.ReadLine();
        Console.Write("Would you live to save your location preferences? y/n  ");
        string saveString = Console.ReadLine();
        while(true) {
            if(saveString != "y" && saveString != "n") {
                Console.Write("Would you live to save your location preferences? y/n  ");
                saveString = Console.ReadLine();
            }
        }
        bool save = saveString == "y";
        string savePreference;
        if(save) {
            Console.Write("\n1 - save source, 2 - save target, 3 - save both  ");
            savePreference = Console.ReadLine();
            if(savePreference != "1" && savePreference != "2" && savePreference != "3") {
                Console.Write("\n1 - save source, 2 - save target, 3 - save both  ");
                savePreference = Console.ReadLine();
            }
        }
    }
}