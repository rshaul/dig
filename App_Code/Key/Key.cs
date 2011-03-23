using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class Key
	{
		public string Code { get; set; }
		public User User { get; set; }
		public DateTime Created { get; set; }
		public bool Valid { get; set; }

		public string FormatCode() {
			// Add separator every 5 chars (except at the end)
			string o = "";
			for (int i=0; i < Code.Length; i++) {
				o += Code[i];
				if (i % 5 == 4 && i != Code.Length - 1) o += '-';
			}
			return o;
		}
	}
}