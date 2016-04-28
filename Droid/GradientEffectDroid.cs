using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using eXam;
using Android.Graphics;
using Android.Graphics.Drawables;

[assembly: ResolutionGroupName ("Xamarin")]
[assembly: ExportEffect (typeof (GradientEffectDroid), "GradientEffect")]

namespace eXam
{
	public class GradientEffectDroid : PlatformEffect
	{
		Drawable originalDrawable;

		protected override void OnAttached()
		{
			var view = Element as View;

			if (view == null)
				return;

			var color1 = new Android.Graphics.Color (0, 0, 40);
			var color2 = view.BackgroundColor.ToAndroid ();

			originalDrawable = Control.Background;

			var gradDrawable = new GradientDrawable (GradientDrawable.Orientation.BottomTop, new int[]{color1, color2});

			Control.SetBackground (gradDrawable);
		}

		protected override void OnDetached()
		{
			if (originalDrawable != null)
				Control.SetBackground (originalDrawable);
		}
	}
}