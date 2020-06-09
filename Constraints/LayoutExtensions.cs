using System;
using System.Runtime.CompilerServices;
using UIKit;

namespace Xmf2.iOS.Extensions.Constraints
{
	public static class LayoutExtensions
	{
		#region Flow

		public static UIView VerticalFlow(this UIView containerView, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			if (views.Length == 0)
			{
				throw new ArgumentException("views must contains at least one element", nameof(views));
			}

			containerView.AnchorTop(views[0]);
			containerView.AnchorBottom(views[views.Length - 1]);

			for (int i = 1 ; i < views.Length ; ++i)
			{
				containerView.VerticalSpace(views[i - 1], views[i]);
			}

			return containerView;
		}

		#endregion

		#region IncluseFromX

		public static UIView IncloseFromBottom(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.IncloseFromBottom(containerView, view, margin);
		}

		public static UIView IncloseFromBottom(this UIView constrainedView, UIView inclosingView, UIView view, float margin = 0f)
		{
			return constrainedView.WithConstraint(inclosingView, NSLayoutAttribute.Bottom, NSLayoutRelation.GreaterThanOrEqual, view, NSLayoutAttribute.Bottom, 1f, margin);
		}

		public static UIView IncloseFromTop(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.IncloseFromTop(containerView, view, margin);
		}

		public static UIView IncloseFromTop(this UIView constrainedView, UIView inclosingView, UIView view, float margin = 0f)
		{
			return constrainedView.WithConstraint(inclosingView, NSLayoutAttribute.Top, NSLayoutRelation.LessThanOrEqual, view, NSLayoutAttribute.Top, 1f, -margin);
		}

		public static UIView IncloseFromRight(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.IncloseFromRight(containerView, view, margin);
		}

		public static UIView IncloseFromRight(this UIView constrainedView, UIView inclosingView, UIView view, float margin = 0f)
		{
			return constrainedView.WithConstraint(inclosingView, NSLayoutAttribute.Right, NSLayoutRelation.GreaterThanOrEqual, view, NSLayoutAttribute.Right, 1f, margin);
		}

		public static UIView IncloseFromLeft(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.IncloseFromLeft(containerView, view, margin);
		}

		public static UIView IncloseFromLeft(this UIView containerView, UIView inclosingView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(inclosingView, NSLayoutAttribute.Left, NSLayoutRelation.LessThanOrEqual, view, NSLayoutAttribute.Left, 1f, -margin);
		}

		#endregion

		#region AnchorX

		public static UIView AnchorTop(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(view, NSLayoutAttribute.Top, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.Top, 1f, margin);
		}

		public static UIView AnchorBottom(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(containerView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, view, NSLayoutAttribute.Bottom, 1f, margin);
		}

		public static UIView AnchorRight(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(containerView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, view, NSLayoutAttribute.Right, 1f, margin);
		}

		public static UIView AnchorLeft(this UIView containerView, UIView view, float margin = 0f)
		{
			return containerView.WithConstraint(view, NSLayoutAttribute.Left, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.Left, 1, margin);
		}

		#endregion

		#region Center

		public static UIView CenterHorizontally(this UIView containerView, UIView view, float offset = 0f)
		{
			return containerView.WithConstraint(containerView, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, view, NSLayoutAttribute.CenterX, 1f, offset);
		}

		public static UIView CenterHorizontally(this UIView containerView, params UIView[] views) => containerView.CenterHorizontally(0f, views);

		public static UIView CenterHorizontally(this UIView containerView, float offset, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			foreach (UIView view in views)
			{
				containerView.WithConstraint(view, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterX, 1f, offset);
			}

			return containerView;
		}

		public static UIView CenterVertically(this UIView containerView, UIView view, float offset = 0f)
		{
			containerView.WithConstraint(view, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterY, 1f, offset);
			return containerView;
		}

		public static UIView CenterVertically(this UIView containerView, params UIView[] views) => containerView.CenterVertically(0f, views);

		public static UIView CenterVertically(this UIView containerView, float offset, params UIView[] views)
		{
			if (views == null)
			{
				throw new ArgumentNullException(nameof(views));
			}

			foreach (UIView view in views)
			{
				containerView.WithConstraint(view, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, containerView, NSLayoutAttribute.CenterY, 1f, offset);
			}

			return containerView;
		}

