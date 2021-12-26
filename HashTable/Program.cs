using System;
namespace HashTable
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			var table = new HashTable<int,int>(2);
			table.Add(1, 1);
			table.Add(2, 2);
			table.Remove(2);
			Console.WriteLine(table.Containes(1));
		}
	}
}
