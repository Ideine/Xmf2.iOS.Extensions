using System.Linq;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class SubviewExtensions
	{
		#region WithSubviews

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view) where TParentView : UIView
		{
			parentView.AddSubview(view);
			return parentView;
		}

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view1, UIView view2) where TParentView : UIView
		{
			parentView.AddSubviews(view1, view2);
			return parentView;
		}

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view1, UIView view2, UIView view3) where TParentView : UIView
		{
			parentView.AddSubviews(view1, view2, view3);
			return parentView;
		}

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view1, UIView view2, UIView view3, UIView view4) where TParentView : UIView
		{
			parentView.AddSubviews(view1, view2, view3, view4);
			return parentView;
		}

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view1, UIView view2, UIView view3, UIView view4, UIView view5) where TParentView : UIView
		{
			parentView.AddSubviews(view1, view2, view3, view4, view5);
			return parentView;
		}

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view1, UIView view2, UIView view3, UIView view4, UIView view5, UIView view6) where TParentView : UIView
		{
			parentView.AddSubviews(view1, view2, view3, view4, view5, view6);
			return parentView;
		}

		public static TParentView WithSubviews<TParentView>(this TParentView parentView, UIView view1, UIView view2, UIView view3, UIView view4, UIView view5, UIView view6, params UIView[] views) where TParentView : UIView
		{
			parentView.AddSubviews(view1, view2, view3, view4, view5, view6);
			parentView.AddSubviews(views);
			return parentView;
		}

		#endregion

		#region Ensure Add / Remove

		public static UIView EnsureRemove(this UIView view, params UIView[] subviewsToRemove)
		{
			if (subviewsToRemove != null)
			{
				UIView[] delta = view.Subviews.Intersect(subviewsToRemove).ToArray();
				foreach (UIView subView in delta)
				{
					subView.RemoveFromSuperview();
				}
			}

			return view;
		}

		public static UIView EnsureAdd(this UIView view, params UIView[] subviewsToAdd)
		{
			if (subviewsToAdd != null)
			{
				UIView[] delta = subviewsToAdd.Except(view.Subviews).ToArray();
				view.AddSubviews(delta);
			}

			return view;
		}

		#endregion
	}
}