using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
	public class HashTable<TKey, TValue> : IHashTable<TKey,TValue>, IEnumerable<Tuple<TKey, TValue>>
	{
		private readonly LinkedList<Tuple<TKey,TValue>>[] map;
		private readonly uint size;
		public HashTable(uint size)
		{
			map = new LinkedList<Tuple<TKey, TValue>>[size];
			this.size = size;
		}
		public void Add(TKey key, TValue value)
		{
			if (!Containes(key))
			{
				var list = GetList(key);
				list.AddLast(Tuple.Create(key, value));
			}
			else
			{
				throw new IndexOutOfRangeException("Key is busy");
			}
		}

		public TValue Remove(TKey key)
		{
			if (Containes(key))
			{
				var list = GetList(key);
				var value = Search(key);
				list.Remove(value);
				return value.Item2;
			}
			throw new IndexOutOfRangeException("Invalid key");
		}
		public bool Containes(TKey key)
		{
			var list = GetList(key);
			return list.Any(x => x.Item1?.Equals(key) ?? false);	
		}
		public TValue this[TKey key]
		{
			get => Search(key).Item2;
			set => Add(key, value);
		}
		public Tuple<TKey, TValue> Search(TKey key)
		{
			var list = GetList(key);
			foreach (var nodes in list)
				if (nodes.Item1?.Equals(key) ?? false)
					return nodes;
			throw new IndexOutOfRangeException("Incorrect Key");
		}
		private LinkedList<Tuple<TKey,TValue>> GetList(TKey key)
		{
			int hash = GetHashCode(key);
			if (map[hash] is null)
				map[hash] = new LinkedList<Tuple<TKey, TValue>>();
			return map[hash];
		}
		private int GetHashCode(TKey key)
		{
			var value = 1 / Math.E + key.ToString()[0];
			var trunc = Math.Truncate(value);
			return (int)(size * (value-trunc));
		}

		public IEnumerator<Tuple<TKey, TValue>> GetEnumerator()
		{
			foreach (var list in map)
			{
				foreach (var node in list)
				{
					yield return node;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		
	}
	interface IHashTable<TKey,TValue>
	{
		Tuple<TKey, TValue> Search(TKey key);
		void Add(TKey key, TValue value);
		TValue Remove(TKey key);
	}

}
