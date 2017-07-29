
using System;
using Xamarin.Forms;

namespace HowYouSay.Effects
{
	public class InputFieldEffect : RoutingEffect
	{
		public Thickness Padding { get; set; }

		float _borderWidth = 0;
		public float BorderWidth
		{
			get
			{
				return _borderWidth;
			}
			set
			{
				_borderWidth = value;
			}
		}

		float _cornerRadius = 0;
		public float CornerRadius
		{
			get
			{
				return _cornerRadius;
			}
			set
			{
				_cornerRadius = value;
			}
		}

		public bool ClearBackground { get; set; }

		public InputFieldEffect() : base("HowYouSay.InputViewEffect")
		{
		}
	}
}

