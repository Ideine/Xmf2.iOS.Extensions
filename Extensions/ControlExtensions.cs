using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class ControlExtensions
	{
		public static TControl WithAlignment<TControl>(this TControl control, UIControlContentHorizontalAlignment horizontalAlignment) where TControl : UIControl
		{
			control.HorizontalAlignment = horizontalAlignment;
			return control;
		}
	}
}