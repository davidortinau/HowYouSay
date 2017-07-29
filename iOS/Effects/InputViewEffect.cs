
using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using HowYouSay.iOS.Effects;
using HowYouSay.Effects;
using System.Linq;
using System.Diagnostics;
using CoreGraphics;

[assembly: ResolutionGroupName("HowYouSay")]
[assembly:ExportEffect (typeof(InputViewEffect), "InputViewEffect")]
namespace HowYouSay.iOS.Effects
{
	public class InputViewEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
                var effect = (InputFieldEffect)Element.Effects.FirstOrDefault(e => e is InputFieldEffect);
				Debug.WriteLine("padding {0}", effect.Padding);

				if (effect.ClearBackground)
				{
					Control.BackgroundColor = UIColor.Clear;
				}

				//                if(effect.CornerRadius == 0){
				//                    var tf = (UITextField)Control;
				//                    tf.BorderStyle = UITextBorderStyle.Line;
				//                }

				// thus stuff doesn't seem to do anything
				Control.Layer.BorderColor = UIColor.White.CGColor;
				Control.Layer.BorderWidth = effect.BorderWidth;
				Control.Layer.CornerRadius = effect.CornerRadius;

				//                // this works
				//
				if (effect.BorderWidth == 0)
				{
					var tf = (UITextField)Control;
					tf.BorderStyle = UITextBorderStyle.None;
				}



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

