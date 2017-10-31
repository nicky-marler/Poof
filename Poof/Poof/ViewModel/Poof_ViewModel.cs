using Xamarin.Forms;

namespace Poof.ViewModel
{
    public class Poof_ViewModel : MVVM_Helper.Base_ViewModel
    {
        public Model.Test Testy { get; set; }
        public Command Reset_Command { get; } 

        public Poof_ViewModel()
        {
        Reset_Command = new Command(Reset_Names);
        Testy = new Model.Test();
        }

        void Reset_Names()
        {
            Testy.Name = "";
            Testy.Other_Name = "";
        }
    }
}
