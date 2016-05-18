<Query Kind="Program" />

void Main()
{
	int [] numbers = {1,2};
	
	int factor =10;
	IEnumerable<int> query = numbers.Select (n =>n*factor);
	factor=20;
	query.Dump();
}

// Define other methods and classes here
