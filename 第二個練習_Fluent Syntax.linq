<Query Kind="Program" />

void Main()
{
 	
 	string[] names = {"Tom","Dick","Harry","Mary","Jay"};
  
  	IEnumerable<string> query = names
		.Where(n =>n.Contains("a"))
		.OrderBy(n=>n.Length)
		.Select(n =>n.ToUpper());
				  Console.WriteLine(query);
					
}

// Define other methods and classes here

