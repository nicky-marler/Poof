using Xamarin.Forms;

namespace Poof
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

           ((App)Application.Current).Data.Page_Navigation = Navigation; //Tells the ViewModel where the pages are in Navigation for Pushing and Popping
           BindingContext = ((App)Application.Current).Data;
            
        }

        private async void Open_Selected_Project(object sender, SelectedItemChangedEventArgs e)
        {
            //ItemSelected is called on deselection, which results in SelectedItem being set to null
            if (e.SelectedItem == null)
            {
                return;
            }
            ((App)Application.Current).Data.Selected_Project = (Model.Project)e.SelectedItem;
            ((App)Application.Current).Data.Selected_Project.My_Count = ((App)Application.Current).Data.Selected_Project.Categories.Count;
            await Navigation.PushAsync(new View.Project_View());
            
            Project_List.SelectedItem = null;

        }
    }
}