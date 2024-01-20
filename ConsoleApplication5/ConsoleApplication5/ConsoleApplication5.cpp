// ConsoleApplication5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "Car.h"
#include "Calcaulator.h"
#include "Distance.h"
#include <iostream>
#include "Employees.h"

using namespace std;


class Person {
private:
	string Name;
	int Age;
	string Address;
	string Nationality;
public:
	Person(string Name, int Age, string Address, string Nationallity) {
		this->Name = Name;
		this->Age = Age;
		this->Address = Address;
		this->Nationality = Nationallity;
	}
	void Set_Age(int age) { this->Age = age; }
	int Get_Age() { return Age; }
	void Set_Address(string address) { this->Address = address; }
	string Get_Address() { return this->Address; }
	void Set_Nationality(string Nationality) { this->Nationality = Nationality; }
	string Get_Nationality() { return this->Nationality; }
	void Print() {
		cout << "Name: " << Name << endl;
		cout << "Age: " << Age << endl;
		cout << "Address: " << Address << endl;
		cout << "Nationality: " << Nationality << endl;
	}
};
class Student :public Person{
private:
	int Studey_Level;
	string speciallization;
	float GPA;
public:
	Student(string Name, int Age, string Address, string Nationallity,int level,string special,float gpa):Person(Name,Age,Address,Nationallity) {

		this->Studey_Level = level;
		this->speciallization = special;
		this->GPA = gpa;

	};
	void Set_Studey_Level(int level) { this->Studey_Level = level; }
	int Get_Studey_Level() { return this->Studey_Level; }
	void Set_speciallization(string spical) { this->speciallization = spical; }
	string Get_speciallization() { return this->speciallization; }
	void Set_GPA(float gpa) { this->GPA = gpa; }
	float Get_GPA() { return this->GPA; }
	void Print() {
		Person::Print();
		cout << "Studey_Level: " << Studey_Level << endl;
		cout << "speciallization: " << speciallization << endl;
		cout << "GPA: " << GPA << endl;

	}
};

class Employee : public Person {
private:
	float Salary;
	string Rank;
	string  Job;
public:
	Employee(string Name,int Age,string Addres,string Nationallity,float salary, string Rank, string Job):Person( Name,Age,Addres,Nationallity)
	{ 
		this->Salary = Salary, this->Rank = Rank, this->Job = Job;
	}

	void Set_Salary(int Salary) { this->Salary = Salary; }
	float Get_Salary() { return this->Salary; }
	void Set_Rank(string Rank) { this->Rank = Rank; }
	string Get_Rank() { return this->Rank; }
	void Set_Job(string Job) { this->Job = Job; }
	string Get_Job() { return this->Job; }
	friend void Myfriend(Employee EMP);

};

class PHDStudent :public Student, public Employee {
	string search;
public:
	PHDStudent(string Name, int Age, string Address, string Nationallity, int level, string special, float gpa, string re,float salary, string Rank, string Job) :Student(Name, Age, Address, Nationallity, level, special, gpa),Employee(Name, Age, Address, Nationallity,salary,Rank,Job) {
		this->search = re;
	} 
	void Print() {
		Student::Print();
		Employee:Print();
		cout << "Search:  "<< search << endl;
	}
};
void Myfriend(Employee EMP ) { cout << EMP.Job; }

int main()

{
	Employees* emp_ptr;
	Sales s1("Ahmad", 120, 5000, 50000, 0.1);
	Engineer g1("Momen", 120, 10000, "Electrical", 5, 10, 500);
	
	
	int arr[10] = { 1,5,10,12 };

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
