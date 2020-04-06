using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class TextViewExtensions
	{
		public static UITextView CreateTextView(this object _) => new UITextView();

		public static UITextView WithText(this UITextView input, string text)
		{
			input.Text = text;
			return input;
		}

		public static UITextView WithTextColor(this UITextView input, int color) => input.WithTextColor(color.ColorFromHex());

		public static UITextView WithTextColor(this UITextView input, UIColor color)
		{
			input.TextColor = color;
			return input;
		}
	}
}