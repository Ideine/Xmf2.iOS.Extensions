using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class ScrollViewExtensions
	{
		#region Creator

		public static UIScrollView CreateVerticalScroll(this object _) => new UIScrollView
		{
			AlwaysBounceHorizontal = false,
			AlwaysBounceVertical = true,
			Bounces = true,
			BouncesZoom = false,
			ShowsVerticalScrollIndicator = true,
			ShowsHorizontalScrollIndicator = false
		}.WithContentInsetAdjustmentBehavior(UIScrollViewContentInsetAdjustmentBehavior.Automatic);

		public static UIScrollView CreateHorizontalScroll(this object _) => new UIScrollView
		{
			AlwaysBounceHorizontal = false,
			AlwaysBounceVertical = false,
			Bounces = false,
			BouncesZoom = false,
			ShowsVerticalScrollIndicator = false,
			ShowsHorizontalScrollIndicator = true
		}.WithContentInsetAdjustmentBehavior(UIScrollViewContentInsetAdjustmentBehavior.Automatic);

		#endregion

		#region ContentInset

		public static TScrollView WithContentInset<TScrollView>(this TScrollView view, UIEdgeInsets inset) where TScrollView : UIScrollView
		{
			view.ContentInset = inset;
			return view;
		}

		public static TScrollView WithContentInset<TScrollView>(this TScrollView view, float top = 0, float left = 0, float bottom = 0, float right = 0) where TScrollView : UIScrollView
		{
			return view.WithContentInset(new UIEdgeInsets(top, left, bottom, right));
		}

		#endregion

		#region Disable/Enable Scroll

		public static UIScrollView DisableScroll(this UIScrollView view)
		{
			view.ScrollEnabled = false;
			return view;
		}

		public static UIScrollView EnableScroll(this UIScrollView view)
		{
			view.ScrollEnabled = true;
			return view;
		}

		#endregion

		public static TScrollView WithContentInsetAdjustmentBehavior<TScrollView>(this TScrollView view, UIScrollViewContentInsetAdjustmentBehavior behavior) where TScrollView : UIScrollView
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
			{
				view.ContentInsetAdjustmentBehavior = behavior;
			}

			return view;
		}
	}
}