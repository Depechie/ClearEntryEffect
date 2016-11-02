using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(ClearEntryEffect.iOS.Effects.ClearEntryEffect), "ClearEntryEffect")]
namespace ClearEntryEffect.iOS.Effects
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
			((UITextField)Control).ClearButtonMode = UITextFieldViewMode.WhileEditing;
		}
	}
}
