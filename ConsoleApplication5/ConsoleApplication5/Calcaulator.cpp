#include "Calcaulator.h"

int Calcaulator::add(int x, int y)
{
    return x+y;
}

int Calcaulator::add(int x, int y, int z)
{
    return x+y+z;
}

Calcaulator::Calcaulator()
{
}

int Calcaulator::toadd(int a, int b) {
    return a + b;
}
Calcaulator::Calcaulator(int x, int y):num1(x),num2(y)
{
    
}

Calcaulator::Calcaulator(int x, int y, int z)
{
    num1 = x;
    num2 = y;
    num3 = z;
}

Calcaulator::~Calcaulator()
{
}
