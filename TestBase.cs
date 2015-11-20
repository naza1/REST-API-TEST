using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;
using HypermediaApiTests.Util;

namespace HypermediaApiTests
{
	[TestClass]
	public class TestBase
	{
		/// Abstract Conection String
		public string ConnectionString()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["testsDatabaseConnection"].ConnectionString;
			return connectionString;
		}

		/// Sql consult that no contain SELECT sentences
		public void ExecuteNonQuery(string command)
		{
			string connectionString = this.ConnectionString();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(command, connection);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
			}
		}

		/// Sql consult with SELECT sentences, return one int data
		/// <author>Real Nazareno</author>
		public int ExecuteReader_Int(string command)
		{
			Int32 result = 0;
			string connectionString = this.ConnectionString();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand cmd = new SqlCommand(command, connection);
				SqlDataReader sqlReader = cmd.ExecuteReader();
				while (sqlReader.Read())
				{
					result = sqlReader.GetInt32(0);
				}
				sqlReader.Close();
			}
			return result;
		}

		/// Sql consult with SELECT sentences, return one string data
		public string ExecuteReader_String(string command)
		{
			string result = string.Empty;
			string connectionString = this.ConnectionString();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand cmd = new SqlCommand(command, connection);
				SqlDataReader sqlReader = cmd.ExecuteReader();
				while (sqlReader.Read())
					try
					{
						result = sqlReader.GetString(0);
					}
					catch (Exception)
					{
						result = "";
					}
					sqlReader.Close();
			}
			return result;
		}
	}
}
