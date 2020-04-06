using System;
using UIKit;

namespace Xmf2.iOS.Extensions.Controls
{
	public class VisibilityToggleContainer : UIView
	{
		private UIView _child;
		private NSLayoutConstraint[] _constraints;
		private readonly NSLayoutConstraint _emptyHeightConstraint;
		private readonly NSLayoutConstraint _emptyWidthConstraint;

		public bool Visible
		{
			get => _child.Superview != null;
			set => ShowChildView(value);
		}

		public VisibilityToggleContainer(bool useEmptyHeightConstraint = false, bool useEmptyWidthConstraint = false)
		{
			if (useEmptyHeightConstraint)
			{
				_emptyHeightConstraint = HeightAnchor.ConstraintEqualTo(0);
				AddConstraint(_emptyHeightConstraint);
			}

			if (useEmptyWidthConstraint)
			{
				_emptyWidthConstraint = WidthAnchor.ConstraintEqualTo(0);
				AddConstraint(_emptyWidthConstraint);
			}
		}

		public VisibilityToggleContainer(UIView child, bool useEmptyHeightConstraint = false, bool useEmptyWidthConstraint = false) : this(useEmptyHeightConstraint, useEmptyWidthConstraint)
		{
			SetChild(child);
		}

		/// <summary>
		/// Do it after <see cref="SetChild(UIView)"/>
		/// </summary>
		public void SetPadding(float top, float left, float bottom, float right) => SetPadding(new UIEdgeInsets(top, left, bottom, right));

		/// <summary>
		/// Do it after <see cref="SetChild(UIView)"/>
		/// </summary>
		public void SetPadding(UIEdgeInsets paddings)
		{
			_constraints[0].Constant = -paddings.Top;
			_constraints[1].Constant = paddings.Bottom;
			_constraints[2].Constant = -paddings.Left;
			_constraints[3].Constant = paddings.Right;
		}

		public void SetChild(UIView child)
		{
			if (_child != null)
			{
				throw new InvalidOperationException("Child has already been set");
			}

			_child = child;
			_child.TranslatesAutoresizingMaskIntoConstraints = false;

			_constraints = new[]
			{
				NSLayoutConstraint.Create(this, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _child, NSLayoutAttribute.Top, 1, 0),
				NSLayoutConstraint.Create(this, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, _child, NSLayoutAttribute.Bottom, 1, 0),
				NSLayoutConstraint.Create(this, NSLayoutAttribute.Left, NSLayoutRelation.Equal, child, NSLayoutAttribute.Left, 1, 0),
				NSLayoutConstraint.Create(this, NSLayoutAttribute.Right, NSLayoutRelation.Equal, _child, NSLayoutAttribute.Right, 1, 0),
			};
		}

		private void ShowChildView(bool value)
		{
			if (Visible == value)
			{
				return;
			}

			if (value)
			{
				AddSubview(_child);
				if (_emptyHeightConstraint != null)
				{
					RemoveConstraint(_emptyHeightConstraint);
				}

				if (_emptyWidthConstraint != null)
				{
					RemoveConstraint(_emptyWidthConstraint);
				}

				AddConstraints(_constraints);
			}
			else
			{
				RemoveConstraints(_constraints);
				if (_emptyHeightConstraint != null)
				{
					AddConstraint(_emptyHeightConstraint);
				}

				if (_emptyWidthConstraint != null)
				{
					AddConstraint(_emptyWidthConstraint);
				}

				_child.RemoveFromSuperview();
			}
		}
	}
}