namespace Poof.Model
{
    public class Test : MVVM_Helper.Observable_Object
    {
        string name = string.Empty;
        string other_name = string.Empty;

        public string Name
        {
            get => other_name; 
            set
            {
                SetProperty(ref other_name, value);
                OnPropertyChanged(nameof(Statement));
            }
        }

        public string Other_Name
        {
            get => name; 
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(Statement));
            }
        }

        public string Statement
        {
            get => $"{Name} and {Other_Name} are enemies"; 
        }
    }
}
