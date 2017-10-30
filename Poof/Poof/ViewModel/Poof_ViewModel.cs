using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poof.ViewModel
{
    public class Poof_ViewModel : BaseViewModel
    {
        public Model.Project Test { get; set; } = new Model.Project();

        public Poof_ViewModel()
        {
            Test = new Model.Project();
        }
    }
}
