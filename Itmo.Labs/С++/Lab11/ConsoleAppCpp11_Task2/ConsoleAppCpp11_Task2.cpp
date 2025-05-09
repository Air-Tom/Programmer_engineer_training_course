#include <iostream>
#include <vector>
#include <algorithm> 
#include <cmath>     

class Point {
private:
    double x;
    double y;

public:
    
    Point(double x = 0, double y = 0) : x(x), y(y) {}

    // Функция расчета расстояния до центра координат
    double distanceToOrigin() const {
        return std::sqrt(x * x + y * y);
    }

    // Перегрузка оператора < для сравнения точек по расстоянию до центра координат
    bool operator<(const Point& other) const {
        return distanceToOrigin() < other.distanceToOrigin();
    }

    // Перегрузка оператора << для вывода точки в поток
    friend std::ostream& operator<<(std::ostream& os, const Point& point);
};

std::ostream& operator<<(std::ostream& os, const Point& point) {
    os << "(" << point.x << ", " << point.y << ")";
    return os;
}

int main() {

    std::vector<Point> v;
    v.push_back(Point(1, 2));
    v.push_back(Point(10, 12));
    v.push_back(Point(21, 7));
    v.push_back(Point(4, 8));

    // Сортировка вектора точек
    std::sort(v.begin(), v.end());

    // Вывод отсортированных точек
    for (auto& point : v) {
        std::cout << point << '\n';
    }

    return 0;
}