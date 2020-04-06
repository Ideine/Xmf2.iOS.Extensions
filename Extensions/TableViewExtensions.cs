using CoreGraphics;
using UIKit;

namespace Xmf2.iOS.Extensions.Extensions
{
	public static class TableViewExtensions
	{
		public static UITableView CreateTableView(this object _, CGRect? frame = null)
		{
			UITableView tableView = frame.HasValue ? new UITableView(frame.Value) : new UITableView();
			return tableView.WithoutAutomaticEstimatedHeights();
		}

		/// <see cref="!:https://stackoverflow.com/a/46257601/1584823"/>
		public static TTableView WithoutAutomaticEstimatedHeights<TTableView>(this TTableView view) where TTableView : UITableView
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
			{
				if (view.EstimatedRowHeight == UITableView.AutomaticDimension)
				{
					view.EstimatedRowHeight = 0f;
				}

				if (view.EstimatedSectionHeaderHeight == UITableView.AutomaticDimension)
				{
					view.EstimatedSectionHeaderHeight = 0f;
				}

				if (view.EstimatedSectionFooterHeight == UITableView.AutomaticDimension)
				{
					view.EstimatedSectionFooterHeight = 0f;
				}
			}

			return view;
		}

		#region Selected Background for UITableViewCell

		public static TCell WithSelectedBackground<TCell>(this TCell cell, int color) where TCell : UITableViewCell
		{
			return cell.WithBackgroundColor(color.ColorFromHex());
		}

		public static TCell WithSelectedBackground<TCell>(this TCell cell, uint color) where TCell : UITableViewCell
		{
			return cell.WithBackgroundColor(color.ColorFromHex());
		}

		public static TCell WithSelectedBackground<TCell>(this TCell cell, UIColor color) where TCell : UITableViewCell
		{
			cell.SelectedBackgroundView = new UIView().WithBackgroundColor(color);
			return cell;
		}

		#endregion
	}
}