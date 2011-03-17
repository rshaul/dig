using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class Key
	{
		public string Value { get; set; }
		public User User { get; set; }
		public DateTime Created { get; set; }
		public bool Used { get; set; }

		public string FormatValue() {
			// Add separator every 5 chars (except at the end)
			string o = "";
			for (int i=0; i < Value.Length; i++) {
				o += Value[i];
				if (i % 5 == 4 && i != Value.Length - 1) o += '-';
			}
			return o;
		}
	}
}