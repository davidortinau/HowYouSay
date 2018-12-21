using System;
using HowYouSay.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(HowShellRenderer))] 
namespace HowYouSay.iOS.Renderers
{
    public class HowShellRenderer : ShellRenderer
    {
        protected override void OnElementSet(Shell element)
        {
            base.OnElementSet(element);
        }

        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            Console.WriteLine(("Create Section"));
            var renderer = base.CreateShellSectionRenderer(shellSection);
            if (renderer != null)
            {
                (renderer as ShellSectionRenderer).NavigationBar.SetBackgroundImage(new UIImage(),
                    UIBarMetrics.Default);
                (renderer as ShellSectionRenderer).NavigationBar.ShadowImage = new UIImage();

                UINavigationBar.Appearance.BarTintColor = Color.FromHex("#11313F").ToUIColor(); //bar background
                UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
                UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
                {
                    Font = UIFont.FromName("HelveticaNeue-Light", (nfloat) 20f),
                    TextColor = UIColor.White
                });
            }

            return (IShellSectionRenderer)renderer;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            Console.WriteLine("Flyout!!!!");
            return base.CreateShellFlyoutContentRenderer();
        }
    }
}