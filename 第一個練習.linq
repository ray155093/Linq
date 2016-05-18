<Query Kind="Program" />

void Main()
{
 	int[] source = new int[] { 0, -5, 12, -54, 5, -67, 3, 6 };
 	string[] names = {"Tom","Dick","Harry","Mary","Jay"};
  
  	var data  = from p in   source 
  				where p>0
				select p;
	var data2 = from p in names 
				where  p.Length >3
				select p;
	
				
				  Console.WriteLine(data);
				   Console.WriteLine(data2);
					
}

// Define other methods and classes here

