<Query Kind="Program" />

void Main()
{
	
	var numbers = new List<int>{1,2};
	
	List<int> timesTen = numbers.Select(n =>n*10).ToList();
	
	numbers.Clear();
	
	timesTen.Dump();
	

}

// Define other methods and classes here
