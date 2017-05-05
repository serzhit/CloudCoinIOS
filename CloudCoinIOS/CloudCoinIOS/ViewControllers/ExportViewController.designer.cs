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
	[Register ("ExportViewController")]
	partial class ExportViewController
	{
		[Outlet]
		UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		UIKit.UIPickerView picker100 { get; set; }

		[Outlet]
		UIKit.UIPickerView picker25 { get; set; }

		[Outlet]
		UIKit.UIPickerView picker250 { get; set; }

		[Outlet]
		UIKit.UIPickerView pickerFive { get; set; }

		[Outlet]
		UIKit.UIPickerView pickerOne { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (pickerOne != null) {
				pickerOne.Dispose ();
				pickerOne = null;
			}

			if (pickerFive != null) {
				pickerFive.Dispose ();
				pickerFive = null;
			}

			if (picker25 != null) {
				picker25.Dispose ();
				picker25 = null;
			}

			if (picker100 != null) {
				picker100.Dispose ();
				picker100 = null;
			}

			if (picker250 != null) {
				picker250.Dispose ();
				picker250 = null;
			}
		}
	}
}
