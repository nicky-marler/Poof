using System;
using System.Collections.Generic;
using System.Text;

namespace Poof.Abstract_Model
{
    public abstract class Base_Poof : MVVM_Helper.Observable_Object
    {
        string name;
        bool finish;

        //These will open a new page
        DateTime datetime_start;
        DateTime? datetime_finish;
        TimeSpan? time_estimating;
        TimeSpan? time_elapsed;

        public string Name
        {
            get => name; 
            set
            {
                SetProperty(ref name, value);
            }
        }
        public bool Finish
        {
            get => finish; 
            set
            {
                
                SetProperty(ref finish, value);
            }
        }
        public TimeSpan? Time_Elapsed
        {
            get => time_elapsed; 
            set
            {
                SetProperty(ref time_elapsed, value);
            }
        }
        public TimeSpan? Time_Estimating
        {
            get => time_estimating; 
            set
            {
                SetProperty(ref time_estimating, value);
            }
        }
        public DateTime DateTime_Start
        {
            get => datetime_start; 
            set
            {
                SetProperty(ref datetime_start, value);
            }
        }
        public DateTime? DateTime_Finish
        {
            get => datetime_finish; 
            set
            {
                SetProperty(ref datetime_finish, value);
            }
        }



    }
}
