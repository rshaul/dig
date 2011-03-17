using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class KeyGenerator
	{
		const int KeyLength = 25;

		char[] KeyTable = {
			'2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R',
			'S', 'T', 'W', 'X', 'Y', 'Z'
		};

		public string Generate() {
			string key = "";
			for (int i = 0; i < KeyLength; i++) {
				key += Rand.om(KeyTable);
				// Add separator every 5 chars (except at the end)
				if (i % 5 == 4 && i != KeyLength - 1) key += '-';
			}
			return key;
		}
	}
}