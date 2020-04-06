using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UIKit;

namespace Xmf2.iOS.Extensions.Constraints
{
	public static class ConstraintExtensions
	{
		#region Add / Remove Constraints

		public static void RemoveConstraints(this UIView container, params NSLayoutConstraint[] constraints) => container.RemoveConstraints(constraints);

		public static void AddConstraints(this UIView container, params NSLayoutConstraint[] constraints) => container.AddConstraints(constraints);

		#endregion

		#region Enable/Disable

		public static NSLayoutConstraint Enable(this NSLayoutConstraint constraint)
		{
			constraint.Active = true;
			return constraint;
		}

		public static NSLayoutConstraint Disable(this NSLayoutConstraint constraint)
		{
			constraint.Active = false;
			return constraint;
		}

		#endregion

		#region EnsureX

		public static UIView EnsureRemove(this UIView view, IEnumerable<NSLayoutConstraint> constraintsToRemove)
		{
			return EnsureRemove(view, constraintsToRemove?.ToArray());
		}

		public static UIView EnsureRemove(this UIView view, params NSLayoutConstraint[] constraintsToRemove)
		{
			if (constraintsToRemove != null)
			{
				var delta = view.Constraints.Intersect(constraintsToRemove).ToArray();
				view.RemoveConstraints(delta);
			}

			return view;
		}

		public static UIView EnsureAdd(this UIView view, IEnumerable<NSLayoutConstraint> constraintsToAdd)
		{
			return EnsureAdd(view, constraintsToAdd?.ToArray());
		}

		public static UIView EnsureAdd(this UIView view, params NSLayoutConstraint[] constraintsToAdd)
		{
			if (constraintsToAdd != null)
			{
				var delta = constraintsToAdd.Except(view.Constraints).ToArray();
				view.AddConstraints(delta);
			}

			return view;
		}

		#endregion

		#region WithConstraint

		public static UIView WithConstraint(this UIView constrainedView, UIView view, NSLayoutAttribute attribute, NSLayoutRelation relation, nfloat multiplier, nfloat constant, [CallerMemberName] string identifier = "")
		{
			if (view != null && view != constrainedView)
			{
				view.TranslatesAutoresizingMaskIntoConstraints = false;
			}

			var constraint = NSLayoutConstraint.Create(view, attribute, relation, multiplier, constant);

			if (!string.IsNullOrEmpty(identifier))
			{
				constraint.SetIdentifier(identifier);
			}

			constrainedView.AddConstraint(constraint);
			return constrainedView;
		}

		public static UIView WithConstraint(this UIView constrainedView, UIView view1, NSLayoutAttribute attribute1, NSLayoutRelation relation, UIView view2, NSLayoutAttribute attribute2, nfloat multiplier, nfloat constant, [CallerMemberName] string identifier = "")
		{
			if (view1 != null && view1 != constrainedView)
			{
				view1.TranslatesAutoresizingMaskIntoConstraints = false;
			}

			if (view2 != null && view2 != constrainedView)
			{
				view2.TranslatesAutoresizingMaskIntoConstraints = false;
			}

			var constraint = NSLayoutConstraint.Create(view1, attribute1, relation, view2, attribute2, multiplier, constant);

			if (!string.IsNullOrEmpty(identifier))
			{
				constraint.SetIdentifier(identifier);
			}

			constrainedView.AddConstraint(constraint);
			return constrainedView;
		}

		#endregion
	}
}