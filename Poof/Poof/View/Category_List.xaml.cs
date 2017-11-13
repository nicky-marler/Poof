using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poof.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Category_List : ContentPage
	{
		public Category_List ()
		{
			InitializeComponent ();
            BindingContext = ((App)Application.Current).Data;
        }

        private async void Open_Selected_Category(object sender, SelectedItemChangedEventArgs e)
        {
            //ItemSelected is called on deselection, which results in SelectedItem being set to null
            if (e.SelectedItem == null)
            {
                return;
            }
            ((App)Application.Current).Data.Selected_Category = (Model.Category)e.SelectedItem;
            await Navigation.PushAsync(new View.Category());

            The_Category_List.SelectedItem = null;

        }
    }
}