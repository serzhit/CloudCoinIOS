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
	[Register ("NewPassViewController")]
	partial class NewPassViewController
	{
		[Outlet]
		UIKit.UIButton btnOk { get; set; }

		[Outlet]
		UIKit.UITextField txtCfrPassword { get; set; }

		[Outlet]
		UIKit.UITextField txtPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnOk != null) {
				btnOk.Dispose ();
				btnOk = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}

			if (txtCfrPassword != null) {
				txtCfrPassword.Dispose ();
				txtCfrPassword = null;
			}
		}
	}
}
