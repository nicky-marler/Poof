using Xamarin.Forms;

namespace Poof
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel.Poof_ViewModel();
        }
    }
}