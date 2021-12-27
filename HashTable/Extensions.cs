using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
	static class Extensions
	{
		public static HashTable<int,string> RandomTable(this HashTable<int, string> table)
		{
			for (int i = 0; i < table.Size*100; i++)
			{
				table.Add(i, RandomString(2, 8));
			}
			return table;
		}
		private static string RandomString(int minSize,int maxSize)
		{
			if(0 < maxSize - minSize && maxSize>0 && minSize > 0)
			{
				var str = new StringBuilder();
				var size = new Random().Next(minSize, maxSize);
				for (int i = 0; i < size; i++)
				{
					str.Append(new Random().Next('a', 'z'));
				}
				return str.ToString();
			}
			throw new Exception("Incorrect value");
		}
	}
}
