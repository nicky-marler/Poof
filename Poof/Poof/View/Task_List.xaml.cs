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
	public partial class Task_List : ContentPage
	{
        public Task_List()
        {
            InitializeComponent();
            BindingContext = ((App)Application.Current).Data;
        }

        private async void Open_Selected_Category(object sender, SelectedItemChangedEventArgs e)
        {
            //ItemSelected is called on deselection, which results in SelectedItem being set to null
            if (e.SelectedItem == null)
            {
                return;
            }
            ((App)Application.Current).Data.Selected_Task = (Model.Task)e.SelectedItem;
            ((App)Application.Current).Data.Selected_Category.Get_Cost();
            await Navigation.PushAsync(new View.Task());

            The_Task_List.SelectedItem = null;

        }
    }
}