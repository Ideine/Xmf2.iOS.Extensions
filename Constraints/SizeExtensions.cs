using System;
using UIKit;

namespace Xmf2.iOS.Extensions.Constraints
{
	public static class SizeExtensions
	{
		#region CenterAndLimitX

		public static UIView CenterAndLimitWidth(this UIView containerView, UIView view, float margin = 0)
		{
			return containerView.WithConstraint(view, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterX, 1f, 0f, $"{nameof(CenterAndLimitWidth)}-CenterX")
				.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.LessThanOrEqual, containerView, NSLayoutAttribute.Width, 1f, -margin, $"{nameof(CenterAndLimitWidth)}-Width");
		}

		public static UIView CenterAndLimitWidth(this UIView containerView, params UIView[] views)
		{
			return containerView.CenterAndLimitWidth(0f, views);
		}

		public static UIView CenterAndLimitWidth(this UIView containerView, float margin, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			foreach (var view in views)
			{
				containerView.CenterAndLimitWidth(view, margin);
			}

			return containerView;
		}

		public static UIView CenterAndLimitHeight(this UIView containerView, UIView view, float margin = 0)
		{
			return containerView.WithConstraint(view, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterY, 1f, 0f, $"{nameof(CenterAndLimitHeight)}-CenterY")
				.WithConstraint(view, NSLayoutAttribute.Height, NSLayoutRelation.LessThanOrEqual, containerView, NSLayoutAttribute.Height, 1f, -margin, $"{nameof(CenterAndLimitHeight)}-Height");
		}

		public static UIView CenterAndLimitHeight(this UIView containerView, params UIView[] views)
		{
			return containerView.CenterAndLimitHeight(0f, views);
		}

		public static UIView CenterAndLimitHeight(this UIView containerView, float margin = 0f, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			foreach (var view in views)
			{
				containerView.CenterAndLimitHeight(view, margin);
			}

			return containerView;
		}

		#endregion

		#region CenterAndFillX

		public static UIView CenterAndFillWidth(this UIView containerView, params UIView[] views)
		{
			return containerView.CenterAndFillWidth(0f, views);
		}

		public static UIView CenterAndFillWidth(this UIView containerView, float margin, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			foreach (var view in views)
			{
				containerView.CenterAndFillWidth(view, margin);
			}

			return containerView;
		}

		public static UIView CenterAndFillWidth(this UIView containerView, UIView view, float margin = 0)
		{
			return containerView.WithConstraint(view, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterX, 1f, 0f, $"{nameof(CenterAndFillWidth)}-CenterX")
				.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.Width, 1f, -margin, $"{nameof(CenterAndFillWidth)}-Width");
		}

		public static UIView CenterAndFillHeight(this UIView containerView, params UIView[] views)
		{
			return containerView.CenterAndFillHeight(0f, views);
		}

		public static UIView CenterAndFillHeight(this UIView containerView, float margin, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			foreach (var view in views)
			{
				containerView.CenterAndFillHeight(view, margin);
			}

			return containerView;
		}

		public static UIView CenterAndFillHeight(this UIView containerView, UIView view, float margin = 0f)
		{
			containerView.WithConstraint(view, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterY, 1f, 0f, $"{nameof(CenterAndFillHeight)}-CenterY")
				.WithConstraint(containerView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, view, NSLayoutAttribute.Height, 1f, margin, $"{nameof(CenterAndFillHeight)}-Height");
			return containerView;
		}

		#endregion

		#region ConstrainSize

		public static UIView ConstrainSize(this UIView view, float width, float height)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.Equal, 1f, width, $"{nameof(ConstrainSize)}-Width")
				.WithConstraint(view, NSLayoutAttribute.Height, NSLayoutRelation.Equal, 1f, height, $"{nameof(ConstrainSize)}-Height");
		}

		public static UIView ConstrainHeight(this UIView view, float height)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Height, NSLayoutRelation.Equal, 1, height);
		}

		public static UIView ConstrainWidth(this UIView view, float width)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.Equal, 1, width);
		}

		public static UIView ConstrainMinHeight(this UIView view, float height)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, 1f, height);
		}

		public static UIView ConstrainMinWidth(this UIView view, float width)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.GreaterThanOrEqual, 1f, width);
		}

		public static UIView ConstrainMaxHeight(this UIView view, int height)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Height, NSLayoutRelation.LessThanOrEqual, 1f, height);
		}

		public static UIView ConstrainMaxWidth(this UIView view, float width)
		{
			return view.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.LessThanOrEqual, 1f, width);
		}

		#endregion

		#region FillX

		public static UIView FillWidth(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(containerView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, view, NSLayoutAttribute.Width, 1, margin, nameof(FillWidth));
		}

		public static UIView FillHeight(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(containerView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, view, NSLayoutAttribute.Height, 1f, margin, nameof(FillHeight));
		}

		#endregion

		#region SameX

		public static UIView SameWidth(this UIView view, UIView v1, float margin = 0f)
		{
			return view.SameWidth(view, v1, margin);
		}

		public static UIView SameWidth(this UIView view, UIView v1, UIView v2, float margin = 0f)
		{
			return view.WithConstraint(v1, NSLayoutAttribute.Width, NSLayoutRelation.Equal, v2, NSLayoutAttribute.Width, 1f, margin);
		}

		public static UIView SameHeight(this UIView view, UIView v1, float margin = 0f)
		{
			return view.SameHeight(view, v1, margin);
		}

		public static UIView SameHeight(this UIView view, UIView v1, UIView v2, float margin = 0f)
		{
			return view.WithConstraint(v1, NSLayoutAttribute.Height, NSLayoutRelation.Equal, v2, NSLayoutAttribute.Height, 1f, margin);
		}

		#endregion

		#region Ratio

		public static UIView WithRatio(this UIView view, float referenceWidth, float referenceHeight)
		{
			return view.WithRatio(view, referenceWidth, referenceHeight);
		}

		public static UIView WithRatio(this UIView constrainedView, UIView view, float referenceWidth, float referenceHeight)
		{
			return constrainedView.WithRatio(view, referenceWidth / referenceHeight);
		}

		public static UIView WithRatio(this UIView view, float widthOnHeightRatio)
		{
			return view.WithRatio(view, widthOnHeightRatio);
		}

		public static UIView WithRatio(this UIView constrainedView, UIView view, float widthOnHeightRatio)
		{
			return constrainedView.WithConstraint(view, NSLayoutAttribute.Width, NSLayoutRelation.Equal, view, NSLayoutAttribute.Height, widthOnHeightRatio, 0f);
		}

		#endregion
	}
}