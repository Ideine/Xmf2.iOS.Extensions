using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class TextFieldExtensions
	{
		public static UITextField CreateTextField(this object _) => new UITextField();

		#region Field type

		public static UITextField AsPasswordField(this UITextField input)
		{
			input.KeyboardType = UIKeyboardType.Default;
			input.SpellCheckingType = UITextSpellCheckingType.No;
			input.AutocorrectionType = UITextAutocorrectionType.No;
			input.AutocapitalizationType = UITextAutocapitalizationType.None;
			input.SecureTextEntry = true;
			return input;
		}

		public static UITextField AsSearchField(this UITextField input, UIReturnKeyType returnKeyType = UIReturnKeyType.Search)
		{
			input.KeyboardType = UIKeyboardType.Default;
			input.SpellCheckingType = UITextSpellCheckingType.No;
			input.ReturnKeyType = returnKeyType;
			input.AutocorrectionType = UITextAutocorrectionType.No;
			input.AutocapitalizationType = UITextAutocapitalizationType.None;
			return input;
		}

		public static UITextField AsEmailField(this UITextField input, UIReturnKeyType returnKeyType = UIReturnKeyType.Next)
		{
			input.KeyboardType = UIKeyboardType.EmailAddress;
			input.SpellCheckingType = UITextSpellCheckingType.No;
			input.AutocorrectionType = UITextAutocorrectionType.No;
			input.AutocapitalizationType = UITextAutocapitalizationType.None;
			input.ReturnKeyType = returnKeyType;
			return input;
		}

		public static UITextField AsNumpadField(this UITextField input, UIReturnKeyType returnKeyType = UIReturnKeyType.Next)
		{
			input.KeyboardType = UIKeyboardType.NumberPad;
			input.SpellCheckingType = UITextSpellCheckingType.No;
			input.AutocorrectionType = UITextAutocorrectionType.No;
			input.AutocapitalizationType = UITextAutocapitalizationType.None;
			input.ReturnKeyType = returnKeyType;
			return input;
		}

		public static UITextField AsPhoneField(this UITextField input, UIReturnKeyType returnKeyType = UIReturnKeyType.Next)
		{
			input.KeyboardType = UIKeyboardType.PhonePad;
			input.SpellCheckingType = UITextSpellCheckingType.No;
			input.AutocorrectionType = UITextAutocorrectionType.No;
			input.AutocapitalizationType = UITextAutocapitalizationType.None;
			input.ReturnKeyType = returnKeyType;
			return input;
		}

		#endregion

		#region TextColor

		public static UITextField WithTextColor(this UITextField input, int color)
		{
			return input.WithTextColor(color.ColorFromHex());
		}

		public static UITextField WithTextColor(this UITextField input, uint color)
		{
			return input.WithTextColor(color.ColorFromHex());
		}

		public static UITextField WithTextColor(this UITextField input, UIColor color)
		{
			input.TextColor = color;
			return input;
		}

		#endregion

		#region Font

		public static UITextField WithFont(this UITextField input, UIFont font)
		{
			input.Font = font;
			return input;
		}

		public static UITextField WithSystemFont(this UITextField input, float size, UIFontWeight weight = UIFontWeight.Regular)
		{
			input.Font = UIFont.SystemFontOfSize(size, weight);
			return input;
		}

		#endregion

		#region Placeholder

		public static UITextField WithPlaceholder(this UITextField input, string placeholder)
		{
			input.Placeholder = placeholder;
			return input;
		}

		public static UITextField WithPlaceholderTextColor(this UITextField input, int color)
		{
			return input.WithPlaceholderTextColor(color.ColorFromHex());
		}

		public static UITextField WithPlaceholderTextColor(this UITextField input, uint color)
		{
			return input.WithPlaceholderTextColor(color.ColorFromHex());
		}

		public static UITextField WithPlaceholderTextColor(this UITextField input, UIColor color)
		{
			input.AttributedPlaceholder = new NSAttributedString(input.Placeholder ?? string.Empty, input.Font, color);
			return input;
		}

		#endregion

		#region Return

		public static UITextField OnReturn(this UITextField input, Action action, bool dismissKeyboard)
		{
			input.ShouldReturn += textField =>
			{
				if (dismissKeyboard)
				{
					textField.ResignFirstResponder();
				}

				action?.Invoke();
				return true;
			};
			return input;
		}

		public static UITextField OnReturnNextResponder(this UITextField input, UIResponder nextResponder, Action action = null)
		{
			input.ShouldReturn += textField =>
			{
				action?.Invoke();
				nextResponder?.BecomeFirstResponder();
				return false;
			};
			return input;
		}

		public static UITextField WithReturnKey(this UITextField input, UIReturnKeyType returnKeyType)
		{
			input.ReturnKeyType = returnKeyType;
			return input;
		}

		#endregion

		public static UITextField WithLeftPadding(this UITextField input, int leftPadding)
		{
			input.LeftView = new UIView(new CGRect(0, 0, leftPadding, 5));
			input.LeftViewMode = UITextFieldViewMode.Always;
			return input;
		}

		public static UITextField WithText(this UITextField input, string text)
		{
			input.Text = text;
			return input;
		}

		public static UITextField WithAlignment(this UITextField input, UITextAlignment alignment)
		{
			input.TextAlignment = alignment;
			return input;
		}

		public static UITextField WithAutocapitalization(this UITextField input, UITextAutocapitalizationType autocapitalizationType = UITextAutocapitalizationType.Sentences)
		{
			input.AutocapitalizationType = autocapitalizationType;
			return input;
		}

		public static UITextField WithBorderStyle(this UITextField input, UITextBorderStyle style)
		{
			input.BorderStyle = style;
			return input;
		}
	}
}