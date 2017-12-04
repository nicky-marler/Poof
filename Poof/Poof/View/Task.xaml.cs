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
	public partial class Task : ContentPage
	{
		public Task ()
		{
			InitializeComponent ();
            BindingContext = ((App)Application.Current).Data;
        }

        public async void Delete_Task()
        {
            var Answer = await DisplayAlert("Delete", "Are you sure?", "Yes", "No");
            if (Answer)
            {
                await Navigation.PopAsync();
                ((App)Application.Current).Data.Selected_Category.Tasks.Remove(((App)Application.Current).Data.Selected_Task);
                ((App)Application.Current).Data.Selected_Project.Get_Completion();
                ((App)Application.Current).Data.Selected_Category.Get_Cost();
                ((App)Application.Current).Data.Selected_Category.Task_Count--;
            }
        }

        public void Update_Category()
        {
            ((App)Application.Current).Data.Selected_Category.Compute_Completion();
            ((App)Application.Current).Data.Selected_Project.Get_Completion();
        }
    }
}