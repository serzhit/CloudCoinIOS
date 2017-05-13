// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
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
		UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		UIKit.UIButton btnOk { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint textConstraintHeight { get; set; }

		[Outlet]
		UIKit.UITextField txtCfrPassword { get; set; }

		[Outlet]
		UIKit.UITextView txtExplain { get; set; }

		[Outlet]
		UIKit.UITextField txtPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnOk != null) {
				btnOk.Dispose ();
				btnOk = null;
			}

			if (txtCfrPassword != null) {
				txtCfrPassword.Dispose ();
				txtCfrPassword = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}

			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (textConstraintHeight != null) {
				textConstraintHeight.Dispose ();
				textConstraintHeight = null;
			}

			if (txtExplain != null) {
				txtExplain.Dispose ();
				txtExplain = null;
			}
		}
	}
}
