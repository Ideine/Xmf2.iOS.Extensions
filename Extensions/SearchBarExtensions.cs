using Foundation;
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

		#region Internal field

		private static readonly NSString _searchField = new NSString("searchField");
		private static readonly NSString _searchCancelButton = new NSString("cancelButton");

		/// <summary>
		/// Returns <see cref="UISearchBar"/>'s <see cref="UITextField"/>.
		/// NOT SUPPORTED BY APPLE therefore may return null in the future.
		/// </summary>
		public static UITextField TextField(this UISearchBar searchBar)
		{
			try
			{
				return searchBar?.ValueForKey(_searchField) as UITextField;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Returns <see cref="UISearchBar"/>'s cancel button.
		/// NOT SUPPORTED BY APPLE therefore may return null in the future.
		/// </summary>
		public static UIButton CancelButton(this UISearchBar searchBar)
		{
			try
			{
				return searchBar?.ValueForKey(_searchCancelButton) as UIButton;
			}
			catch
			{
				return null;
			}
		}

		#endregion
	}
}