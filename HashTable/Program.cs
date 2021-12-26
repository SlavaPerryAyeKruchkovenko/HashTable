using System;
namespace HashTable
{
	class Program
	{
		static void Main(string[] args)
		{
			var table = new HashTable<int,string>(10000).RandomTable();
			Console.WriteLine($"Процент заполнения таблицы {table.PercentageOfFilling()}");
			Console.WriteLine($"Максимальный размер свзяного списка {table.CountOfLongestList()}");
			Console.WriteLine($"минимальный размер свзяного списка {table.CountOfFewerList()}");
		}

	}
}
