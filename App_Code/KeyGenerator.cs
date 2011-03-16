using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class KeyGenerator
{
	const int KeyLength = 25;
	const char KeySeparator = '-';
	char[] KeyTable = {
		'2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
		'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R',
		'S', 'T', 'U', 'W', 'X', 'Y', 'Z'
	};

	Random random;

	public KeyGenerator() {
		random = new Random();
	}

	char GetRandomChar() {
		// Make random int {0,1,2,...,Table.Length-1}
		int rnd = random.Next(0, KeyTable.Length);
		return KeyTable[rnd];
	}

	public string Generate() {
		string key = "";
		for (int i = 0; i < KeyLength; i++) {
			key += GetRandomChar();
			// Add separator every 5 chars (except at the end)
			if (i % 5 == 4 && i != KeyLength - 1) key += KeySeparator;
		}
		return key;
	}
}