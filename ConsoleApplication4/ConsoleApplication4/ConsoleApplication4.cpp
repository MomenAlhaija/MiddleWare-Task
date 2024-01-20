// ConsoleApplication4.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
class Node {
public:
	int data;
	Node* next;
	Node() {
		data = 0;
		next = NULL;
	}
};
class Stack {
public:
	Node* top;
	Stack() { top = NULL; }
	bool IsEmpty() {return top == NULL; };
	void push(int item) {
		Node* newnode = new Node();
		newnode->data = item;
		if (IsEmpty()) {

			newnode->next = NULL;
			top = newnode;
		}
		else {
			newnode->next = top;
			top = newnode;
		}
	}
	void pop() {
		Node* delptr = top;
		top = top->next;
		delete delptr;
	}
	int Peek() {
		return top->data;
	}
	void display() {
		Node* temp = top;
		while (temp != NULL) {
			cout << temp->data;
			temp = temp->next;

		}
		cout << "\n";
	}
	void Count() {
		int count = 0;
		Node* temp = top;
		while (temp != NULL) {
			count++;
			temp =  temp->next;
		}
		cout << count << "\n";
	}
	bool Isfount(int item) {
		Node* temp = top;
		while (temp != NULL) {
			if (temp->data == item) {
				return 1;
			}
			temp = temp->next;
		}
		return 0;
	}
};
class Queue {
	Node* head;
	Node* teil;
public:
	Queue() {
		head = teil = NULL;
	}
	bool IsEmpty() {
		return	(head == NULL) && (teil == NULL);
	}
	void Enqueue(int item) {
		Node* newnode=new Node();
		newnode->data = item;
		if (IsEmpty()) {
			head = teil = newnode;

		}
		else {
			teil->next=newnode;
			teil = newnode;
		}
	}
	void display() {
		Node* temp = head;
		while (temp != NULL) {
			cout << temp->data;
			temp = temp->next;
			cout << "\t";

		}
		cout << "\n";
	}
	bool IsFound(int item) {
		Node* temp = head;
		bool flag = 1;
		while (temp != NULL) {
			if (temp->data == item) {
				flag = true;
				break;
			}
			temp = temp->next;
			cout << "\t";

		}
		return flag;
	}
	void Counter() {
		int counter = 0;
		Node* temp = head;
		while (temp != NULL) {
			counter++;
			temp = temp->next;

		}
		cout << counter <<"\n";
	}
	void Dequeue(){
	
		if (teil == head) {
			delete head;
			teil = head = NULL;
		}
		else {
			Node* delptr = head;
			head = head->next;
			delete delptr;
		}
	}
	void clear() {
		if (!IsEmpty()) {
			Dequeue();
		}
	}
};
class BNode {
public:
	int data;
	BNode* left;BNode *right;
	BNode() {
		left = right = 0;
	}
};
class BST {
	BNode* root;
	BST() {
		root = NULL;
	}
	BNode* insert(BNode*r,int item) {

		if(root=NULL){
			BNode* newnode;
			newnode->data = item;
			root = newnode;
		
		}
		
		else if(item > r->data)
			 
			r->right = insert(r->right,item);
		
		else 
		
			r->left = insert(r->left, item);
	}
	void insert(int item) {
		root = insert(root, item);
	}
	void preorder(BNode*r){
	
		if (r == NULL)
			return;
		cout << r->data;
		preorder(r->left);
		preorder(r->right);

	}

