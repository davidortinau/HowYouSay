
using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using HowYouSay.iOS.Effects;
using HowYouSay.Effects;
using System.Linq;
using System.Diagnostics;
using CoreGraphics;

//[assembly: ResolutionGroupName("HowYouSay")]
[assembly:ExportEffect (typeof(HowYouSay.iOS.Effects.RemoveNavBarBorderEffect), "RemoveNavBarBorderEffect")]
namespace HowYouSay.iOS.Effects
{
    public class RemoveNavBarBorderEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
                //var effect = (RemoveNavBarBorderEffect)Element.Effects.FirstOrDefault(e => e is RemoveNavBarBorderEffect);
                if(Control == null)
                    return;
                (Control as UINavigationBar).SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
				(Control as UINavigationBar).ShadowImage = new UIImage();



			}
			catch (Exception ex)
			{
				Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{

		}
	}
}

