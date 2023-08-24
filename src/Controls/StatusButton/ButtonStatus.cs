using UIKit;

namespace Xmf2.iOS.Extensions.Controls.StatusButton
{
	/// <summary>
	/// Use in <see cref="UIStatusButton"/>
	/// </summary>
	public enum ButtonStatus
	{
		Normal,
		Disabled,
		Selected,
		Highlighted,
		DisabledAndSelected,
		HighlightedAndSelected,
	}

	public static class ButtonStateExtensions
	{
		public static UIControlState ToUiControlState(this ButtonStatus state) => state switch
		{
			ButtonStatus.Disabled => UIControlState.Disabled,
			ButtonStatus.Selected => UIControlState.Selected,
			ButtonStatus.Highlighted => UIControlState.Highlighted,
			ButtonStatus.DisabledAndSelected => (UIControlState.Disabled | UIControlState.Selected),
			ButtonStatus.HighlightedAndSelected => (UIControlState.Highlighted | UIControlState.Selected),
			_ => UIControlState.Normal
		};
	}
}