	void inorder(BNode* r) {

		if (r == NULL)
			return;
		inorder(r->left);
		cout << r->data;
		inorder(r->right);

	}
	void postorder(BNode* r) {

		if (r == NULL)
			return;
		postorder(r->left);
		postorder(r->right);
		cout << r->data;

	}
	BNode* IsFound(BNode* r,int item ) {
		if (r == NULL) {
			return NULL;
		}
		else if (r->data == item) {
			return r;
		}
		else if (r->data > item) {
			return IsFound(r->left, item);
		}
		else {
			return IsFound(r->right, item);

		}
	}
	BNode* Min(BNode*r) {
		if (r == NULL) {
			return NULL;
		}
		else if (r->left == NULL) {
			return r;
		}
		return Min(r->left);
	}
	BNode* Max(BNode* r) {
		if (r == NULL) {
			return NULL;
		}
		else if (r->right == NULL) {
			return r;
		}
		return Min(r->right);
	}
	bool search(int key) {
	  	BNode*result=IsFound(root, key);
		if (result == NULL)
			return false;
		return true;
	}
};
class LNode {
public:
	int data;
	LNode* Next;
	LNode(){

		data = 0;
		Next = NULL;

	}
};
class Linked {
public:
	LNode* head;
	
	Linked() { head = NULL; }
	
	bool IsEmpty() {
		if (head == NULL){return true;}
		return false;
	}
	void Insert(int item){


		LNode* newnode=new LNode();
		newnode->data = item;
		
		if (IsEmpty()) {
			newnode->Next = NULL;
			head = newnode;

		}
		else {
			newnode->Next = head;
			head = newnode;
		}
	}
	void print() {
		LNode* temp = head;
		while (temp != NULL)
		{
			cout << temp->data;
			temp = temp->Next;
		}
	}
	int count() {
		int count = 0;
		LNode* temp = head;

		while (temp != NULL)
		{
			count++;
			temp = temp->Next;
		}
		return count;
	}
	void IsFound(int item){
		if (IsEmpty()) {
			cout << "Its Empty\n";
			return;
		}
		else {
			LNode* temp = head;

			while (temp != NULL)
			{
				if (temp->data == item) { cout << "Its found\n"; return; }
				temp = temp->Next;
			}
			cout << "Not Found";
		}

	}
	void pop() {
		LNode* delptr = head;
		while (delptr->Next!=NULL)
		{
			delptr = delptr->Next;
		}

	}
	void insert(int olditem,int newitem){
	
		if (IsEmpty()) { cout << "The List Is Empty\n"; }
		else {
			LNode* newnode=new LNode();
			newnode->data = newitem;
			LNode* temp = head;
			while (temp->Next != NULL && temp->data==olditem) {
	
				temp = temp->Next;
			}
			newnode->Next = temp->Next;
			temp->Next = newnode;
		}

	}
	void delte(int item) {
		if (IsEmpty()) {
			cout << "The List Is Empty" << endl;
		}
		else {
			LNode* delptr = head;
			LNode* prev = NULL;
			while (delptr != NULL && delptr->data != item) {
				prev = delptr;
				delptr = delptr->Next;
			}
			if (delptr == NULL) {
				cout << "Item not found in the list" << endl;
			}
			else {
				if (prev == NULL) {
					head = delptr->Next;
				}
				else {
					prev->Next = delptr->Next;
				}
				delete delptr;
			}
		}
	}
};
class reStack {
public:
	LNode* Top=new LNode();
	reStack() { Top->data = NULL; }
	bool IsEmpty() { return Top == NULL ; }
	void Push(int item){
		LNode* Newnode=new LNode();
		Newnode->data = item;
		if (IsEmpty()) {
			Top = Newnode;
			Newnode->Next = NULL;
		}
		else{
			Newnode->Next = Top;
			Top = Newnode;
		}
	}
	void display() {
		LNode* temp=Top;
		while (temp->Next != NULL) {
			cout << temp->data ;
			temp = temp->Next;
		}
		cout << endl;
	}
	bool IsFound(int item) {
		LNode* temp = Top;
		bool flaq = false;
		while (temp->Next != NULL) {
			if (temp->data == item) {
				flaq = true;
			}
			temp = temp->Next;
		}
		return flaq;
	}
	int count() {
		int count = 0;
		LNode* temp = Top;
		while (temp->Next != NULL) {
			temp = temp->Next;
			count++;
		}
		return count;
	}
	void pop() {

		LNode* delptr = Top;
		Top = Top->Next;
		delete delptr;
	}
};
class Requeue {
	Node* head =new Node();
	Node*teil=new Node();
public:
	Requeue() { head = NULL; teil = NULL; }
	bool IsEmpty() { return (head == NULL) && (teil == NULL); }

