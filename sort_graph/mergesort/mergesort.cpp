// mergesort.cpp: определяет точку входа для консольного приложения.
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
{ //Выполнить слияние массива A, содержащего nA элементов,
	//  и массива B, содержащего nB элементов.
	//  Результат записать в массив C.

	int a(0), b(0); //Номера текущих элементов в массивах A и B

	while (a + b < nA + nB) //Пока остались элементы в массивах
	{
		if ((b >= nB) || ((a<nA) && (A[a] <= B[b])))
		{ //Копирую элемент из массива A
			C[a + b] = A[a];
			++a;
		}
		else { //Копирую элемент из массива B
			C[a + b] = B[b];
			++b;
		}
	}
}


template<class T> void MergeSortIterative(T *&A, int const n)
{ //Отсортировать массив A, содержащий n элементов.
	//  При работе указатель на A, возможно, меняется.
	//  (Функция получает ссылку на указатель на A)

	T *B(new T[n]); //Временный буфер памяти

	for (int size(1); size<n; size *= 2)
	{ //Перебираем все размеры кусочков для слияния: 1,2,4,8...

		int start(0); //Начало первого кусочка пары

		for (; (start + size)<n; start += size * 2)
		{ //Перебираем все пары кусочков, и выполняем попарное
			//  слияние. (start+size)<n означает, что начало
			//  следующего кусочка лежит внутри массива

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
		//Если последний кусочек остался без пары, просто копи-
		//  руем его из A в B:
		for (; start<n; ++start) B[start] = A[start];

		T *temp(B); B = A; A = temp; //Меняем местами указатели
		
	}

	delete[n] B; //Удаляем временный буфер
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

