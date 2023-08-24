using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class DatePickerExtensions
	{
		public static UIDatePicker CreateDatePicker(this object _) => new();

		public static UIDatePicker WithMode(this UIDatePicker view, UIDatePickerMode pickerMode)
		{
			view.Mode = pickerMode;
			return view;
		}
	}
}