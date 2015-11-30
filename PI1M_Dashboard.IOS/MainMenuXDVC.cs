using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using JASidePanels;
using System.Diagnostics;

namespace PI1M_Dashboard.IOS
{
	partial class MainMenuXDVC : JASidePanelController
	{

		public MainMenuXDVC (IntPtr handle) : base (handle)
		{
			ShouldDelegateAutorotateToVisiblePanel = false;
			LeftPanel = new MMXDVCSideLeftMenu();
			CenterPanel = new UINavigationController(new MMXDVCTopBar());
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Debug.WriteLine ("[MainMenuXDVC] MainMenu loaded");

		}
	}
}