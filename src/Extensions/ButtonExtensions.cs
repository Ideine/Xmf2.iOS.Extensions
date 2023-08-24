using System;
using CoreGraphics;
using Foundation;
using UIKit;
using Xmf2.iOS.Extensions.Controls.HighlightButton;
using Xmf2.iOS.Extensions.Controls.StatusButton;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class ButtonExtensions
	{
		#region Creator

		public static UIButton CreateButton(this object _, UIButtonType type = UIButtonType.Custom) => new(type);

		public static UIActionHighlightButton CreateActionHighlightButton(this object _) => new();

		public static UIStatusButton CreateStatusButton(this object _) => new();

		#endregion

		#region EdgeInset

		public static TButton WithContentEdgeInset<TButton>(this TButton button, float padding) where TButton : UIButton
		{
			return button.WithContentEdgeInset(new UIEdgeInsets(padding, padding, padding, padding));
		}

		public static TButton WithTitleEdgeInset<TButton>(this TButton button, float padding) where TButton : UIButton
		{
			return button.WithTitleEdgeInset(new UIEdgeInsets(padding, padding, padding, padding));
		}

		public static TButton WithImageEdgeInset<TButton>(this TButton button, float padding) where TButton : UIButton
		{
			return button.WithImageEdgeInset(new UIEdgeInsets(padding, padding, padding, padding));
		}

		public static TButton WithContentEdgeInset<TButton>(this TButton button, float top, float left, float bottom, float right) where TButton : UIButton
		{
			return button.WithContentEdgeInset(new UIEdgeInsets(top, left, bottom, right));
		}

		public static TButton WithTitleEdgeInset<TButton>(this TButton button, float top, float left, float bottom, float right) where TButton : UIButton
		{
			return button.WithTitleEdgeInset(new UIEdgeInsets(top, left, bottom, right));
		}

		public static TButton WithImageEdgeInset<TButton>(this TButton button, float top, float left, float bottom, float right) where TButton : UIButton
		{
			return button.WithImageEdgeInset(new UIEdgeInsets(top, left, bottom, right));
		}

		public static TButton WithContentEdgeInset<TButton>(this TButton button, UIEdgeInsets insets) where TButton : UIButton
		{
			button.ContentEdgeInsets = insets;
			return button;
		}

		public static TButton WithImageEdgeInset<TButton>(this TButton button, UIEdgeInsets insets) where TButton : UIButton
		{
			button.ImageEdgeInsets = insets;
			return button;
		}

		public static TButton WithTitleEdgeInset<TButton>(this TButton button, UIEdgeInsets insets) where TButton : UIButton
		{
			button.TitleEdgeInsets = insets;
			return button;
		}

		#endregion

		#region Title

		public static TButton WithTitle<TButton>(this TButton button, string title) where TButton : UIButton
		{
			button.SetTitle(title, UIControlState.Normal);
			return button;
		}

		public static TButton WithTitle<TButton>(this TButton button, NSAttributedString title) where TButton : UIButton
		{
			button.SetAttributedTitle(title, UIControlState.Normal);
			return button;
		}

		public static TButton WithEllipsis<TButton>(this TButton button) where TButton : UIButton
		{
			button.TitleLabel.LineBreakMode = UILineBreakMode.TailTruncation;
			return button;
		}

		#endregion

		#region TextColor

		public static TButton WithTextColor<TButton>(this TButton button, uint color, UIControlState forState = UIControlState.Normal) where TButton : UIButton
		{
			button.SetTitleColor(color.ColorFromHex(), forState);
			return button;
		}

		public static TButton WithTextColor<TButton>(this TButton button, int color, UIControlState forState = UIControlState.Normal) where TButton : UIButton
		{
			button.SetTitleColor(color.ColorFromHex(), forState);
			return button;
		}

		public static TButton WithTextColor<TButton>(this TButton button, UIColor color, UIControlState forState = UIControlState.Normal) where TButton : UIButton
		{
			button.SetTitleColor(color, forState);
			return button;
		}

		public static TButton WithTextColorHighlight<TButton>(this TButton button, UIColor color) where TButton : UIButton => button.WithTextColor(color, UIControlState.Highlighted);

		public static TButton WithTextColorHighlight<TButton>(this TButton button, int color) where TButton : UIButton => button.WithTextColor(color, UIControlState.Highlighted);

		public static TButton WithTextColorHighlight<TButton>(this TButton button, uint color) where TButton : UIButton => button.WithTextColor(color, UIControlState.Highlighted);

		public static TButton WithTextColorSelected<TButton>(this TButton button, uint color) where TButton : UIButton => button.WithTextColor(color, UIControlState.Selected);

		public static TButton WithTextColorSelected<TButton>(this TButton button, UIColor color) where TButton : UIButton => button.WithTextColor(color, UIControlState.Selected);

		public static TButton WithTextColorSelected<TButton>(this TButton button, int color) where TButton : UIButton => button.WithTextColor(color, UIControlState.Selected);

		#endregion

		#region Image

		public static TButton WithImage<TButton>(this TButton button, string image, UIControlState state = UIControlState.Normal) where TButton : UIButton
		{
			button.SetImage(string.IsNullOrEmpty(image) ? null : new UIImage(image), state);

			return button;
		}

		public static TButton WithImage<TButton>(this TButton button, UIImage image, UIControlState state = UIControlState.Normal) where TButton : UIButton
		{
			button.SetImage(image, UIControlState.Normal);
			return button;
		}

		public static TButton WithImageHighlight<TButton>(this TButton button, string image) where TButton : UIButton => button.WithImage(image, UIControlState.Highlighted);

		public static TButton WithImageHighlight<TButton>(this TButton button, UIImage image) where TButton : UIButton => button.WithImage(image, UIControlState.Highlighted);

		public static TButton WithImageSelected<TButton>(this TButton button, string image) where TButton : UIButton => button.WithImage(image, UIControlState.Selected);

		public static TButton WithImageSelected<TButton>(this TButton button, UIImage image) where TButton : UIButton => button.WithImage(image, UIControlState.Selected);

		public static TButton WithImageFocused<TButton>(this TButton button, string image) where TButton : UIButton => button.WithImage(image, UIControlState.Focused);

		public static TButton WithImageFocused<TButton>(this TButton button, UIImage image) where TButton : UIButton => button.WithImage(image, UIControlState.Focused);

		#endregion

		#region Font

		public static TButton WithFont<TButton>(this TButton button, UIFont font) where TButton : UIButton
		{
			button.TitleLabel.Font = font;
			return button;
		}

		public static TButton WithSystemFont<TButton>(this TButton button, float size, UIFontWeight weight = UIFontWeight.Regular) where TButton : UIButton
		{
			return button.WithFont(UIFont.SystemFontOfSize(size, weight));
		}

		#endregion

		#region BackgroundColor

		public static TButton WithBackgroundColor<TButton>(this TButton button, int backgroundColor, UIControlState forState) where TButton : UIButton
		{
			return button.WithBackgroundColor(backgroundColor.ColorFromHex(), forState);
		}

		public static TButton WithBackgroundColor<TButton>(this TButton button, uint backgroundColor, UIControlState forState) where TButton : UIButton
		{
			return button.WithBackgroundColor(backgroundColor.ColorFromHex(), forState);
		}

		public static TButton WithBackgroundColor<TButton>(this TButton button, UIColor backgroundColor, UIControlState forState) where TButton : UIButton
		{
			UIImage backgroundImage;
			UIGraphics.BeginImageContext(new CGSize(1f, 1f));
			try
			{
				CGContext context = UIGraphics.GetCurrentContext();
				context.SetFillColor(backgroundColor.CGColor);
				context.FillRect(new CGRect(0, 0, 1, 1));
				backgroundImage = UIGraphics.GetImageFromCurrentImageContext();
			}
			finally
			{
				UIGraphics.EndImageContext();
			}

			button.SetBackgroundImage(backgroundImage, forState);
			return button;
		}

		#endregion

		#region OnClick

		[Obsolete("Prefer use OnClick with unregister action")]
		public static TButton OnClick<TButton>(this TButton button, Action action) where TButton : UIButton
		{
			button.TouchUpInside += (sender, e) => action?.Invoke();
			return button;
		}

		[Obsolete("Prefer use OnClick with unregister action")]
		public static TButton OnClick<TButton>(this TButton button, Action<TButton, EventArgs> action) where TButton : UIButton
		{
			button.TouchUpInside += (sender, e) => action?.Invoke((TButton)sender, e);
			return button;
		}

		public static TButton OnClick<TButton>(this TButton button, Action action, out Action unregisterAction) where TButton : UIButton
		{
			void OnTouchUpInside(object sender, EventArgs e) => action?.Invoke();
			button.TouchUpInside += OnTouchUpInside;
			unregisterAction = () => { button.TouchUpInside -= OnTouchUpInside; };
			return button;
		}

		#endregion
	}
}