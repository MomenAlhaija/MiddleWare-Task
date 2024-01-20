#pragma once
#include <iostream>
#include <string>
using namespace std;

    class car {
    private:
        string Make;
        int year;
       static int counter;
    public:
        car();
        car(string brand, int year);
        void setMaker(string m);
        string getMaker();
        int getcarcount();
   

        void display();
          
        ~car();


    };


