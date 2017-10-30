using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Poof.Model
{
    public class Project : ObservableObject
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
