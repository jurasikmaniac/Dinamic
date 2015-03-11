#include "LongInt_Class.h"
#include <iostream>

using namespace std;

int main()
{
	LongInt_Class a, b;
	char sign;
	while (!feof(stdin))
	try
	{
		a.input();
		b.input();
		cin>>sign;
		if(feof(stdin)) break;
		switch (sign)
		
		{
		case '+':
			(a.plus(b)).output();
			break;

		case '-':
			(a.minus(b)).output();
			break;
			
		case '*':
			(a.multiplication(b)).output();
			break;

		case '/':
			(a.division(b)).output();
			break;

		case '^':
			(a.power(b)).output();
			break;

		case '=':
			if(a.equal(b)){cout<<"True";}
			else {cout<<"False";}
			break;

		case '>':
			if(a.greater(b)){cout<<"True";}
			else {cout<<"False";}
			break;

		case '<':
			if (a.less(b)){cout<<"True";}
			else {cout<<"False";}
			break;

		}
		cout<<endl;
	}
	catch(int Err)
	{
		cout << "Error" << endl;
	}
	return 0;
}

