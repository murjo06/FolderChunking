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
    
        chunker(string From, string To) {
            from = From;
            to = To;
            if(from[lenght(from) - 1] != '/') {
                from += '/';
            }
            if(to[lenght(to) - 1] != '/') {
                to += '/';
            }
        }

        void generateTree() {
            struct dirent* dirent;
            struct stat dst;
            DIR* directory;
            directory = opendir(from.c_str());
            int arrayLenght = 0;
            if(directory != NULL) {
                for(dirent = readdir(directory); dirent != NULL; dirent = readdir(directory)) {
                    arrayLenght++;
                }
                closedir(directory);
            } else {
                cerr << "Error detected!" << endl;
            }
            struct dirent* d;
            struct stat dt;
            DIR* dir;
            dir = opendir(from.c_str());
            array<string, sizeof(arrayLenght)> names;
            if(dir != NULL) {
                int index = 0;
                for(d = readdir(dir); d != NULL; d = readdir(dir)) {
                    names[index] = from + d->d_name;
                    index++;
                }
                closedir(directory);
            } else {
                cerr << "Error detected!" << endl;
            }
            array<string, sizeof(arrayLenght)> values;
            array<string, sizeof(arrayLenght)> parents;
            values[0] = from;
            parents[0] = "";
            for(int i = 1; i <= arrayLenght; i++) {
                values[i] = names[i];
                string parent = "";
                int k = 0;
                int len = lenght(names[i]);
                if(names[i][len - 1] != '/') {
                    for(int j = len; j > 0; j--) {
                        k++;
                        if(names[i][j] == '/') {
                            break;
                        }
                    }
                    for(int j = 0; j < j < len - k; j++) {
                        parent += names[i][j];
                    }
                }
                parents[i] = parent;
            }
            //tree = new Tree(values, parents);
        }
        void startChonk() {
            
        }
};