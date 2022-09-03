#include <string>
class chunker {
    public:
        std::string from;
        std::string to;
    
        chunker(std::string from, std::string to) {
            from = from;
            to = to;
        }
    
        int StartChonk() {
            return 0;
        }
};