using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Rand
{
	static Random random = new Random();

	public static T om<T>(T[] a) {
		return a[random.Next(0, a.Length)];
	}
}