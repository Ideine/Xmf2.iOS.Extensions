using System;
using CoreGraphics;
using UIKit;

namespace Xmf2.iOS.Extensions.Controls
{
	/// <summary>
	/// UICollectionView with dynamic size
	/// </summary>
	public class DynamicCollectionView : UICollectionView
	{
		protected internal DynamicCollectionView(IntPtr handle) : base(handle) { }

		public DynamicCollectionView(CGRect frame, UICollectionViewLayout layout) : base(frame, layout) { }

		public override CGSize IntrinsicContentSize => ContentSize;

		public override void LayoutSubviews()
		{
			if (Bounds.Size != IntrinsicContentSize)
			{
				InvalidateIntrinsicContentSize();
			}

			base.LayoutSubviews();

			//maybe there is a crash in iPhone X, if you find solution, please fill a PR !
		}
	}
}