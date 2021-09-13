using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class TextViewExtensions
	{
		public static UITextView CreateTextView(this object _) => new();

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

		#region Font

		public static UITextView WithFont(this UITextView textView, UIFont font)
		{
			textView.Font = font;
			return textView;
		}

		public static UITextView WithSystemFont(this UITextView textView, float size, UIFontWeight weight = UIFontWeight.Regular)
		{
			textView.Font = UIFont.SystemFontOfSize(size, weight);
			return textView;
		}

		public static UITextView WithItalicSystemFont(this UITextView textView, float size)
		{
			textView.Font = UIFont.ItalicSystemFontOfSize(size);
			return textView;
		}

		public static UITextView WithItalicSystemFont(this UITextView textView, float size, UIFontWeight weight)
		{
			UIFontDescriptor descriptor = UIFont.SystemFontOfSize(size, weight).FontDescriptor;
			UIFontDescriptor italicFontDescriptor = descriptor.CreateWithTraits(descriptor.SymbolicTraits | UIFontDescriptorSymbolicTraits.Italic);
			textView.Font = UIFont.FromDescriptor(italicFontDescriptor, size);
			return textView;
		}

		#endregion
	}
}