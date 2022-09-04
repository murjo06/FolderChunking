#include <string>
#include <iostream>
#include <filesystem>
#include <array>
#include <sys/stat.h>
#include <dirent.h>
using namespace std;
using namespace std::filesystem;

class chunker {
    public:
        string from;
        string to;
    
        chunker(string from, string to) {
            from = from;
            to = to;
        }

        void generateTree() {
            recursive_directory_iterator iter(from);
            recursive_directory_iterator end;
            size_t tempArrayLenght = 0;
            struct dirent* dirent;
            struct stat dst;
            DIR* directory;
            directory = opendir(from.c_str());
            if(directory != NULL) {
                for(dirent = readdir(directory); dirent != NULL; dirent = readdir(directory)) {
                    string type = dirent->d_name;
                    type = from + type;
                    if(stat(type.c_str(), &dst)) {
                        if (dst.st_mode & S_IFDIR) {
				        	type = "folder";
				        } else if (dst.st_mode & S_IFREG) {
				        	type = "file";
				        }
                    }
                }
                closedir(directory);
            } else {
                cerr << "Error detected!" << endl;
            }
            size_t arrayLenght = tempArrayLenght;
            array<string, sizeof(arrayLenght)> values;
            array<string, sizeof(arrayLenght)> parents;
            values[0] = from;
            parents[0] = "";
            array<string, 0> files; // = Directory.GetFiles(from.FullName, "*", SearchOption.AllDirectories);
            array<string, 0> directories; //= Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories);
            array<string, 0> currentValues;// = new string[files.Length + directories.Length];
            files.CopyTo(currentValues, 0);
            directories.CopyTo(currentValues, files.Length);
            for(int i = 1; i <= currentValues.Length; i++) {
                values[i] = currentValues[i];
                parents[i] = Directory.GetParent(currentValues[i]).FullName;
            }
            tree = new Tree(values, parents);
        }
        void startChonk() {
            
        }
};