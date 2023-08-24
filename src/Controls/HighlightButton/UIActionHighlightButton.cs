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

		protected override void Dispose(bool disposing)
		{
			ToHighlightedAnimation = null;
			FromHighlightedAnimation = null;
			base.Dispose(disposing);
		}
	}

	public static class ActionHighlightButtonExtensions
	{
		public static TActionHighlightButton WithFadeFeedbackRedirect<TActionHighlightButton>(this TActionHighlightButton button, float fadeIn, params UIView[] onViews) where TActionHighlightButton : UIActionHighlightButton
		{
			return button.WithFeedBack(_ =>
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

		public static TActionHighlightButton WithFadeFeedbackOnSuperview<TActionHighlightButton>(this TActionHighlightButton button, float fadeIn) where TActionHighlightButton : UIActionHighlightButton
		{
			return button.WithFeedBack(button => button.Superview?.FadeTo(fadeIn), button => button.Superview?.FadeTo(1f));
		}

		public static TActionHighlightButton WitFeedbackOnSuperview<TActionHighlightButton>(this TActionHighlightButton button, UIColor normalBackgroundColor, UIColor highlightBackgroundColor) where TActionHighlightButton : UIActionHighlightButton
		{
			return button.WithFeedBack(button => button.Superview.WithBackgroundColor(normalBackgroundColor), button => button.Superview.WithBackgroundColor(highlightBackgroundColor));
		}

		public static TActionHighlightButton WithFeedbackOnSelf<TActionHighlightButton>(this TActionHighlightButton button, UIColor normalBackgroundColor, UIColor highlightBackgroundColor) where TActionHighlightButton : UIActionHighlightButton
		{
			return button.WithFeedBack(button => button.WithBackgroundColor(highlightBackgroundColor), button => button.WithBackgroundColor(normalBackgroundColor));
		}

		public static TActionHighlightButton WithFeedBack<TActionHighlightButton>(this TActionHighlightButton button, Action<UIActionHighlightButton> toHighlightedAnimation, Action<UIActionHighlightButton> fromHighlightedAnimation) where TActionHighlightButton : UIActionHighlightButton
		{
			button.ToHighlightedAnimation = toHighlightedAnimation;
			button.FromHighlightedAnimation = fromHighlightedAnimation;
			return button;
		}

		public static TActionHighlightButton WithHighlightedAnimationDuration<TActionHighlightButton>(this TActionHighlightButton button, double toHighlightedDuration, double fromHighlightedDuration) where TActionHighlightButton : UIActionHighlightButton
		{
			button.ToHighlightedAnimationDuration = toHighlightedDuration;
			button.FromHighlightedAnimationDuration = fromHighlightedDuration;
			return button;
		}
	}
}