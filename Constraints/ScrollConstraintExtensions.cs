using UIKit;
using static UIKit.NSLayoutAttribute;
using static UIKit.NSLayoutRelation;

namespace Xmf2.iOS.Extensions.Constraints
{
	public static class ScrollConstraintExtensions
	{
		public static UIScrollView VerticalScrollContentConstraint(this UIScrollView scroll, UIView content, float horizontalMargin = 0f)
		{
			scroll.WithConstraint(scroll, Left, Equal, content, Left, 1, -horizontalMargin / 2f, $"{nameof(VerticalScrollContentConstraint)}-Left")
				.WithConstraint(scroll, Right, Equal, content, Right, 1f, horizontalMargin / 2f, $"{nameof(VerticalScrollContentConstraint)}-Right")
				.WithConstraint(scroll, Top, Equal, content, Top, 1f, 0f, $"{nameof(VerticalScrollContentConstraint)}-Top")
				.WithConstraint(scroll, Bottom, Equal, content, Bottom, 1f, 0f, $"{nameof(VerticalScrollContentConstraint)}-Bottom")
				.WithConstraint(scroll, CenterX, Equal, content, CenterX, 1f, 0f, $"{nameof(VerticalScrollContentConstraint)}-CenterX");
			return scroll;
		}

		public static UIScrollView VerticalScrollFilledContentConstraint(this UIScrollView scroll, UIView content, float horizontalMargin = 0f)
		{
			scroll.WithConstraint(scroll, Left, Equal, content, Left, 1, -horizontalMargin / 2f, $"{nameof(VerticalScrollFilledContentConstraint)}-Left")
				.WithConstraint(scroll, Right, Equal, content, Right, 1f, horizontalMargin / 2f, $"{nameof(VerticalScrollFilledContentConstraint)}-Right")
				.WithConstraint(scroll, Top, Equal, content, Top, 1f, 0f, $"{nameof(VerticalScrollFilledContentConstraint)}-Top")
				.WithConstraint(scroll, Bottom, Equal, content, Bottom, 1f, 0f, $"{nameof(VerticalScrollFilledContentConstraint)}-Bottom")
				.WithConstraint(scroll, Height, LessThanOrEqual, content, Height, 1f, 0f, $"{nameof(VerticalScrollFilledContentConstraint)}-Height")
				.WithConstraint(scroll, CenterX, Equal, content, CenterX, 1f, 0f, $"{nameof(VerticalScrollFilledContentConstraint)}-CenterX");
			return scroll;
		}

		public static UIScrollView HorizontalScrollContentConstraint(this UIScrollView scroll, UIView content)
		{
			scroll.WithConstraint(scroll, Left, Equal, content, Left, 1f, 0f, $"{nameof(HorizontalScrollContentConstraint)}-Left")
				.WithConstraint(scroll, Right, Equal, content, Right, 1f, 0f, $"{nameof(HorizontalScrollContentConstraint)}-Right")
				.WithConstraint(scroll, Top, Equal, content, Top, 1f, 0f, $"{nameof(HorizontalScrollContentConstraint)}-Top")
				.WithConstraint(scroll, Bottom, Equal, content, Bottom, 1f, 0f, $"{nameof(HorizontalScrollContentConstraint)}-Bottom")
				.WithConstraint(scroll, CenterY, Equal, content, CenterY, 1f, 0f, $"{nameof(HorizontalScrollContentConstraint)}-CenterY");
			return scroll;
		}

		public static UIScrollView HorizontalScrollFilledContentConstraint(this UIScrollView scroll, UIView content, float verticalMargin)
		{
			scroll.WithConstraint(scroll, Left, Equal, content, Left, 1f, 0f, $"{nameof(HorizontalScrollFilledContentConstraint)}-Left")
				.WithConstraint(scroll, Right, Equal, content, Right, 1f, 0f, $"{nameof(HorizontalScrollFilledContentConstraint)}-Right")
				.WithConstraint(scroll, Top, Equal, content, Top, 1f, -verticalMargin / 2f, $"{nameof(HorizontalScrollFilledContentConstraint)}-Top")
				.WithConstraint(scroll, Bottom, Equal, content, Bottom, 1f, verticalMargin / 2f, $"{nameof(HorizontalScrollFilledContentConstraint)}-Bottom")
				.WithConstraint(scroll, Width, LessThanOrEqual, content, Width, 1f, 0f, $"{nameof(HorizontalScrollFilledContentConstraint)}-Width")
				.WithConstraint(scroll, CenterY, Equal, content, CenterY, 1f, 0f, $"{nameof(HorizontalScrollFilledContentConstraint)}-CenterY");
			return scroll;
		}
	}
}