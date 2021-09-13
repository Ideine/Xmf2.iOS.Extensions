using System;
using CoreGraphics;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class KeyboardToolbarExtensions
	{
		public static UITextField AddToolbar(this UITextField input, string buttonTitle, UIResponder next = null, Action onEnter = null)
		{
			input.InputAccessoryView = CreateToolbar(input.Frame, buttonTitle, next, onEnter);
			return input;
		}

		public static UITextView AddToolbar(this UITextView input, string buttonTitle, UIResponder next = null, Action onEnter = null)
		{
			input.InputAccessoryView = CreateToolbar(input.Frame, buttonTitle, next, onEnter);
			return input;
		}

		private static UIView CreateToolbar(CGRect frame, string buttonTitle, UIResponder next, Action onEnter)
		{
			var toolbar = new UIToolbar(new CGRect(0, 0, frame.Size.Width, 50));
			var button = new UIBarButtonItem(buttonTitle, UIBarButtonItemStyle.Plain, (_, _) =>
			{
				next?.BecomeFirstResponder();
				onEnter?.Invoke();
			});
			toolbar.Items = new[]
			{
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace), button
			};
			toolbar.SizeToFit();
			return toolbar;
		}
	}
}