﻿using System;
using UIKit;

namespace PI1M_Dashboard.IOS
{
	public class CustomLibs
	{
		public CustomLibs ()
		{
			
		}

		//Declared IOS Screen Size
		public static nfloat iOSScreenSize = DetectScreenSize();

		private static nfloat DetectScreenSize()
		{
			nfloat widthSize = UIScreen.MainScreen.Bounds.Size.Width;
			nfloat heightSize = UIScreen.MainScreen.Bounds.Size.Height;

			nfloat getMaxLength = NMath.Max (widthSize, heightSize);

			return getMaxLength;
		}

		//Detect IPhone Type (may not precised)
		//Nota: Jika ada sokongan lain seperti IPad atau apa2 Iphone yg berlainan
		//saiz skrin, sila ubah disini.
		public static string iOSDeviceModel = DetectIOSDeviceModel ();

		private static string DetectIOSDeviceModel ()
		{
			if (iOSScreenSize < 568.0f) {
				return "I_PHONE_4_OR_LESS";
			} else if (iOSScreenSize == 568.0f) {
				return "I_PHONE_5";
			} else if (iOSScreenSize == 667.0f) {
				return "I_PHONE_6";
			} else if (iOSScreenSize == 736.0f) {
				return "I_PHONE_6_PLUS";
			} else {
				return "UNKNOWN";
			}

		}

		// Retrieve customized UIColor in CSS HashHex
		public static UIColor ColorFromHexString (string hexValue, float alpha = 1.0f)
		{
			var colorString = hexValue.Replace ("#", "");
			if (alpha > 1.0f) {
				alpha = 1.0f;
			} else if (alpha < 0.0f) {
				alpha = 0.0f;
			}

			float red, green, blue;

			switch (colorString.Length) 
			{
			case 3 : // #RGB
				{
					red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
					green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
					blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
					return UIColor.FromRGBA(red, green, blue, alpha);
				}
			case 6 : // #RRGGBB
				{
					red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
					green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
					blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
					return UIColor.FromRGBA(red, green, blue, alpha);
				}   

			default :
				throw new ArgumentOutOfRangeException(string.Format("Invalid color value {0} is invalid. It should be a hex value of the form #RBG, #RRGGBB", hexValue));

			}
		}

	}
}

