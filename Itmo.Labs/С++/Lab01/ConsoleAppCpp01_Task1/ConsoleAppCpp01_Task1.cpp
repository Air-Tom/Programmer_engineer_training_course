#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

struct Point {
    double x, y;
};

double calculateArea(const vector<Point>& vertices) {
    double area = 0.0;
    int n = vertices.size();

    for (int i = 0; i < n; i++) {
        int j = (i + 1) % n; 
        area += (vertices[i].x * vertices[j].y - vertices[j].x * vertices[i].y);
    }

    return abs(area) / 2.0;
}

int main() 
{
    system("chcp 1251");
    vector<Point> vertices(5); 

    cout << "Введите координаты вершин пятиугольника (x y):" << endl;
    for (int i = 0; i < 5; i++) {
        cout << "Вершина " << i + 1 << ": ";
        cin >> vertices[i].x >> vertices[i].y;
    }

    double area = calculateArea(vertices);

    cout << "Площадь пятиугольника: " << area << endl;

    return 0;
}