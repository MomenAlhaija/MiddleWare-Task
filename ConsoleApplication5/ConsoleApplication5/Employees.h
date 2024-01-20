#pragma once
#include <iostream>
#include <string>
using namespace std;


class Employees {
protected:
	string Name;
	int Emp_Id;
	float Salary;
public:
	Employees(string n, int id, float s);
	~Employees();
	virtual float get_total_salary() = 0;
	virtual void print();
};


class Sales:Employees 
{
private:
	float Gross_sale;
	float commission_Rate;
public:
	Sales(string n, int id, float s, float gs, float cr);
	~Sales ();
	void print();
 	float  get_total_salary();
};

class Engineer:Employees
{
public:
	Engineer(string n, int id, float s, string sp, int exp,int Ovt,float ovr);
	~Engineer();
	void print();
	float get_total_salary();

private:
	string speciality;
	int Experinces;
	int overtime_hours;
	float overtime_hours_rate;
	
};


