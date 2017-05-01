// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using CloudCoin_SafeScan;
using Foundation;
using UIKit;

namespace CloudCoinIOS
{
	public partial class ImportViewController : BaseFormSheet
	{
		private List<string> urlList;

		public ImportViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			InitializeProperties();

			InitializeMethods();
		}

		private void InitializeProperties()
		{
			var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			urlList = appDelegate.UrlList;
		}

		private void InitializeMethods()
		{
			btnImport.TouchUpInside += (sender, e) =>
			{
				ApplicationLogic.ScanSelected(urlList);
			};

			btnCancel.TouchUpInside += (sender, e) => 
			{ 
                RemoveAnimate();
			};
		}
	}
}
