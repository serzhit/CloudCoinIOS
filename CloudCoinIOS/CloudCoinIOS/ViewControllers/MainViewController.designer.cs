// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CloudCoinIOS
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UIView bankView { get; set; }

		[Outlet]
		UIKit.UIView exportView { get; set; }

		[Outlet]
		UIKit.UIView importView { get; set; }

		[Outlet]
		UIKit.UIView mainView { get; set; }

		[Action ("OnImportTouched:")]
		partial void OnImportTouched (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (bankView != null) {
				bankView.Dispose ();
				bankView = null;
			}

			if (exportView != null) {
				exportView.Dispose ();
				exportView = null;
			}

			if (importView != null) {
				importView.Dispose ();
				importView = null;
			}
		}
	}
}
