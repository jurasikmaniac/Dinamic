#include "LongInt_Class.h"
#include<iostream>
#include<iomanip>
#include <string>
using namespace std;

void LongInt_Class::Zero()
{
	for (int i = 0; i < 25001; i++) data[i] = 0;
}


void LongInt_Class::SetSize(void)
{
	int i;
	for (i = 25000; i>=0; i--)
	if (data[i]!=0) break;
	size = i+1;
}






void LongInt_Class::input()
{
	string str;
	cin>>str;
	int c=str.size();
	size=0;
	Zero();
	while (c>0)
	{
		c-=4;
		if(c>0)
		{
			for(int i=c;i<c+4;i++)
			{data[size]=data[size]*10 + str[i] - '0';}
		}
		
		else
		{
			for(int i=0;i<c+4;i++)
			{data[size]=data[size]*10 + str[i] - '0';}
		}
		size++;
		if (size > 25000)
		{
			throw 1;
			
		}
	}

}

void LongInt_Class::output()
{
	if (size<25000)
	{
		cout << data[size-1];

		for (int i=size-2;i>=0;i--)
		{
			cout<<setw(4)<<setfill('0')<<data[i];
		}
		
	}
	else 	{throw 1;}
	
}


LongInt_Class LongInt_Class::plus(LongInt_Class& a)
{
	LongInt_Class result;
	result.Zero();
	
	for  ( int i=0;i<25000;i++)
	{
		result.data[i]+=data[i]+a.data[i];
		if(result.data[i]>9999)
		{
			result.data[i]-=10000;
			result.data[i+1]++;
		}
	}
	result.SetSize();
	return result;
}

LongInt_Class LongInt_Class::minus(LongInt_Class& a)
{
	LongInt_Class result;
	result.Zero();
	if (this->less(a)){throw 1;}
	else

	for (int i=0; i<25000;i++)
	{
		result.data[i]+=data[i]-a.data[i];
		if(result.data[i]<0)
		{
			result.data[i]=result.data[i]+10000;
			result.data[i+1]=result.data[i+1]-1;
		}

	}
	result.SetSize();
	return result;

}

LongInt_Class LongInt_Class::multiplication(LongInt_Class& a)
{
	LongInt_Class result;
	result.Zero();
	for (int i=0;i<size;i++)
	{
		for (int j=0; j<a.size;j++)
		{
			result.data[i+j]+=data[i]*a.data[j];
			if(result.data[i+j]>9999)
			{
				result.data[i+j+1]+=result.data[i+j]/10000;
				result.data[i+j]%=10000;

			}
		}
	}
	result.SetSize();
	return result;
}



bool LongInt_Class::greater(LongInt_Class& a)
{
	if(size>a.size){return 1;}
	if(size<a.size){return 0;}
	for (int i=a.size-1; i>=0; i--)
	{
		if(data[i]>a.data[i]){return 1;}
		if(data[i]<a.data[i]){return 0;}
	}
	return 0;
}

bool LongInt_Class::less(LongInt_Class& a)
{
	if(size<a.size){return 1;}
	if(size>a.size){return 0;}
	for (int i=a.size-1; i>=0; i--)
	{
		if(data[i]<a.data[i]){return 1;}
		if(data[i]>a.data[i]){return 0;}
	}
	return 0;
}

bool LongInt_Class::equal(LongInt_Class& a)
{
	if(size!=a.size) {return 0;}

	for (int i=a.size-1; i>=0; i--)
	{
		if(data[i]!=a.data[i]){return 0;}
	}
	return 1;

}

LongInt_Class LongInt_Class::division(LongInt_Class& a)
{
	int div = a.data[0];
	if (div == 0) throw 1;
	LongInt_Class result;
	result.Zero();
	int t=0;
	int i = size-1;
	while (i>=0)
	{
		t = t * 10000 + data[i];
		result.data[i] = t / div;
		t %= div;
		i--;
	}
	result.SetSize();
	return result;
}

LongInt_Class LongInt_Class::power(LongInt_Class& a)
{
	int pow = a.data[1]*10000 + a.data[0];
	LongInt_Class result, temp;
	if (pow==0)
	{
		if ((size == 1)&&(data[0] == 0))
		{
			throw 1;
		}
		else
		{
			result.data[0] = 1;
			result.size = 1;
			return result;
		}
	}

	if ((size == 1)&&(data[0] == 0))
	{
		result.data[0] = 0;
		result.size = 0;
		return result;
	}
	if (pow>330000)
	{
		if ((size == 1)&&(data[0]!=1))
		{
			throw 1;
		}
	}
	

	result.Zero();
	temp.Zero();
	result.data[0] = 1;
	result.size = 1;
	for (int i = 0; i < size; i++)
	temp.data[i] = data[i];
	temp.size = size;
	while (pow)
	{
		if (pow%2==0)
		{
			pow /= 2;
			temp = temp.multiplication(temp);
		}
		else
		{
			pow--;
			result = result.multiplication(temp);
		}
	}
	return result;
}

