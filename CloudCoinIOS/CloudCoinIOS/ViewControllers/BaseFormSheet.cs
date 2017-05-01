using System;
using UIKit;

namespace CloudCoinIOS
{
	public class BaseFormSheet : UIViewController
	{
		public BaseFormSheet()
		{
		}

		public BaseFormSheet(IntPtr handle) : base (handle)
		{
		}

		public void ShowInView(UIView parentView, bool animated)
		{
			parentView.AddSubview(View);
			if (animated)
			ShowAnimate();
		}

		public void ShowAnimate()
		{
			View.Transform.Scale(1.3f, 1.3f);
			View.Alpha = 0;

			UIView.Animate(0.25f, () =>
			{
				View.Alpha = 1;
				View.Transform.Scale(1, 1);
			}, null);
		}

		public void RemoveAnimate()
		{
			UIView.Animate(0.25f, () =>
			{
				View.Alpha = 0;
				View.Transform.Scale(1.3f, 1.3f);
			}, () =>
			{
				View.RemoveFromSuperview();
			});
				}
			}
}
