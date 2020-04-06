using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class SearchBarExtensions
	{
		public static UISearchBar CreateSearchBar(this object _) => new UISearchBar();

		public static UISearchBar WithPlaceholder(this UISearchBar input, string text)
		{
			input.Placeholder = text;
			return input;
		}

		public static UISearchBar WithTintColor(this UISearchBar input, UIColor color)
		{
			input.TintColor = color;
			return input;
		}

		public static UISearchBar WithBarTintColor(this UISearchBar input, UIColor color)
		{
			input.BarTintColor = color;
			return input;
		}

		public static UISearchBar WithBorderWidthAndColor(this UISearchBar input, UIColor color, int width)
		{
			input.Layer.BorderColor = color.CGColor;
			input.Layer.BorderWidth = width;
			return input;
		}

		public static UISearchBar WithSearchBarStyle(this UISearchBar input, UISearchBarStyle style)
		{
			input.SearchBarStyle = style;
			return input;
		}

		public static UISearchBar WithBarStyle(this UISearchBar input, UIBarStyle style)
		{
			input.BarStyle = style;
			return input;
		}

		public static UISearchBar WithTranslucent(this UISearchBar input, bool isTranslucent = true)
		{
			input.Translucent = isTranslucent;
			return input;
		}

		public static UISearchBar WithOpaque(this UISearchBar input, bool isOpaque = true)
		{
			input.Opaque = isOpaque;
			return input;
		}
	}
}