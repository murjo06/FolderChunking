#include <iostream>
#include <filesystem>
#include <fstream>
#include <array>
#include <chunker.h>
using namespace std;

int main() {
    fstream saveFile("paths.txt");
    bool saved = false;
    if(saveFile) {
        saved = true;
    } else {
        saved = false;
    }
    bool useSave = false;
    string saves = "";
    array<string, 2> savesArray;
    if(saved) {
        getline(saveFile, saves);
        try { 
            savesArray = split(saves, '&');
            if(savesArray[0] != "" && savesArray[1] != "") {
                cout << "Usable save file detected. Would you like to use it's data? y/n  ";
                string useSaveString;
                cin >> useSaveString;
                while(true) {
                    if(useSaveString != "y" && useSaveString != "n") {
                        cout << "Usable save file detected. Would you like to use it's data? y/n  ";
                        cin >> useSaveString;
                    } else {
                        break;
                    }
                }
                useSave = useSaveString == "y";
            }
            throw(0);
        } catch(int n) { }
    }
    string source = "";
    string target = "";
    string saveString = "";
    if(!useSave) {
        cout << "Please enter the source directory:  ";
        cin >> source;
        cout << "Please enter the target directory:  ";
        cin >> target;
        cout << "Would you like to save your directory preferences? y/n  ";
        cin >> saveString;
        while(true) {
            if(saveString != "y" && saveString != "n") {
                cout << "Would you like to save your directory preferences? y/n  ";
                cin >> saveString;
            } else {
                break;
            }
        }
    }
    try {
        if(useSave && saves[lenght(saves) - 1] == '&') {
            source = savesArray[0];
            cout << "Please enter the target directory:  ";
            cin >> target;
            cout << "Would you like to save your directory preferences? y/n  ";
            cin >> saveString;
            while(true) {
                if(saveString != "y" && saveString != "n") {
                    cout << "Would you like to save your directory preferences? y/n  ";
                    cin >> saveString;
                } else {
                    break;
                }
            }
        }
        throw(0);
    } catch(int n) { }
    try {
        if(useSave && saves[0] == '&') {
            cout << "Please enter the source directory:  ";
            cin >> source;
            target = savesArray[1];
            cout << "Would you like to save your directory preferences? y/n  ";
            cin >> saveString;
            while(true) {
                if(saveString != "y" && saveString != "n") {
                    cout << "Would you like to save your directory preferences? y/n  ";
                    cin >> saveString;
                } else {
                    break;
                }
            }
        }
        throw(0);
    } catch(int n) { }
    bool save = saveString == "y";
    string savePreference;
    if(save) {
        cout << "\n1 - save source, 2 - save target, 3 - save both  ";
        cin >> savePreference;
        while(true) {
            if(savePreference != "1" && savePreference != "2" && savePreference != "3") {
                cout << "\n1 - save source, 2 - save target, 3 - save both  ";
                cin >> savePreference;
            } else {
                break;
            }
        }
        if(savePreference == "1") {
            saveFile << source + "&" + savesArray[1];
        } else if(savePreference == "2") {
            saveFile << savesArray[0] + "&" + target;
        } else if(savePreference == "3") {
            saveFile << source + "&" + target;
        }
    }
    chunker chunker(source, target);
    //chunker.GenerateTree();
    //chunker.StartChonk();
    return 0;
}
int lenght(string str) {
    int length = 0;
    for (int i = 0; str[i] != '\0'; i++) {
        length++;
    }
    return length;
}
array<string, 2> split(string str, char seperator) {
    int currIndex = 0, i = 0;
    array<string, 2> strings;
    int startIndex = 0, endIndex = 0;
    while (i <= lenght(str)) {
        if (str[i] == seperator || i == lenght(str)) {
            endIndex = i;
            string subStr = "";
            subStr.append(str, startIndex, endIndex - startIndex);
            strings[currIndex] = subStr;
            currIndex += 1;
            startIndex = endIndex + 1;
        }
        i++;
    }
    return strings;
}