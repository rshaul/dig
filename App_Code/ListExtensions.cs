using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;

namespace Dig
{
	public static class ListExtensions
	{
		public static List<T> Subset<T>(this List<T> list, int firstIndex, int count) {
			if (firstIndex < 0 || count < 0) {
				throw new ArgumentOutOfRangeException();
			}
			if (firstIndex >= list.Count || count == 0) {
				return new List<T>();
			}

			int lastIndex = firstIndex + count - 1;
			if (lastIndex >= list.Count) {
				lastIndex = list.Count - 1;
			}

			List<T> subset = new List<T>(lastIndex - firstIndex + 1);
			for (int i = firstIndex; i <= lastIndex; i++) {
				subset.Add(list[i]);
			}
			return subset;
		}

		public delegate TOut ConvertDelegate<TIn,TOut>(TIn item);
		public delegate bool TryConvertDelegate<TIn,TOut>(TIn item, out TOut output);

		public static List<TOut> Convert<TIn,TOut>(this List<TIn> list, ConvertDelegate<TIn,TOut> convert) {
			List<TOut> output = new List<TOut>(list.Count);
			foreach (TIn t in list) {
				output.Add(convert(t));
			}
			return output;
		}

		public static List<TOut> TryConvert<TIn, TOut>(this List<TIn> list, TryConvertDelegate<TIn, TOut> tryConvert) {
			List<TOut> output = new List<TOut>();
			foreach (TIn t in list) {
				TOut tOut;
				if (tryConvert(t, out tOut)) {
					output.Add(tOut);
				}
			}
			return output;
		}

		public static List<T> Where<T>(this List<T> list, Func<T, bool> filter) {
			List<T> output = new List<T>();
			foreach (T t in list) {
				if (filter(t)) {
					output.Add(t);
				}
			}
			return output;
		}

		public static void RemoveDuplicates<T>(this List<T> list) {
			for (int i = 0; i < list.Count; i++) {
				for (int j = i + 1; j < list.Count; j++) {
					if (list[i].Equals(list[j])) {
						list.RemoveAt(j);
						j--;
					}
				}
			}
		}
	}

	public static class List
	{
		public static List<T> Of<T>(params T[] items) {
			List<T> list = new List<T>(items.Length);
			list.AddRange(items);
			return list;
		}

		public static List<T> Of<T>(params List<T>[] lists) {
			List<T> output = new List<T>();
			foreach (List<T> list in lists) {
				output.AddRange(list);
			}
			return output;
		}
	}
}