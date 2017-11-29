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
	public partial class Bid : ContentPage
	{
		public Bid ()
		{
			InitializeComponent ();
            BindingContext = ((App)Application.Current).Data;
        }

        public async void Delete_Bid()
        {
            var Answer = await DisplayAlert("Delete", "Are you sure?", "Yes", "No");
            if (Answer)
            {
                await Navigation.PopAsync();
                ((App)Application.Current).Data.Selected_Category.Bids.Remove(((App)Application.Current).Data.Selected_Bid);
                ((App)Application.Current).Data.Selected_Project.Get_Completion();
                ((App)Application.Current).Data.Selected_Category.Get_Cost();
                ((App)Application.Current).Data.Selected_Category.Bid_Count--;
            }
        }
    }
}