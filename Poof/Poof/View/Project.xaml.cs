using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poof.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Project_View : ContentPage
	{

		public Project_View ()
		{
			InitializeComponent ();
            BindingContext = ((App)Application.Current).Data;
		}

        public async void Delete_Project()
        {
            var Answer = await DisplayAlert("Delete", "Are you sure?", "Yes", "No");
            if (Answer)
            {
                await Navigation.PopAsync();
                ((App)Application.Current).Data.Projects.Remove(((App)Application.Current).Data.Selected_Project);

            }
        }

    }
}