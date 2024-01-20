// stack.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<stack>
using namespace std;
const int Max_Size = 100;
template <class t>
class Stack{
private:
    int top;
    t item[Max_Size];
public:
    Stack() :top(-1) {};
     void Push(t element) {

         if (top >= Max_Size - 1) {
             cout << "The Stack is Full";
         }
         else {
             top++;
             item[top] = element;

         }
     }
     void pop()
     {
         if (!isEmpty())
             top--;
         else
             cout << "The Stack Is Empty";
         
     }
     void getTop() { 
         
         if (!isEmpty())
             cout<<item[top]<<endl;
         else
             cout << "The Stack Is Empty";

     }
     void print() {
         for (int i = 0; i < top + 1; i++)
             cout << item[i]<<"\t\t";
         cout << endl;
     }
     bool isEmpty() { return top == -1; };

};
template <class a>
class linkedStack {
private:
    struct Node {
        a item;
        Node* Next;
    };
    Node* Top;
public:
    linkedStack()
    {
      Top = NULL;

    }
    void Push(a data) {
       
        Node* Newnode=new Node();

       
            Newnode->item = data;
            Newnode->Next = Top;
            Top = Newnode;
        
    }
    void pop() {
        if (!isEmpty()) {
            Node* temp = Top;
            Top = Top->Next;
            delete temp;
        }
        else {
            cout << "The Stack is Empty";
        }
    }
    bool isEmpty() {
        return Top == NULL;
    }
    void getTop() {
        cout<< Top->item<<endl;
    }
    void Display() {
        Node* temp = Top;
        while (temp!= NULL) {
            cout << temp->item<<"\t";
            temp = temp->Next;
        }
        cout << endl;
    }
};
bool arepair(char open, char close) {
    if (open == '(' && close == ')')
        return true;
    else  if (open == '{' && close == '}')
        return true;
    else  if (open == '[' && close == ']')
        return true;
    else
        return false;

}
bool isBalance(string exp) {
    stack<char> s;
    for (int i = 0; i < exp.length(); i++) {
        if(exp[i]=='('|| exp[i] == '{'|| exp[i] == '['){
            s.push(exp[i]);
        }
        else if (exp[i] == ')' || exp[i] == '}' || exp[i] == ']') {
            if (s.empty()||!(arepair(s.top(), exp[i])))
                return false;
            else {
                s.pop();
            }
        }
    }
    return s.empty()?true:false;
}

int main()
{
    //linkedStack<char> s;
    //s.Push('a');
    //s.Push('b');
    //s.Push('c');
    //s.Display();
    //s.pop();
    //s.Display();
    //s.Push('s');
    //s.getTop();
    if (isBalance("{[5+2]*(2/9}}*[2+6]"))
        cout << "Balanced" << endl;
    else
        cout << "UnBalanced" << endl;
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
