#include <iostream>
#include <map>
#include <string>
#include <limits>


using namespace std;

struct StudentGrade {
    string studentName;
    char grade;
};

int main() {


    map<string, char> gradeBook;

    while (true) {
        cout << "\nMenu:\n";
        cout << "1. Add/change student grade\n";
        cout << "2. View student grade\n";
        cout << "3. View all grades\n";
        cout << "4. Exit\n";
        cout << "Select an action: ";

        int choice;
        cin >> choice;

        // Очистка буфера ввода
        cin.ignore(numeric_limits<streamsize>::max(), '\n');

        switch (choice) {
        case 1: {
            StudentGrade sg;
            cout << "Enter the student's name: ";
            getline(cin, sg.studentName);

            cout << "Enter your grade (A, B, C, D, F): ";
            cin >> sg.grade;
            cin.ignore(numeric_limits<streamsize>::max(), '\n');

            // Проверка корректности оценки
            if (toupper(sg.grade) >= 'A' && toupper(sg.grade) <= 'F') {
                gradeBook[sg.studentName] = toupper(sg.grade);
                cout << "Rating added/changed.\n";
            }
            else {
                cout << "Incorrect assessment!\n";
            }
            break;
        }
        case 2: {
            string name;
            cout << "Enter the student's name: ";
            getline(cin, name);

            auto it = gradeBook.find(name);
            if (it != gradeBook.end()) {
                cout << "Student's assessment " << name << ": " << it->second << endl;
            }
            else {
                cout << "Student not found.\n";
            }
            break;
        }
        case 3: {
            if (gradeBook.empty()) {
                cout << "There are no entries.\n";
            }
            else {
                cout << "\nList of all students and grades:\n";
                for (const auto& entry : gradeBook) {
                    cout << entry.first << ": " << entry.second << endl;
                }
            }
            break;
        }
        case 4:
            return 0;
        default:
            cout << "Incorrect selection. Try again.\n";
        }
    }

    return 0;
}