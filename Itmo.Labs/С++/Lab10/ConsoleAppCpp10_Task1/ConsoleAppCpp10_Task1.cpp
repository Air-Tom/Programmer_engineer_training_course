#include <iostream>
#include <Windows.h>
#include "triangle.h"

int main() {

    SetConsoleOutputCP(1251);

    TriangleComposition triangleComp(1, 4, 2, 4, 5, 1);
    triangleComp.printSideLengths();
    std::cout << "Периметр треугольника (композиция): " << triangleComp.calculatePerimeter() << std::endl;
    std::cout << "Площадь треугольника (композиция): " << triangleComp.calculateArea() << std::endl;

    Dot dot1(0, 0);
    Dot dot2(3, 0);
    Dot dot3(0, 4);
    TriangleAggregation triangleAggr(&dot1, &dot2, &dot3);
    triangleAggr.printSideLengths();
    std::cout << "Периметр треугольника (агрегация): " << triangleAggr.calculatePerimeter() << std::endl;
    std::cout << "Площадь треугольника (агрегация): " << triangleAggr.calculateArea() << std::endl;

    return 0;
}