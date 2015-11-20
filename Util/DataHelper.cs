using Doppler.FunctionalTests.Enums;
using HypermediaApiTests.Enums;
using System.Collections.Generic;
using System.Linq;

namespace HypermediaApiTests.Util
{
	public static class DataHelper
	{
		public static IEnumerable<SubscriberStatus> SubscriberStatusEnumValues
		{
			get
			{
				return System.Enum.GetValues(typeof(SubscriberStatus)).Cast<SubscriberStatus>();
			}
		}

		public static IEnumerable<string> GetStringValues
		{
			get
			{
				return new List<string> { "", " ", "  ", "Ñ", (string)null };
			}
		}

		public static IEnumerable<string> GetUnsubscribeValues
		{
			get
			{
				return new List<string> {	"administrative", "subscriberRequestNeverSubscribed",
											"subscriberRequestNotInterestingContent", "subscriberRequestIsSpam",
											"subscriberRequestTooManyEmails", "subscriberRequestOther"
											};
			}
		}

		public static IEnumerable<string> GetInvalidEmails
		{
			get
			{
				return new List<string> {	"@", "ab(c)d,e:f;g<h>i[jk]l@example.com", "A@b@c@example.com", "Abc.example.com", "\"ARROBA@YAHOO.COM.AR\"",
									"john..doe@example.com", "john.doe@example..com", "m@.com", "this isnot\allowed@example.com",
									"this still\"not\\allowed@example.com", "@example.org", "()<>[]:,;@\\\\\\!#$%&'*+-/=?^_`{}| ~.a\"@example.org",
									"much.more unusual@example.com",  "very.(),:;<>[].VERY.\"very@\\ \"very\".unusual@strange.example.com",
									"very.unusual.@.unusual.com@example.com", "admin@mailserver1", "abarbuto+ip2..@makingsense.com",
									"abarbuto+ip2.@makingsense.com2", "abarbuto+ip2.,/@makingsense.com", "סמחרני@סמחרני.com", "סמחרני@example.com"
											};
			}
		}

		public static IEnumerable<CampaignStatusEnum> CampaignStatusEnumValues
		{
			get
			{
				return System.Enum.GetValues(typeof(CampaignStatusEnum)).Cast<CampaignStatusEnum>();
			}
		}

		public static IEnumerable<int> GetStateCampaigns
		{
			get
			{
				return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			}
		}
	}
}
