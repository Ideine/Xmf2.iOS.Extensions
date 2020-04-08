using System;
using UIKit;
using Xmf2.iOS.Extensions.Extensions;

namespace Xmf2.iOS.Extensions.Controls.HighlightButton
{
	public class UIActionHighlightButton : UIBaseHighlightButton
	{
		public Action<UIActionHighlightButton> ToHighlightedAnimation { get; set; }
		public Action<UIActionHighlightButton> FromHighlightedAnimation { get; set; }

		public double ToHighlightedAnimationDuration { get; set; } = 0.2;
		public double FromHighlightedAnimationDuration { get; set; } = 0.2;

		protected override void OnHighlighted() => Animate(ToHighlightedAnimationDuration, () => ToHighlightedAnimation(this), () => { });
		protected override void OnUnhighlighted() => Animate(FromHighlightedAnimationDuration, () => FromHighlightedAnimation(this), () => { });

		#region Extensions

		public UIActionHighlightButton WithFadeFeedbackRedirect(float fadeIn, params UIView[] onViews)
		{
			return WithFeedBack(_ =>
			{
				foreach (var view in onViews)
				{
					view.FadeTo(fadeIn);
				}
			}, _ =>
			{
				foreach (var view in onViews)
				{
					view.FadeTo(1f);
				}
			});
		}

		public UIActionHighlightButton WithFadeFeedbackOnSuperview(float fadeIn)
		{
			return WithFeedBack(button => button.Superview?.FadeTo(fadeIn), button => button.Superview?.FadeTo(1f));
		}

		public UIActionHighlightButton WitFeedbackOnSuperview(UIColor normalBackgroundColor, UIColor highlightBackgroundColor)
		{
			return WithFeedBack(button => button.Superview.WithBackgroundColor(normalBackgroundColor), button => button.Superview.WithBackgroundColor(highlightBackgroundColor));
		}

		public UIActionHighlightButton WithFeedbackOnSelf(UIColor normalBackgroundColor, UIColor highlightBackgroundColor)
		{
			return WithFeedBack(button => button.WithBackgroundColor(highlightBackgroundColor), button => button.WithBackgroundColor(normalBackgroundColor));
		}

		public UIActionHighlightButton WithFeedBack(Action<UIActionHighlightButton> toHighlightedAnimation, Action<UIActionHighlightButton> fromHighlightedAnimation)
		{
			ToHighlightedAnimation = toHighlightedAnimation;
			FromHighlightedAnimation = fromHighlightedAnimation;
			return this;
		}

		public UIActionHighlightButton WithHighlightedAnimationDuration(double toHighlightedDuration, double fromHighlightedDuration)
		{
			ToHighlightedAnimationDuration = toHighlightedDuration;
			FromHighlightedAnimationDuration = fromHighlightedDuration;
			return this;
		}

		#endregion

		protected override void Dispose(bool disposing)
		{
			ToHighlightedAnimation = null;
			FromHighlightedAnimation = null;
			base.Dispose(disposing);
		}
	}
}