	void Enqueue(int item){
		Node* newnode = new Node();
		newnode->data = item;
		if (IsEmpty()) { teil = head = newnode; }
		else {
			teil->next = newnode;
			teil = newnode;
		}
	}
	void desplay() {
		Node* temp = head;
		while (temp != NULL) {
			cout << temp->data << "\t";
			temp = temp->next;
		}
		cout << endl;
	}
	void Dequeue(){
	
		if (IsEmpty()) { teil = head = NULL; }
		else {
			Node* temp = head;
			head = head->next;
			delete temp;
		}
	
	}
	int qetfont() {
		return head->data;
	}
	int dequeue() {
		return teil->data;
	}
	int Counter() {
		Node* temp = head;
		int count = 0;
		while (temp != NULL) {
			count++;
			temp = temp->next;
		}
		return count;
	}
	bool found(int item) {
		Node* temp = head;
		bool flag = false;
		while (temp != NULL) {
			if (temp->data == item) { flag = true; break; }
			temp = temp->next;
		}
		return flag;
	}
};
class ReBST {

public:
	BNode* root;

	ReBST() { root = NULL; };
	BNode* Insert(BNode*r,int item){
		if (r == NULL) {
			BNode* newnode = new BNode();
			newnode->data = item;
			r = newnode;
		}
		else if (item < r->data)
			r->left = Insert(r->left, item);
		else
			r->right = Insert(r->right, item);

		return r;
	}
	void Display(BNode*r) {
		if (r == NULL) {
			return;
		}
		else {
			cout << r->data;
			Display(r->left);
			Display(r->right);
		}

	}
	BNode* search(BNode*r,int key){
		if (r == NULL) {
			return NULL;
		}
		else if (r->data == key) { return r; }
		else if (r < r->left)
			search(r->left,key);
		else
			search(r->right, key);


	}
	BNode* Insert(int item) {
		root=Insert(root, item);
	}
};

int main()
{

	Requeue Q;
	Q.Enqueue(5);
	Q.Enqueue(10);
	Q.Enqueue(15);
	Q.desplay();
	Q.Dequeue();
	Q.desplay();
	cout << Q.Counter() << endl;
	cout << Q.found(50) << endl;



	Linked l;
	
		l.Insert(30);
		l.Insert(20);
		l.Insert(10);
	l.print();
	cout << endl;
	cout<<l.count();
	l.insert(20, 40);
	cout << endl;

	l.print();
	cout << endl;

	l.delte(30);
	cout << endl;
	l.print();
		cout << endl;
		reStack s;
		s.Push(10);
		s.Push(15);
		s.Push(30);
		s.Push(50);
		s.display();
		s.pop();
		s.display();
		cout << s.count() << endl;
		cout << s.IsFound(30);
	//Stack 

   /*Stack s;
   int y;
   for (int i = 0; i < 3; i++) {
	   cout << "Enter Item\n";
	   cin >> y;
	   s.push(y);
   }

   s.display();
  
   s.pop();
   s.display();
   cout << s.Peek() << endl;
   s.Count();
   if (s.Isfount(6)) {
	   cout << "Its found";
   }
   else {
	   cout << "Not Found";
   }*/













	//Queue
	
   //Queue q;

   //int z;
   //for (int i = 0; i < 3; i++) {
	  // cout << "Enter Item\n";
	  // cin >> z;
	  // q.Enqueue(z);
   //}
   //q.display();
   //if (q.IsFound(11)) { cout << "ItsFound\n"; }
   //else { cout << "Not Found\n"; }
   //q.Counter();

   //q.Dequeue();
   //q.Counter();
   //q.display();

   //q.Dequeue();
   //q.Counter();

   //q.display();
   //q.clear();
   //q.display();
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
