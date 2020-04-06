using System;
using CoreGraphics;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class AnimationExtensions
	{
		public static TView TranslateY<TView>(this TView view, nfloat offset) where TView : UIView
		{
			CGRect frame = view.Frame;
			frame.Y += offset;
			view.Frame = frame;

			return view;
		}

		public static TView TranslateX<TView>(this TView view, nfloat offset) where TView : UIView
		{
			CGRect frame = view.Frame;
			frame.X += offset;
			view.Frame = frame;

			return view;
		}
	}
}