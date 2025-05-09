#include "dot.h"

class TriangleComposition {
private:
    Dot dot1;
    Dot dot2;
    Dot dot3;

public:
    TriangleComposition(double x1, double y1, double x2, double y2, double x3, double y3);
    void printSideLengths();
    double calculatePerimeter();
    double calculateArea();
};

class TriangleAggregation {
private:
    Dot* dot1;
    Dot* dot2;
    Dot* dot3;

public:
    TriangleAggregation(Dot* dot1, Dot* dot2, Dot* dot3);
    void printSideLengths();
    double calculatePerimeter();
    double calculateArea();
};