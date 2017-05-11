// This file has been autogenerated from a class added in the UI designer.

using System;
using System.IO;
using System.Text;
using CloudCoin_SafeScan;
using CryptSharp;
using Foundation;
using PassKit;
using UIKit;

namespace CloudCoinIOS
{
	public partial class MainViewController : UIViewController
	{
		public enum ViewType
		{
			Imported,
			Banked,
			Exported
		}

		private ViewType subViewType;
		private CloudCoinFile coinFile;
		private AppDelegate appDelegate;

		public MainViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			//var paths = new NSSearchPath()
		}

		public override void ViewDidLayoutSubviews()
		{
			makeRoundRectView(importView);
			makeRoundRectView(bankView);
			makeRoundRectView(exportView);

			base.ViewDidLayoutSubviews();
		}

		private void makeRoundRectView(UIView view)
		{
			view.Layer.CornerRadius = view.Bounds.Height / 2f;
			view.Layer.MasksToBounds = true;
		}

		partial void OnImportTouched(Foundation.NSObject sender)
		{
			var modalImportViewController = (ImportViewController)GetViewController("ImportViewController");
			modalImportViewController.ShowInView(View, true);
			modalImportViewController.CompletedWithPassword += CompletedWithPassword;
		}

		private void CompletedWithPassword(CloudCoinFile ccFile)
		{
			subViewType = ViewType.Imported;
			ShowPasswordViewController(ccFile);
		}

		private void ShowPasswordViewController(CloudCoinFile ccFile)
		{
			var fileInfo = new FileInfo(Safe.GetSafeFilePath());
			NewPassViewController newPassViewController;
			EnterPassViewController enterPassViewController;

			this.coinFile = ccFile;

			if (!fileInfo.Exists)
			{
				newPassViewController = (NewPassViewController)GetViewController("NewPassViewController");
				newPassViewController.ShowInView(View, true);
				newPassViewController.FinishSetPassword += FinishDoPassword;
			}
			else
			{
				enterPassViewController = (EnterPassViewController)GetViewController("EnterPassViewController");
				enterPassViewController.ShowInView(View, true);
				enterPassViewController.FinishEnterPassword += FinishDoPassword;
			}
		}

		private void FinishDoPassword(string password)
		{
			UserInteract.Password = password;
			appDelegate.Password = password;
			if (subViewType == ViewType.Imported)
			{
				Safe.Instance?.Add(coinFile.Coins);
				foreach (var path in appDelegate.UrlList)
				{
					File.Delete(path);
				}

				appDelegate.UrlList.Clear();
			}

			if (Safe.Instance != null)
			{
				if (subViewType == ViewType.Exported)
				{
					ShowExportViewController();
				}
				else
				{
					ShowBankViewController();
				}
			}
		}

		private void ShowExportViewController()
		{
			var modalExportViewController = (ExportViewController)GetViewController("ExportViewController");
			modalExportViewController.ShowInView(View, true);
		}

		private void ShowFixFrackedViewController()
		{
			var fixFrackedViewController = (FixFrackedViewController)GetViewController("FixFrackedViewController");
			fixFrackedViewController.ShowInView(View, true);
		}

		private void ShowBankViewController()
		{
			var modalBankViewController = (BankViewController)GetViewController("BankViewController");
			modalBankViewController.ShowInView(View, true);
			modalBankViewController.FixFrackedTouched += (sender, e) =>
			{
				ShowFixFrackedViewController();
			};
		}

		partial void OnExportTouched(Foundation.NSObject sender)
		{
			subViewType = ViewType.Exported;

			if (appDelegate.Password == "")
			{
				ShowPasswordViewController(null);
			}
			else
			{
				ShowExportViewController();
			}
		}

		partial void OnBankTouched(Foundation.NSObject sender)
		{
			subViewType = ViewType.Banked;

			if (appDelegate.Password == "")
			{
				ShowPasswordViewController(null);
			}
			else
			{
				ShowBankViewController();
			}
		}

		private BaseFormSheet GetViewController(string regId)
		{
			return (BaseFormSheet)Storyboard.InstantiateViewController(regId);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}
	}
}
