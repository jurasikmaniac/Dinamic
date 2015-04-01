// mergesort.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
#include <ctime>
#include <math.h>


template <class T> const T& min(const T& a, const T& b) {
	return !(b<a) ? a : b;     // or: return !comp(b,a)?a:b; for version (2)
}

template<class T> void Merge(T const *const A, int const nA,
	T const *const B, int const nB,
	T *const C)
{ //��������� ������� ������� A, ����������� nA ���������,
	//  � ������� B, ����������� nB ���������.
	//  ��������� �������� � ������ C.

	int a(0), b(0); //������ ������� ��������� � �������� A � B

	while (a + b < nA + nB) //���� �������� �������� � ��������
	{
		if ((b >= nB) || ((a<nA) && (A[a] <= B[b])))
		{ //������� ������� �� ������� A
			C[a + b] = A[a];
			++a;
		}
		else { //������� ������� �� ������� B
			C[a + b] = B[b];
			++b;
		}
	}
}


template<class T> void MergeSortIterative(T *&A, int const n)
{ //������������� ������ A, ���������� n ���������.
	//  ��� ������ ��������� �� A, ��������, ��������.
	//  (������� �������� ������ �� ��������� �� A)

	T *B(new T[n]); //��������� ����� ������

	for (int size(1); size<n; size *= 2)
	{ //���������� ��� ������� �������� ��� �������: 1,2,4,8...

		int start(0); //������ ������� ������� ����

		for (; (start + size)<n; start += size * 2)
		{ //���������� ��� ���� ��������, � ��������� ��������
			//  �������. (start+size)<n ��������, ��� ������
			//  ���������� ������� ����� ������ �������

			Merge(A + start, size,
				A + start + size, min(size, n - start - size),
				B + start);
			for (size_t i = start; i <start+size*2; i++)
			{
				printf_s("%d ", B[i]);				
			}
			printf_s("|");
			
		}
printf_s("\n");
		//���� ��������� ������� ������� ��� ����, ������ ����-
		//  ���� ��� �� A � B:
		for (; start<n; ++start) B[start] = A[start];

		T *temp(B); B = A; A = temp; //������ ������� ���������
		
	}

	delete[n] B; //������� ��������� �����
}

#define MAX 16
int _tmain(int argc, _TCHAR* argv[])
{
	srand(time(0));
	int *A=new int[MAX];
	printf_s("Unsorted array:\n");
	for (size_t i = 0; i < MAX; i++)
	{
		A[i] = rand() % 10 + 1;
		printf_s("%d ", A[i]);
	}
	printf_s("\n\n");
	MergeSortIterative(A, MAX);
	
	printf_s("\nSorted array:\n");
	for (size_t i = 0; i < MAX; i++)
	{		
		printf_s("%d ", A[i]);
	}
	printf_s("\n\n");
	system("pause");
	return 0;
}

