using System.Collections.Generic;
using UIKit;
using Xmf2.iOS.Extensions.Extensions;

namespace Xmf2.iOS.Extensions.Controls.StatusButton
{
	public class UIStatusButton : UIButton
	{
		private readonly Dictionary<ButtonStatus, UIColor> _backgroundColorList = new Dictionary<ButtonStatus, UIColor>();

		public override bool Highlighted
		{
			get => base.Highlighted;
			set
			{
				if (Highlighted != value)
				{
					base.Highlighted = value;
					StateUpdate();
				}
			}
		}

		public override bool Selected
		{
			get => base.Selected;
			set
			{
				if (Selected != value)
				{
					base.Selected = value;
					StateUpdate();
				}
			}
		}

		public override bool Enabled
		{
			get => base.Enabled;
			set
			{
				if (Enabled != value)
				{
					base.Enabled = value;
					StateUpdate();
				}
			}
		}

		protected void StateUpdate()
		{
			ButtonStatus state = ButtonStatus.Normal;

			if (Highlighted)
			{
				state = Selected ? ButtonStatus.HighlightedAndSelected : ButtonStatus.Highlighted;
			}
			else if (!Enabled)
			{
				state = Selected ? ButtonStatus.DisabledAndSelected : ButtonStatus.Disabled;
			}
			else if (Selected)
			{
				state = ButtonStatus.Selected;
			}

			OnStateUpdate(state);
		}

		protected virtual void OnStateUpdate(ButtonStatus state)
		{
			if (_backgroundColorList.TryGetValue(state, out var backgroundColor))
			{
				Animate(0.15, () => BackgroundColor = backgroundColor);
			}
		}

		public UIStatusButton WithBackgroundColor(uint color, ButtonStatus state) => WithBackgroundColor(color.ColorFromHex(), state);
		public UIStatusButton WithBackgroundColor(int color, ButtonStatus state) => WithBackgroundColor(color.ColorFromHex(), state);

		public UIStatusButton WithBackgroundColor(UIColor color, ButtonStatus state)
		{
			_backgroundColorList[state] = color;

			StateUpdate();
			return this;
		}

		public UIStatusButton WithTextColor(uint color, ButtonStatus state) => WithTextColor(color.ColorFromHex(), state);
		public UIStatusButton WithTextColor(int color, ButtonStatus state) => WithTextColor(color.ColorFromHex(), state);

		public UIStatusButton WithTextColor(UIColor color, ButtonStatus state)
		{
			SetTitleColor(color, state.ToUiControlState());
			return this;
		}
	}
}