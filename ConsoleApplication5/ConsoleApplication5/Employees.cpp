#include "Employees.h"

Employees::Employees(string n, int id, float s)
{
	this->Name = n;
	this->Emp_Id = id;
	this->Salary = s;
}

Employees::~Employees()
{
}

void Employees::print()
{
	cout << "Name:" << Name << endl;
	cout << "Employee ID: " << Emp_Id << endl;
	cout << "Salary:" << Salary << endl;
}

Sales::Sales(string n, int id, float s, float gs, float cr):Employees( n,  id,  s)
{
	this->Gross_sale = gs;
	this->commission_Rate = cr;
}

void Sales::print()
{
Employees:print();
	cout << "Gross Sale: " << Gross_sale << endl;
	cout << " commission Rate: " << commission_Rate << endl;
	cout << "Salary " << get_total_salary();

}

float Sales::get_total_salary()
{
	return Salary+Gross_sale*commission_Rate;
}

Engineer::Engineer(string n, int id, float s, string sp, int exp, int Ovt, float ovr):Employees( n ,  id ,  s ) 
{
	this->speciality = sp;
	this->Experinces = exp;
	this->overtime_hours = Ovt;
	this->overtime_hours_rate = ovr; 
}

void Engineer::print()
{
Employees:print();
	cout << "specialty: " << speciality << endl;
	cout << "Experinces: " << Experinces << endl;
	cout << "Over Time Hours: " << overtime_hours << endl;
	cout << "Over Time Hour Rate: " << overtime_hours_rate << endl;
	cout << "Salary " << get_total_salary();
}

float Engineer::get_total_salary()
{
	return Salary+ overtime_hours* overtime_hours_rate;
}
