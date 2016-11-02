using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Views;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(ClearEntryEffect.Droid.Effects.ClearEntryEffect), "ClearEntryEffect")]
namespace ClearEntryEffect.Droid.Effects
{
	public class ClearEntryEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			ConfigureControl();
		}

		protected override void OnDetached()
		{
		}

		private void ConfigureControl()
		{			
			EditText editText = ((EditText)Control);
			editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.ic_clear_icon, 0);
			editText.SetOnTouchListener(new OnDrawableTouchListener());
		}
	}

	public class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
	{
		public bool OnTouch(Android.Views.View v, MotionEvent e)
		{
			if (v is EditText && e.Action == MotionEventActions.Up)
			{
				EditText editText = (EditText)v;
				if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
				{
					editText.Text = string.Empty;
					return true;
				}
			}

			return false;
		}
	}
}