		#endregion

		#region Space

		public static UIView VerticalSpace(this UIView containerView, UIView topView, UIView bottomView, float margin = 0)
		{
			return containerView.WithConstraint(topView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, bottomView, NSLayoutAttribute.Top, 1f, -margin);
		}

		public static UIView MinVerticalSpace(this UIView containerView, UIView top, UIView bottom, float margin = 0)
		{
			return containerView.WithConstraint(bottom, NSLayoutAttribute.Top, NSLayoutRelation.GreaterThanOrEqual, top, NSLayoutAttribute.Bottom, 1f, margin);
		}

		public static UIView HorizontalSpace(this UIView containerView, UIView leftView, UIView rightView, float margin = 0)
		{
			return containerView.WithConstraint(rightView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, leftView, NSLayoutAttribute.Right, 1f, margin);
		}

		public static UIView MinHorizontalSpace(this UIView containerView, UIView left, UIView right, float margin = 0f)
		{
			return containerView.WithConstraint(right, NSLayoutAttribute.Left, NSLayoutRelation.GreaterThanOrEqual, left, NSLayoutAttribute.Right, 1f, margin);
		}

		#endregion

		#region Align

		public static UIView AlignOnLeft(this UIView view, UIView v1, UIView v2, float offset = 0)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.Left, v2, offset);
		}

		public static UIView AlignOnRight(this UIView view, UIView v1, UIView v2, int offset = 0)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.Right, v2, offset);
		}

		public static UIView AlignOnTop(this UIView view, UIView v1, UIView v2, float offset = 0f)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.Top, v2, offset);
		}

		public static UIView AlignOnBottom(this UIView view, UIView v1, UIView v2, float offset = 0)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.Bottom, v2, offset);
		}

		/// <summary>
		/// Align on horizontal center
		/// </summary>
		public static UIView AlignOnCenterX(this UIView view, UIView v1, float offset = 0)
		{
			return view.AlignOnX(view, NSLayoutAttribute.CenterX, v1, offset);
		}

		/// <summary>
		/// Align on horizontal center
		/// </summary>
		public static UIView AlignOnCenterX(this UIView view, UIView v1, UIView v2, float offset = 0)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.CenterX, v2, offset);
		}

		/// <summary>
		/// Align on vertical center
		/// </summary>
		public static UIView AlignOnCenterY(this UIView view, UIView v1, float offset = 0)
		{
			return view.AlignOnX(view, NSLayoutAttribute.CenterY, v1, offset);
		}

		/// <summary>
		/// Align on vertical center
		/// </summary>
		public static UIView AlignOnCenterY(this UIView view, UIView v1, UIView v2, float offset = 0)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.CenterY, v2, offset);
		}

		public static UIView AlignOnBaseLine(this UIView view, UIView v1, UIView v2, float offset = 0)
		{
			return view.AlignOnX(v1, NSLayoutAttribute.Baseline, v2, offset);
		}

		private static UIView AlignOnX(this UIView view, UIView v1, NSLayoutAttribute attribute, UIView v2, float offset, [CallerMemberName] string identifier = "")
		{
			return view.WithConstraint(v1, attribute, NSLayoutRelation.Equal, v2, attribute, 1f, offset, identifier);
		}

		#endregion

		#region Same

		public static UIView Same(this UIView view, UIView childView)
		{
			return view.Same(view, childView);
		}

		public static UIView Same(this UIView view, UIView reference, UIView dest)
		{
			return view.WithConstraint(reference, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, dest, NSLayoutAttribute.CenterY, 1f, 0f, $"{nameof(Same)}-CenterY")
				.WithConstraint(reference, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, dest, NSLayoutAttribute.CenterX, 1f, 0f, $"{nameof(Same)}-CenterX")
				.WithConstraint(reference, NSLayoutAttribute.Height, NSLayoutRelation.Equal, dest, NSLayoutAttribute.Height, 1f, 0f, $"{nameof(Same)}-Height")
				.WithConstraint(reference, NSLayoutAttribute.Width, NSLayoutRelation.Equal, dest, NSLayoutAttribute.Width, 1f, 0f, $"{nameof(Same)}-Width");
		}

		#endregion
	}
}