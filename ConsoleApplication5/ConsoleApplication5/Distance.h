#pragma once

class Distance
{
private:
	int feet;
	float inches;
public:
	Distance();
	~Distance();
	Distance(int f,float in);
	void setDistance(int f, float in);
	void print();

	Distance adddistance(Distance d2);
};

