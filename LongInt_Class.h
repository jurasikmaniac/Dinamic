class LongInt_Class
{
public: 
	int size;
	int data[25001];
	void input();
	void output();
	void Zero();
	void SetSize();
	LongInt_Class plus (LongInt_Class&);
	LongInt_Class minus (LongInt_Class&);
	LongInt_Class multiplication (LongInt_Class&);
	LongInt_Class division(LongInt_Class&);
	LongInt_Class power(LongInt_Class&);
	bool greater (LongInt_Class&);
	bool less (LongInt_Class&);
	bool equal(LongInt_Class&);

};
