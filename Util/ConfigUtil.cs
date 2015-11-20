using System.Configuration;

namespace HypermediaApiTests.Util
{
	public sealed class ConfigUtil
	{
		public static string GetString(string key)
		{
			return ConfigurationManager.AppSettings.Get(key);
		}

		public static int GetInt(string key)
		{
			return int.Parse(ConfigurationManager.AppSettings.Get(key));
		}

		public static decimal GetDecimal(string key)
		{
			return decimal.Parse(ConfigurationManager.AppSettings.Get(key));
		}
	}
}
