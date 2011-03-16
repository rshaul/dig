using System;
using System.Data;
using System.Data.Common;
using System.Collections;

	public class DbResult
	{
		IDataRecord dr;

		public DbResult(IDataRecord dr) {
			this.dr = dr;
		}
		
		public object Get(string key) {
			return dr[key];
		}

		public T Get<T>(string key) {
			return (T)Convert.ChangeType(Get(key), typeof(T));
		}
	}
