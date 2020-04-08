using UIKit;

namespace Xmf2.iOS.Extensions.Controls.HighlightButton
{
	public abstract class UIBaseHighlightButton : UIButton
	{
		public override bool Highlighted
		{
			get => base.Highlighted;
			set
			{
				if (Highlighted != value)
				{
					base.Highlighted = value;
					if (value)
					{
						OnHighlighted();
					}
					else
					{
						OnUnhighlighted();
					}
				}
			}
		}

		protected abstract void OnHighlighted();
		protected abstract void OnUnhighlighted();
	}
}