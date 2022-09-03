using System;
using System.IO;

internal class Program {
    public static void Main(string[] args) {

        // TODO : add save file reading
        // TODO : add save file overriding without data loss

        bool saved = File.Exists("paths.txt");
        bool useSave = false;
        string saves = "";
        string[] savesArray = new string[2];
        if(saved) {
            saves = File.ReadAllText("paths.txt");
            try { 
                savesArray = saves.Split('&');
                if(savesArray.Length > 1 && savesArray[0] != "" && savesArray[1] != "") {
                    Console.Write("Usable save file detected. Would you like to use it's data? y/n  ");
                    string useSaveString = Console.ReadLine();
                    while(true) {
                        if(useSaveString != "y" && useSaveString != "n") {
                            Console.Write("Usable save file detected. Would you like to use it's data? y/n  ");
                            useSaveString = Console.ReadLine();
                        } else {
                            break;
                        }
                    }
                    useSave = useSaveString == "y";
                }
            } catch { }
        }
        string source = "";
        string target = "";
        string saveString = "";
        if(!useSave) {
            Console.Write("Please enter the source directory:  ");
            source = Console.ReadLine();
            Console.Write("Please enter the target directory:  ");
            target = Console.ReadLine();
            Console.Write("Would you like to save your directory preferences? y/n  ");
            saveString = Console.ReadLine();
            while(true) {
                if(saveString != "y" && saveString != "n") {
                    Console.Write("Would you like to save your directory preferences? y/n  ");
                    saveString = Console.ReadLine();
                } else {
                    break;
                }
            }
        }
        try {
            if(useSave && saves.EndsWith("&")) {
                source = savesArray[0];
                Console.Write("Please enter the target directory:  ");
                target = Console.ReadLine();
                Console.Write("Would you like to save your directory preferences? y/n  ");
                saveString = Console.ReadLine();
                while(true) {
                    if(saveString != "y" && saveString != "n") {
                        Console.Write("Would you like to save your directory preferences? y/n  ");
                        saveString = Console.ReadLine();
                    } else {
                        break;
                    }
                }
            }
        } catch { }
        try {
            if(useSave && saves[0] == '&') {
                Console.Write("Please enter the source directory:  ");
                source = Console.ReadLine();
                target = savesArray[1];
                Console.Write("Would you like to save your directory preferences? y/n  ");
                saveString = Console.ReadLine();
                while(true) {
                    if(saveString != "y" && saveString != "n") {
                        Console.Write("Would you like to save your directory preferences? y/n  ");
                        saveString = Console.ReadLine();
                    } else {
                        break;
                    }
                }
            }
        } catch { }
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
                File.WriteAllText("paths.txt", $"{source}&" + savesArray[1]);
            } else if(savePreference == "2") {
                File.WriteAllText("paths.txt", savesArray[0] + $"&{target}");
            } else if(savePreference == "3") {
                File.WriteAllText("paths.txt", $"{source}&{target}");
            }
        }
    }
}