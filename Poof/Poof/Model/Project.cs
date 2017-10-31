

namespace Poof.Model
{
    public class Project : MVVM_Helper.Observable_Object
    {
        string name = "Hello Senior Capstone";
       
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }


        public Project()
        {

        }
    }
}
