// Array.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
class dynamicArray {
private:
       int  length;
       int Max_Size;
       int* arr;
public:
    dynamicArray(int size):length(0)
    {
        if (size < 0)
            Max_Size = 10;
        else
            Max_Size = size;

        length = 0;
        arr = new int[size];
    } 
    bool isFull() {
        return length == Max_Size;
    }
    bool isEmpty() {
        return length == 0;
    }
    void print() {
        for (int i = 0; i < length; i++) {
            cout<< arr[i] << "\t";
        }
        cout << endl;
    }
    void insertAt(int index, int value) {
        if (isFull()) {
            cout << "The Array is Full\n";
        }
        else if (index<0 || index>length) {
            cout << "The Index is out of range" << endl;
        }
        else {
            for (int i = length; i > index; i--)
                arr[i] = arr[i - 1];
            arr[index] = value;
            length++;
        }
    }
    void removeAt(int index) {
        if (isFull()) {
            cout << "The Array is Full\n";
        }
        else if (index<0 || index>length) {
            cout << "The Index is out of range" << endl;
        }
        else {
            for (int i = index; i < length; i++)
                arr[i] = arr[i + 1];
            length--;
        }
    }
    void inserAtEnd(int value){
        if (isFull()) {
            cout << "The Array is Full" << endl;
        }
        arr[length] = value;
        length++;
    }
    int search(int val) {
        for (int i = 0; i < length; i++)
            if (arr[i] == val)
                return i;
        return -1;
    }
    void insertNoDuplicate(int val) {
        if (search(val) == -1)
            inserAtEnd(val);
        else
            cout << "The item is aleade is inside the Array" << endl;
    }
    void update(int pos, int val) {
        if (pos<0 || pos>length)
            cout << "The Index is Out of Range\n";
        else
            arr[pos] = val;
    }
    int getElement(int index){
        if (index<0 || index>length)
            cout << "The Index is Out of Range\n";
        else
            return arr[index];
    }
    ~dynamicArray() {
        delete[] arr;
    }
    void clear() {
        length = 0;
    }
};
int main()
{
    dynamicArray d(100);
    d.insertAt(0, 10);
    d.insertAt(1, 50);
    d.insertAt(2, 30);
    d.print();
    d.insertNoDuplicate(50);
    d.update(1, 20);
    d.print();

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
