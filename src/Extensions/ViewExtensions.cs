using System;
using CoreGraphics;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class ViewExtensions
	{
		#region Creator

		public static UIView CreateSeparator(this object _)
		{
			return new UIView();
		}

		public static UIView CreateSeparator(this object _, int backgroundColor)
		{
			return new UIView().WithBackgroundColor(backgroundColor);
		}

		public static UIView CreateSeparator(this object _, uint backgroundColor)
		{
			return new UIView().WithBackgroundColor(backgroundColor);
		}

		public static UIView CreateSeparator(this object _, UIColor backgroundColor)
		{
			return new UIView().WithBackgroundColor(backgroundColor);
		}

		public static UIView CreateView(this object _)
		{
			return new UIView();
		}

		#endregion

		#region Visibility

		public static TView Hide<TView>(this TView view) where TView : UIView
		{
			view.Hidden = true;
			return view;
		}

		public static TView Show<TView>(this TView view) where TView : UIView
		{
			view.Hidden = false;
			return view;
		}

		/// <summary>
		/// Set alpha to 0
		/// </summary>
		public static TView Invisible<TView>(this TView view) where TView : UIView
		{
			view.Alpha = 0f;
			return view;
		}

		/// <summary>
		/// Set alpha to 1
		/// </summary>
		public static TView Visible<TView>(this TView view) where TView : UIView
		{
			view.Alpha = 1f;
			return view;
		}

		#endregion

		#region BackgroundColor

		public static TView WithBackgroundColor<TView>(this TView view, int color) where TView : UIView
		{
			view.BackgroundColor = color.ColorFromHex();
			return view;
		}

		public static TView WithBackgroundColor<TView>(this TView view, uint color) where TView : UIView
		{
			view.BackgroundColor = color.ColorFromHex();
			return view;
		}

		public static TView WithBackgroundColor<TView>(this TView view, UIColor color) where TView : UIView
		{
			view.BackgroundColor = color;
			return view;
		}

		#endregion

		#region Shadow

		public static TView WithSketchShadow<TView>(this TView view, int shadowColor, float x = 0, float y = 0, float blur = 4) where TView : UIView
			=> view.WithSketchShadow(shadowColor.ColorFromHex(), x, y, blur);

		public static TView WithSketchShadow<TView>(this TView view, uint shadowColor, float x = 0, float y = 0, float blur = 4) where TView : UIView
			=> view.WithSketchShadow(shadowColor.ColorFromHex(), x, y, blur);

		/// <summary>
		/// <see cref="!:https://stackoverflow.com/a/48489506/1479638"/>
		/// </summary>
		public static TView WithSketchShadow<TView>(this TView view, UIColor shadowColor, float x = 0, float y = 0, float blur = 4) where TView : UIView
		{
			view.Layer.ShadowColor = shadowColor.ColorWithAlpha(1).CGColor;
			view.Layer.ShadowOpacity = (float)shadowColor.CGColor.Alpha;
			view.Layer.ShadowOffset = new CGSize(x, y);
			view.Layer.ShadowRadius = blur / 2f;
			return view;
		}

		public static TView WithShadow<TView>(this TView view, int shadowColor, float xOffset, float yOffset, float radius = 8f) where TView : UIView
			=> view.WithShadow(shadowColor.ColorFromHex(), xOffset, yOffset, radius);

		public static TView WithShadow<TView>(this TView view, uint shadowColor, float xOffset, float yOffset, float radius = 8f) where TView : UIView
			=> view.WithShadow(shadowColor.ColorFromHex(), xOffset, yOffset, radius);

		public static TView WithShadow<TView>(this TView view, UIColor shadowColor, float xOffset, float yOffset, float radius = 8f) where TView : UIView
		{
			view.Layer.ShadowColor = shadowColor.ColorWithAlpha(1).CGColor;
			view.Layer.ShadowOpacity = (float)shadowColor.CGColor.Alpha;
			view.Layer.ShadowOffset = new CGSize(xOffset, yOffset);
			view.Layer.ShadowRadius = radius;
			return view;
		}

		public static TView WithoutShadow<TView>(this TView view) where TView : UIView
		{
			view.Layer.ShadowColor = UIColor.Clear.CGColor;
			view.Layer.ShadowOpacity = 0;
			view.Layer.ShadowRadius = 0;
			view.Layer.ShadowOffset = CGSize.Empty;
			return view;
		}

		#endregion

		#region Compression / Hugging

		/// <param name="priority">The first to be compressed is the one with the lowest <see cref="UILayoutPriority"/></param>
		public static TView WithContentCompressionResistancePriority<TView>(this TView view, UILayoutPriority priority, UILayoutConstraintAxis axis) where TView : UIView
		{
			view.SetContentCompressionResistancePriority((float)priority, axis);
			return view;
		}

		/// <summary>
		/// Sets the resistance to expansion beyond the UIKit.UIView's UIKit.UIView.IntrinsicContentSize.
		/// </summary>
		public static TView WithContentHuggingPriority<TView>(this TView view, UILayoutPriority priority, UILayoutConstraintAxis axis) where TView : UIView
		{
			view.SetContentHuggingPriority((float)priority, axis);
			return view;
		}

		#endregion

		#region UserInteraction

		public static TView DisableUserInteraction<TView>(this TView view) where TView : UIView
		{
			view.UserInteractionEnabled = false;
			return view;
		}

		public static TView EnableUserInteraction<TView>(this TView view) where TView : UIView
		{
			view.UserInteractionEnabled = true;
			return view;
		}

		#endregion

		public static TView WithContentMode<TView>(this TView view, UIViewContentMode mode) where TView : UIView
		{
			view.ContentMode = mode;
			return view;
		}

		public static TView WithBorder<TView>(this TView view, UIColor borderColor, float size = 1) where TView : UIView
		{
			view.Layer.BorderColor = borderColor.CGColor;
			view.Layer.BorderWidth = size;
			return view;
		}

		public static TView WithBorder<TView>(this TView view, uint borderColor, float size = 1) where TView : UIView => view.WithBorder(borderColor.ColorFromHex(), size);

		public static TView WithBorder<TView>(this TView view, int borderColor, float size = 1) where TView : UIView => view.WithBorder(borderColor.ColorFromHex(), size);

		public static TView WithCornerRadius<TView>(this TView view, float size) where TView : UIView
		{
			view.Layer.CornerRadius = size;
			return view;
		}

		public static TView WithClipping<TView>(this TView view) where TView : UIView
		{
			view.ClipsToBounds = true;
			return view;
		}

		public static TView WithAlpha<TView>(this TView view, float alpha) where TView : UIView
		{
			view.Alpha = alpha;
			return view;
		}

		public static TView ScaleTo<TView>(this TView view, float ratio) where TView : UIView
		{
			view.Transform = CGAffineTransform.MakeScale(ratio, ratio);
			return view;
		}

		public static void FadeTo<TView>(this TView view, float alpha) where TView : UIView
		{
			view.Alpha = alpha;
		}

		public static T GetFirstDescendantOfType<T>(this UIView root) where T : UIView
		{
			foreach (var view in root.Subviews)
			{
				if (view is T resultView)
				{
					return resultView;
				}

				T descendant = GetFirstDescendantOfType<T>(view);
				if (descendant != null)
				{
					return descendant;
				}
			}

			return null;
		}

		[Obsolete("Use version with out gestureRecognizer")]
		public static TView AddTapAction<TView>(this TView view, Action tapped) where TView : UIView
		{
			UITapGestureRecognizer recognizer = new UITapGestureRecognizer(tapped);
			view.AddGestureRecognizer(recognizer);
			return view;
		}

		/// <param name="tapGestureRecognizer">remove and dispose it when you need</param>
		public static TView AddTapAction<TView>(this TView view, Action tapped, out UITapGestureRecognizer tapGestureRecognizer) where TView : UIView
		{
			tapGestureRecognizer = new UITapGestureRecognizer(tapped);
			view.AddGestureRecognizer(tapGestureRecognizer);
			return view;
		}
	}
}