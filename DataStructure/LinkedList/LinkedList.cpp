// LinkedList.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
class Linked {
private:
	struct Node
	{
		int data;
		Node* Next;
	};
	int count;
	Node* head;
	Node* Tail;
public:
	Linked()
	{
		head = NULL;
		Tail = NULL;
		count = 0;
	}
	bool isEmpty() {
		return head == NULL;
	}
	void insertFirst(int val) {
		Node* newNode = new Node;
		newNode->data = val;
		if (isEmpty()) {
			head=Tail= newNode;
			newNode->Next = NULL;
		}
		else {
			newNode->Next = head;
			head = newNode;
		}
		count++;
	}
	void inserEnd(int val) {
		Node* newNode = new Node;
		newNode->data = val;
		Tail->Next = newNode;
		newNode->Next = NULL;
		count++;
	}
	void inserAt(int index, int val) {
		Node* newNode = new Node;
		newNode->data = val;
		if (index == 0)
			insertFirst(val);
		else if (isEmpty()) {
			head = Tail = newNode;
			newNode->Next = NULL;
		}
		else {
			Node* prev = new Node;
			prev = head;
			for (int i = 1; i < index; i++)
				prev = prev->Next;
			newNode->Next = prev->Next;
			prev->Next = newNode;
		}
		count++;
	}
	void print() {
		Node* temp = new Node;
		temp = head;
		while (temp != NULL) {
			cout << temp->data<<"\n";
			temp = temp->Next;
		}
	}
	void removeFirst() {
		if (isEmpty())
			cout << "The Linked Lis IS Empty\n";
		else if (count == 1) {
			delete head;
			head = Tail = NULL;
			count--;
		}
		else {

			Node* temp = new Node;
			temp = head;
			head = head->Next;
			delete temp;
			count--;
		}
	}
	void removeEnd() {
		if (isEmpty())
			cout << "The Linked List IS Empty";
		else if (count == 1) {
			delete head;
			head = Tail = NULL;
			count--;
		}
		else {
			Node* cur = new Node;
			Node* prev = new Node;
			cur = head->Next;
			prev = head;
			while (cur!=Tail) {
				prev = cur;
				cur = cur->Next;
			}
			delete cur;
			prev->Next = NULL;
			Tail = prev;
			count--;
		}
	}
	void removeAt(int val) {
		Node* prev = new Node;
		Node* cur = new Node;
		prev = head;
		cur = head->Next;
		if (head->data == val) {
			
			head = head->Next;
			delete prev;
			count--;
		}
		while (cur != Tail) {
			if (cur->data == val) {
				break;
			}
			else {
				prev = cur;
				cur = cur->Next;
			}
		}
		prev->Next = cur->Next;
	}
	void reverse() {
		Node* next = new Node;
		Node* prev = new Node;
		Node* cur = new Node;
		next = head->Next;
		prev = NULL;
		cur = head;
		while (next != NULL) {
			next = cur->Next;
			cur->Next = prev;
			prev = cur;
			cur = next;
		}
		head = prev;
	}
	int search(int val) {
		Node* temp = new Node;
		int pos = 0;
		temp = head;
		while (temp != NULL) {
			if (temp->data == val)
				return pos;
			temp = temp->Next;
			pos++;
		}
		return -1;
	}
	
};
class  Duply {
	struct  Node
	{
		int data;
		Node* prev;
		Node* Next;
	};
	Node* first;
	Node* last;
	int count;
public:
	Duply() :first(NULL), last(NULL), count(0) {};
	void insertFirst(int val) {
		Node* newNode = new Node;
		newNode->data = val;

		if (isEmpty()) {

			first = last = newNode;
			newNode->Next = NULL;
			newNode->prev = NULL;
			count++;
		}
		else {
			newNode->Next = first;
			first->prev = newNode;
			newNode->prev = NULL;
			first = newNode;
			count++;
		}
	}
	void insertEnd(int val) {
		Node* newNode = new Node;
		newNode->data = val;
		if (isEmpty()) {
			first = last = newNode;
			newNode->Next = NULL;
			newNode->prev = NULL;
			count++;
		}
		else {
			last->Next = newNode;
			newNode->prev = last;
			newNode->Next = NULL;
			last = newNode;
			count++;

		}
	}
	void insetAt(int index, int val) {

		if (index == 0)
			insertFirst(val);
		else if (index == count)
			insertEnd(val);
		else {
			Node* newNode = new Node;
			newNode->data = val;
			Node* temp = new Node;
			temp = first;
			for (int i = 0; i < index; i++)
				temp = temp->Next;
			temp->Next = newNode;
			newNode->prev = temp;
			newNode->Next = temp->Next;
			temp->Next->prev = newNode;
			count++;
		}
	}
	void removeFirst() {
		if (isEmpty())
			cout << "The Linked List Is Empty" << endl;
		else if (count == 1) {
			delete first;
			first = last = NULL;
			count--;

		}
		else {
			Node* temp = new Node;
			temp = first;
			first = first->Next;
			first->prev = NULL;
			delete temp;
			count--;

		}
	}
	void removeLast() {
		if (isEmpty())
			cout << "The Linked List Is Empty" << endl;
		else if (count == 1) {
			delete first;
			first = last = NULL;
			count--;
		}
		else {
			Node* temp = new Node;
			temp = last;
			last = last->prev;
			last->Next = NULL;
			delete temp;
			count--;

		}

	}
	void remove(int val){

		if (val == 0)
			removeFirst();
		else if (val == count)
			removeLast();
		else if (isEmpty())
			cout << "The Linked List Is Empty" << endl;
		else if (count == 1) {
			delete first;
			first = last = NULL;
			count--;
		}

		else {
			Node* temp = new Node;
			temp = first;
			while (temp != NULL) {
				if (temp->data == val)
					break;
				temp = temp->Next;
			}

			if (temp == NULL) {
				cout << "Not Found\n";
			}
			else {
				temp->prev->Next = temp->Next;
				temp->Next->prev = temp->prev;
				delete temp;
				count--;
			}

		}
	}
	bool isEmpty() {
		return count==0;
	}
	void Display() {
		Node* cur = new Node;
		cur = last;
		while (cur != NULL) {
		  
			cout << cur->data<<"\t";
			cur = cur->prev;
		
		}
		cout << endl;
	}
};


int main()
{
	Duply l;
	l.insertFirst(5);
	l.insertFirst(10);
	l.insertFirst(15);
	l.insetAt(3, 20);
	l.insetAt(4, 30);
	l.insertEnd(50);
	l.removeFirst();
	l.removeLast();
	l.remove(2);
	l.Display();
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
