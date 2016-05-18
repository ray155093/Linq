<Query Kind="Program" />

void Main()
{
	var numbers = new List<int>();
	numbers.Add(1);
	IEnumerable<int> query = numbers.Select (n =>n*10);
 	numbers.Add(2);
	query.Dump();
				 //Console.WriteLine(query);
					
}

// Define other methods and classes here

