using System;
using System.Linq;
using Foundation;

// ReSharper disable InconsistentNaming

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class FoundationExtensions
	{
		private static readonly DateTime _reference = new(2001, 1, 1, 0, 0, 0);
		private static readonly DateTime _referenceForNSDate = new(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// Convert NSDate to DateTime
		/// </summary>
		public static DateTime ToDateTime(this NSDate date)
		{
			return _reference.AddSeconds(date.SecondsSinceReferenceDate).ToLocalTime();
		}

		public static NSDate ToNSDate(this DateTime date)
		{
			return NSDate.FromTimeIntervalSinceReferenceDate((date.ToUniversalTime() - _referenceForNSDate).TotalSeconds);
		}

		public static string ConcatToString(this NSData data, string format = "x2")
		{
			return string.Join(string.Empty, data.Select(x => x.ToString(format)));
		}

		public static bool TryGet<T>(this NSDictionary source, string key, out T value) where T : class
		{
			return source.TryGet(new NSString(key), out value);
		}

		public static bool TryGet<T>(this NSDictionary source, NSString key, out T value) where T : class
		{
			if (source.ContainsKey(key) && source[key] is T result)
			{
				value = result;
				return true;
			}

			value = default;
			return false;
		}
	}
}