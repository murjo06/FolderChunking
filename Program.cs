using System;
using System.IO;

internal class Program {
    public static void Main(string[] args) {

        // TODO : add save file reading
        // TODO : add save file overriding without data loss

        bool saved = File.Exists("paths.txt");
        string saves = File.ReadAllText("paths.txt");
        string[] savesArray = new string[saves.Split('&').Length];
        if(saved) {
            savesArray = saves.Split('&');
        }
        Console.Write("Please enter the source directory: ");
        string source = Console.ReadLine();
        Console.Write("Please enter the target directory: ");
        string target = Console.ReadLine();
        Console.Write("Would you like to save your directory preferences? y/n  ");
        string saveString = Console.ReadLine();
        while(true) {
            if(saveString != "y" && saveString != "n") {
                Console.Write("Would you live to save your directory preferences? y/n  ");
                saveString = Console.ReadLine();
            } else {
                break;
            }
        }
        bool save = saveString == "y";
        string savePreference;
        if(save) {
            Console.Write("\n1 - save source, 2 - save target, 3 - save both  ");
            savePreference = Console.ReadLine();
            while(true) {
                if(savePreference != "1" && savePreference != "2" && savePreference != "3") {
                    Console.Write("\n1 - save source, 2 - save target, 3 - save both  ");
                    savePreference = Console.ReadLine();
                } else {
                    break;
                }
            }
            if(savePreference == "1") {
                File.WriteAllText("paths.txt", source);
            } else if(savePreference == "2") {
                File.WriteAllText("paths.txt", $"&{target}");
            } else if(savePreference == "3") {
                File.WriteAllText("paths.txt", $"{source}&{target}");
            }
        }
    }
}