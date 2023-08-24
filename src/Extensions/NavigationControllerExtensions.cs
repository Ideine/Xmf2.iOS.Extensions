using System;
using System.Linq;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class NavigationControllerExtensions
	{
		public static void SetViewController(this UINavigationController uiNavigationController, UIViewController controller, bool animated)
		{
			uiNavigationController.SetViewControllers(new[]
			{
				controller
			}, animated);
		}

		public static bool TryToFindViewControllerInStackOfType<TViewController>(this UINavigationController uiNavigationController, out TViewController viewController) where TViewController : class
		{
			viewController = uiNavigationController?.ViewControllers?.OfType<TViewController>().FirstOrDefault();
			return viewController != null;
		}

		public static TViewController GetOrCreate<TViewController>(this UINavigationController uiNavigationController)
			where TViewController : UIViewController, new()
		{
			return uiNavigationController.GetOrCreate(() => new TViewController());
		}

		public static TViewController GetOrCreate<TViewController>(this UINavigationController uiNavigationController, Func<TViewController> creatorFunc)
			where TViewController : UIViewController
		{
			return uiNavigationController.TryToFindViewControllerInStackOfType<TViewController>(out var viewController) ? viewController : creatorFunc();
		}
	}
}