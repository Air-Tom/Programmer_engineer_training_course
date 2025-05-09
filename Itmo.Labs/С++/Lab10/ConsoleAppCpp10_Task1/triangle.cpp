#include "triangle.h"
#include <iostream>
#include <cmath>

TriangleComposition::TriangleComposition(double x1, double y1, double x2, double y2, double x3, double y3)
    : dot1(x1, y1), dot2(x2, y2), dot3(x3, y3) {}

void TriangleComposition::printSideLengths() {
    double side1 = dot1.distanceTo(dot2);
    double side2 = dot2.distanceTo(dot3);
    double side3 = dot3.distanceTo(dot1);

    std::cout << "Длины сторон треугольника (композиция): "
        << side1 << ", " << side2 << ", " << side3 << std::endl;
}

double TriangleComposition::calculatePerimeter() {
    double side1 = dot1.distanceTo(dot2);
    double side2 = dot2.distanceTo(dot3);
    double side3 = dot3.distanceTo(dot1);

    return side1 + side2 + side3;
}

double TriangleComposition::calculateArea() {
    double side1 = dot1.distanceTo(dot2);
    double side2 = dot2.distanceTo(dot3);
    double side3 = dot3.distanceTo(dot1);

    double p = (side1 + side2 + side3) / 2; 
    return sqrt(p * (p - side1) * (p - side2) * (p - side3));
}

TriangleAggregation::TriangleAggregation(Dot* dot1, Dot* dot2, Dot* dot3)
    : dot1(dot1), dot2(dot2), dot3(dot3) {}

void TriangleAggregation::printSideLengths() {
    double side1 = dot1->distanceTo(*dot2);
    double side2 = dot2->distanceTo(*dot3);
    double side3 = dot3->distanceTo(*dot1);

    std::cout << "Длины сторон треугольника (агрегация): "
        << side1 << ", " << side2 << ", " << side3 << std::endl;
}

double TriangleAggregation::calculatePerimeter() {
    double side1 = dot1->distanceTo(*dot2);
    double side2 = dot2->distanceTo(*dot3);
    double side3 = dot3->distanceTo(*dot1);

    return side1 + side2 + side3;
}

double TriangleAggregation::calculateArea() {
    double side1 = dot1->distanceTo(*dot2);
    double side2 = dot2->distanceTo(*dot3);
    double side3 = dot3->distanceTo(*dot1);

    double p = (side1 + side2 + side3) / 2; 
    return sqrt(p * (p - side1) * (p - side2) * (p - side3)); 
}