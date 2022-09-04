#include <string>
#include <filesystem>
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
/*
        void generateTree() {
            int arrayLenght = Directory.GetFiles(from.FullName, "*", SearchOption.AllDirectories).Length + Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories).Length + 1;
            string values[arrayLenght];
            string[] parents = new string[values.Length];
            values[0] = from.FullName;
            parents[0] = "";
            string[] files = Directory.GetFiles(from.FullName, "*", SearchOption.AllDirectories);
            string[] directories = Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories);
            string[] currentValues = new string[files.Length + directories.Length];
            files.CopyTo(currentValues, 0);
            directories.CopyTo(currentValues, files.Length);
            for(int i = 1; i <= currentValues.Length; i++) {
                values[i] = currentValues[i];
                parents[i] = Directory.GetParent(currentValues[i]).FullName;
            }
            tree = new Tree(values, parents);
        }
        void startChonk() {
            
        }*/
};