using System.Linq;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class GestureExtensions
	{
		public static UIView EnsureAdd(this UIView view, params UIGestureRecognizer[] gestureRecognizersToAdd)
		{
			if (gestureRecognizersToAdd != null)
			{
				var delta = gestureRecognizersToAdd.Except(view.GestureRecognizers ?? new UIGestureRecognizer[] { }).ToArray();

				foreach (var recognizer in delta)
				{
					view.AddGestureRecognizer(recognizer);
				}
			}

			return view;
		}

		public static UIView EnsureRemove(this UIView view, params UIGestureRecognizer[] gestureRecognizersToRemove)
		{
			if (gestureRecognizersToRemove != null)
			{
				var delta = view.GestureRecognizers?.Intersect(gestureRecognizersToRemove).ToArray() ?? new UIGestureRecognizer[] { };
				foreach (var recognizer in delta)
				{
					view.RemoveGestureRecognizer(recognizer);
				}
			}

			return view;
		}
	}
}