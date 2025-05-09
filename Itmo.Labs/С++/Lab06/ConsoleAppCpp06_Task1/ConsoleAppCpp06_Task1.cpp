#include <iostream>
#include <sstream>
#include <fstream>
#include <Windows.h>

char* RUS(const char* str) {

    static char buf[BUFSIZ];
    OemToCharA(str, buf);
    return buf;
}

int main() {

    setlocale(LC_CTYPE, "Russian");

    std::ofstream f("poem.txt");
    if (!f.is_open()) {
        std::cerr << "Ошибка: не удалось открыть файл для записи." << std::endl;
        return 1;
    }

    std::cout << "Введите стихотворение (для завершения ввода введите пустую строку):" << std::endl;

    std::string line;
    while (true) {
        std::getline(std::cin, line); 
        if (line.empty()) {          
            break;
        }
        line = std::string(RUS(line.c_str())); 
        f << line << std::endl;               
    }

    f.close();

    std::cout << "Стихотворение успешно записано в файл poem.txt." << std::endl;
    std::cin.get();

    return 0;
}