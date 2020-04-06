using System;
using UIKit;
using Xmf2.iOS.Extensions.Controls;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class LabelExtensions
	{
		#region Creator

		public static UILabel CreateLabel(this object _) => new UILabel();

		public static UILabel CreatePaddingLabel(this object _, UIEdgeInsets inset) => new UIPaddingLabel
		{
			ContentInset = inset
		};

		public static UILabel CreatePaddingLabel(this object _, float top, float left, float bottom, float right) => new UIPaddingLabel
		{
			ContentInset = new UIEdgeInsets(top, left, bottom, right)
		};

		public static UILabel CreatePaddingLabel(this object _, float padding) => new UIPaddingLabel
		{
			ContentInset = new UIEdgeInsets(padding, padding, padding, padding)
		};

		#endregion

		#region TextColor

		public static UILabel WithTextColor(this UILabel label, int color) => WithTextColor(label, color.ColorFromHex());

		public static UILabel WithTextColor(this UILabel label, uint color) => WithTextColor(label, color.ColorFromHex());

		public static UILabel WithTextColor(this UILabel label, UIColor color)
		{
			label.TextColor = color;
			return label;
		}

		#endregion

		#region Font

		public static UILabel WithFont(this UILabel label, UIFont font)
		{
			label.Font = font;
			return label;
		}

		public static UILabel WithSystemFont(this UILabel label, float size, UIFontWeight weight = UIFontWeight.Regular)
		{
			label.Font = UIFont.SystemFontOfSize(size, weight);
			return label;
		}

		public static UILabel WithItalicSystemFont(this UILabel label, float size)
		{
			label.Font = UIFont.ItalicSystemFontOfSize(size);
			return label;
		}

		public static UILabel WithItalicSystemFont(this UILabel label, float size, UIFontWeight weight)
		{
			var descriptor = UIFont.SystemFontOfSize(size, weight).FontDescriptor;
			var italicFontDescriptor = descriptor.CreateWithTraits(descriptor.SymbolicTraits | UIFontDescriptorSymbolicTraits.Italic);
			label.Font = UIFont.FromDescriptor(italicFontDescriptor, size);
			return label;
		}

		public static UILabel WithAdjustsFontSizeToFit(this UILabel label, nfloat minimumScaleFactor)
		{
			label.AdjustsFontSizeToFitWidth = true;
			label.MinimumScaleFactor = minimumScaleFactor;
			return label;
		}

		#endregion

		public static UILabel WithText(this UILabel label, string text)
		{
			label.Text = text;
			return label;
		}

		public static UILabel WithAlignment(this UILabel label, UITextAlignment alignment)
		{
			label.TextAlignment = alignment;
			return label;
		}

		public static UILabel WithTextWrapping(this UILabel label, int maxLine = 0)
		{
			label.Lines = maxLine;
			label.LineBreakMode = UILineBreakMode.WordWrap;
			return label;
		}

		public static UILabel WithEllipsis(this UILabel label)
		{
			label.LineBreakMode = UILineBreakMode.TailTruncation;
			return label;
		}
	}
}