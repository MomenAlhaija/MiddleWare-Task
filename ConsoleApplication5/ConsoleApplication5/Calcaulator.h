#pragma once
class Calcaulator
{
private:
int	num1, num2, num3;
public:
	int add(int x, int y);
	int add(int x, int y, int z);
	Calcaulator();
	Calcaulator(int x,int y);
	Calcaulator(int x,int y,int z);
	~Calcaulator();
	static int toadd(int a, int b);
};

