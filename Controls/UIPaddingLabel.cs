using CoreGraphics;
using UIKit;

namespace Xmf2.iOS.Extensions.Controls
{
	public class UIPaddingLabel : UILabel
	{
		private UIEdgeInsets _contentInset;

		public UIEdgeInsets ContentInset
		{
			get => _contentInset;
			set
			{
				_contentInset = value;
				LayoutIfNeeded();
			}
		}

		public override void DrawText(CGRect rect)
		{
			base.DrawText(ContentInset.InsetRect(rect));
		}

		public override CGSize IntrinsicContentSize
		{
			get
			{
				CGSize size = base.IntrinsicContentSize;
				size.Width += ContentInset.Left + ContentInset.Right;
				size.Height += ContentInset.Bottom + ContentInset.Top;
				return size;
			}
		}

		#region Fluent Method

		public UIPaddingLabel WithPadding(float padding) => WithPadding(padding, padding, padding, padding);

		public UIPaddingLabel WithPadding(float top, float left, float bottom, float right) => WithPadding(new UIEdgeInsets(top, left, bottom, right));

		public UIPaddingLabel WithPadding(UIEdgeInsets padding)
		{
			ContentInset = padding;
			return this;
		}

		#endregion
	}
}