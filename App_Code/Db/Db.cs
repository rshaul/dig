using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.Common;

	public class DigDb : Db {
		public DigDb() : base("dig") { }
	}

	public abstract class Db
	{
		DbProviderFactory Factory;
		string ConnectionString;

		public Db(string connStringName) {
			Factory = GetFactory(connStringName);
			ConnectionString = GetConnectionString(connStringName);
			Parameters = new DbParameters(Factory);
		}

		public string CommandText { get; set; }
		public DbParameters Parameters { get; private set; }

		public delegate T ConvertResult<T>(DbResult result);

		public bool TryGetResult<T>(ConvertResult<T> convertResult, out T output) {
			using (DbConnection cn = GetConnection()) {
				using (DbCommand cd = GetCommand(cn)) {
					using (DbDataReader dr = cd.ExecuteReader()) {
						if (dr.Read()) {
							output = convertResult(new DbResult(dr));
							return true;
						}
					}
				}
			}
			output = default(T);
			return false;
		}

		public List<T> GetResults<T>(ConvertResult<T> convertResult) {
			List<T> output = new List<T>();
			using (DbConnection cn = GetConnection()) {
				using (DbCommand cd = GetCommand(cn)) {
					using (DbDataReader dr = cd.ExecuteReader()) {
						DbResult result = new DbResult(dr);
						while (dr.Read()) {
							output.Add(convertResult(result));
						}
					}
				}
			}
			return output;
		}

		public void ExecuteNonQuery() {
			using (DbConnection cn = GetConnection()) {
				using (DbCommand cd = GetCommand(cn)) {
					cd.ExecuteNonQuery();
				}
			}
		}

		DbProviderFactory GetFactory(string connStringName) {
			string providerName = ConfigurationManager.ConnectionStrings[connStringName].ProviderName;
			return DbProviderFactories.GetFactory(providerName);
		}

		string GetConnectionString(string connStringName) {
			return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
		}

		DbConnection GetConnection() {
			DbConnection cn = Factory.CreateConnection();
			cn.ConnectionString = ConnectionString;
			cn.Open();
			return cn;
		}

		DbCommand GetCommand(DbConnection cn) {
			DbCommand cd = Factory.CreateCommand();
			cd.Connection = cn;
			cd.CommandText = CommandText;
			foreach (DbParameter p in Parameters) {
				cd.Parameters.Add(p);
			}
			return cd;
		}
	}
