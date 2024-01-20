#include "Car.h"
int car::counter = 0;
car::car(string brand, int year)
{
	this->Make = brand;
	this->year = year;
	counter++;
}

car::car()
{
	counter++;
}

void car::setMaker(string m)
{
	this->Make = m;
}

string car::getMaker()
{
	return this->Make;
}

int car::getcarcount()
{
	return counter;
}

void car::display()
{
	  cout << "brand: " << Make << endl;
            cout << "Year:  " << year << endl;
}

car::~car()
{
	cout << "End Object" << endl;
	counter--;
}
