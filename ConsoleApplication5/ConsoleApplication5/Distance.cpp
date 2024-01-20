#include "Distance.h"
#include <iostream>
using namespace std;

Distance::Distance()
{

}

Distance::~Distance()
{
}

Distance::Distance(int f, float in)
{
	this->feet = f;
	this->inches = in;
}

void Distance::setDistance(int f, float in)
{
	this->feet = f, this->inches = in;
}

void Distance::print()
{
	cout << "Inches: " << this->inches;
	cout << "Feets: " << this->feet;
}

Distance Distance::adddistance(Distance d2)
{
	Distance result;
	result.feet = feet + d2.feet;
	result.inches = inches + d2.inches;
	return result;
}
