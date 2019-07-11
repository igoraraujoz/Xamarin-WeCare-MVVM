using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeCare.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProntuarioView : ContentPage
	{
		public ProntuarioView ()
		{
			InitializeComponent();
           
		}

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //monkeyNameLabel.Text = picker.Items[selectedIndex];
            }
        }
    }
}