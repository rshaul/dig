using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;

	public class DbParameters : IEnumerable<DbParameter>
	{
		List<DbParameter> list = new List<DbParameter>();
		DbProviderFactory factory;

		public DbParameters(DbProviderFactory factory) {
			this.factory = factory;
		}

		void _Add(string key, object value) {
			DbParameter p = factory.CreateParameter();
			p.ParameterName = key;
			p.Value = value;
			list.Add(p);
		}

		public void Add(string key, string value) {
			_Add(key, value);
		}
		public void Add(string key, int value) {
			_Add(key, value);
		}
		public void Add(string key, DateTime value) {
			_Add(key, value);
		}

		public IEnumerator<DbParameter> GetEnumerator() {
			return list.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return list.GetEnumerator();
		}
	}
