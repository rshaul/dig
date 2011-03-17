using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class ArrayExtensions
{
	static Random random = new Random();

	public static T GetRandomElement<T>(this T[] array) {
		return array[random.Next(0, array.Length)];
	}
}