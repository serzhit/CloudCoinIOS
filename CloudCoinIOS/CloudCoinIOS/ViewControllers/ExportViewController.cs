// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using CloudCoin_SafeScan;
using Foundation;
using UIKit;

namespace CloudCoinIOS
{
	public partial class ExportViewController : BaseFormSheet
	{
		private UIColor borderColor = UIColor.FromRGB(122, 134, 148);
		private nint desiredSum;
		Safe safe;
		CoinStack exportCoins;

		public ExportViewController(IntPtr handle) : base(handle)
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
			SetBorderColor(pickerOne);
			SetBorderColor(pickerFive);
			SetBorderColor(picker25);
			SetBorderColor(picker100);
			SetBorderColor(picker250);

			try
			{
				safe = Safe.Instance;
			}
			catch (Exception ex)
			{
				safe = null;
				Console.WriteLine(ex.Message);
			}

			pickerOne.Model = new CoinPickerViewModel(this, safe.Ones.GoodQuantity);
			pickerFive.Model = new CoinPickerViewModel(this, safe.Fives.GoodQuantity);
			picker25.Model = new CoinPickerViewModel(this, safe.Quarters.GoodQuantity);
			picker100.Model = new CoinPickerViewModel(this, safe.Hundreds.GoodQuantity);
			picker250.Model = new CoinPickerViewModel(this, safe.KiloQuarters.GoodQuantity);

			lblOne.Text = "of " + safe.Ones.GoodQuantity.ToString();
			lblFive.Text = "of " + safe.Fives.GoodQuantity.ToString();
			lbl25.Text = "of " + safe.Quarters.GoodQuantity.ToString();
			lbl100.Text = "of " + safe.Hundreds.GoodQuantity.ToString();
			lbl250.Text = "of " + safe.KiloQuarters.GoodQuantity.ToString();

			lblSumInSafe.Text = Safe.Instance.Contents.SumInStack.ToString();
			desiredSum = 0;
			PickerSelectedHandler();
		}

		public void PickerSelectedHandler()
		{
			desiredSum = pickerOne.SelectedRowInComponent(0)
					  + pickerFive.SelectedRowInComponent(0) * 5
					  + picker25.SelectedRowInComponent(0) * 25
					  + picker100.SelectedRowInComponent(0) * 100
					  + picker250.SelectedRowInComponent(0) * 250;

			btnExport.SetTitle("Export " + desiredSum.ToString(), UIControlState.Normal);
		}

		private void SetBorderColor(UIView view)
		{
			view.Layer.MasksToBounds = true;
			view.Layer.BorderColor = borderColor.CGColor;
		}

		private void InitializeMethods()
		{
			btnCancel.TouchUpInside += (sender, e) =>
			{
				RemoveAnimate();
			};

			btnExport.TouchUpInside += (sender, e) =>
			{
				bool isJson = segmentFormat.SelectedSegment == 1 ? true : false;
				exportCoins = GetExportCoins();
				var isExported = safe.SaveOutStack(GetExportCoins(), (int)desiredSum, isJson, lblNote.Text);

				if (isExported)
				{
                    var fileDataList = new List<NSObject>();

                    foreach (var path in safe.ExportedPaths)
                    {
                        fileDataList.Add(NSUrl.FromFilename(path));
                    }

                    var activityViewController = new UIActivityViewController(fileDataList.ToArray(), null);

					if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					{
						activityViewController.PopoverPresentationController.SourceView = this.View;
					}

					activityViewController.CompletionHandler += SetCompletionHandler;

					PresentViewController(activityViewController, true, null);
				}
				else
				{
					ShowAlert("Export", "Nothing to export!\n", new string[] {"Ok"});
				}
			};
		}

		private void SetCompletionHandler(NSString act, bool success)
		{
			if (success)
			{
				safe.Contents.Remove(exportCoins);
				safe.onSafeContentChanged(new EventArgs());
				safe.Save();

				RemoveAnimate();

				Console.WriteLine("success");
			}
			else
			{
				Console.WriteLine("cancel");
			}
		}

		private CoinStack GetExportCoins()
		{
			var coinStack = new CoinStack();
			coinStack.Add(safe.Contents.CoinOnes, (int)pickerOne.SelectedRowInComponent(0));
			coinStack.Add(safe.Contents.CoinFives, (int)pickerFive.SelectedRowInComponent(0));
			coinStack.Add(safe.Contents.CoinQuarters, (int)picker25.SelectedRowInComponent(0));
			coinStack.Add(safe.Contents.CoinHundreds, (int)picker100.SelectedRowInComponent(0));
			coinStack.Add(safe.Contents.CoinKiloQuarters, (int)picker250.SelectedRowInComponent(0));
			return coinStack;
		}
	}

	public class CoinPickerViewModel : UIPickerViewModel
	{
		private int count;
		private ExportViewController exportViewController;

		public CoinPickerViewModel(ExportViewController exportViewController, int count)
		{
			this.count = count;
			this.exportViewController = exportViewController;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return count + 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return row.ToString();
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			exportViewController.PickerSelectedHandler();
		}
	}
}
