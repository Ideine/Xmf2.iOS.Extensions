using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class ImageViewExtensions
	{
		public static UIImageView CreateImageView(this object _) => new UIImageView();

		public static UIImageView CreateImageView(this object _, string imageName) => new UIImageView().WithImage(imageName);

		public static UIImageView WithImage(this UIImageView view, UIImage image)
		{
			view.Image = image;
			return view;
		}

		public static UIImageView WithImage(this UIImageView view, string imageName)
		{
			view.Image = new UIImage(imageName);
			return view;
		}

		public static UIImageView WithoutImage(this UIImageView view)
		{
			return view.WithImage((UIImage) null);
		}

		public static UIImageView UniformToFit(this UIImageView view)
		{
			view.ContentMode = UIViewContentMode.ScaleAspectFit;
			return view;
		}

		public static UIImageView UniformToFill(this UIImageView view)
		{
			view.ContentMode = UIViewContentMode.ScaleAspectFill;
			return view;
		}
	}
}