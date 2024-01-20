// Queue.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
const int Max_length = 5;
class circularQueue {
private:
    int front;
    int rear;
    int count;
    int arr[Max_length];
public:
    circularQueue()
    {
         front=0;
         rear= Max_length-1;
         count=0;
    }
    bool isEmpty() {
        return count == 0;
    }
    bool isFull() {
        return count == Max_length;
    }
    void enQueue(int item) {
        if (isFull())
            cout << "The Queue is Full\n";
        else {
            rear = (rear + 1) % Max_length;
            arr[rear] = item;
            count++;
        }

    }
    void deQueue() {
        if (isEmpty())
            cout << "The Quue is Empty" << endl;
        else {
            front = (front + 1) % Max_length;
            count--;
        }

    }
    int forntQueue() {
        return arr[front];
    }
    int rarQueue() {
        return arr[rear];
    }
    void Display() {
        if (!isEmpty()) {
            for (int i = front; i != rear; i = (i + 1) % Max_length) {
                cout << arr[i] << " ";
            }
            cout << arr[rear];
            cout << endl;
        }
        else {
            cout << "The Queue is Empty";
        }
       
    }
    int search(int elemnt) {
        int pos = -1;
        if (!isEmpty()) {
            for (int i = front; i != rear; i = (i + 1) % Max_length) {
                if (arr[i] == elemnt) {
                    pos = i;
                    return pos;
                }
            }
            if (pos == -1) {
                if (arr[rear] == elemnt) {
                    pos = rear;
                    return pos;
                }
                else {
                    return -1;
                }
            }
        }
        else {
            return -1;
        }
    }
};
class linkedQueue {
    struct Node
    {
        int data;
        Node* Next;
    };
    Node* front;
    Node* rear;
    int count;
public:
    linkedQueue() :front(NULL), rear(NULL), count(0) {};
    bool isEmpty() { return (rear == NULL) && (front == NULL); }
   
    void enQueue(int value) {
        Node* newNode = new Node();
        newNode->data = value;
        newNode->Next = NULL;
        if (isEmpty()) {
            front = rear = newNode;
            count++;
           
        }
        else {
            rear->Next= newNode;
            rear = newNode;
            count++;
        }
    }
    void deQueue() {
        if (!isEmpty()) {
            cout << "The Queue is Empty" << endl;
        }
        else if (front == rear) {
            front = rear = NULL;
            count--;
        }
        else {
            Node* temp = new Node();
            temp = front;
            front = front->Next;
            delete temp;
            count--;
        }
    }
    int getFront() { return front->data; }
    int getRear() { return rear->data; }
    void display() {
        Node* temp =front;
        while(temp!=NULL) {
            cout << temp->data;
            temp = temp->Next;
        }
    }
        
};

int main()
{
    linkedQueue q;
    q.enQueue(3);
    q.enQueue(5);
    q.enQueue(4);
    q.display();
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
