using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace Poof.Model 
{
    class Task : ObservableObject
    {
        //Will liekly scrap the double crap

        string name;
        bool finish;

        //These will open a new page
        DateTime datetime_start;
        DateTime datetime_finish;
        TimeSpan time_estimating;
        TimeSpan time_elapsed;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public bool Finish
        {
            get { return finish; }
            set
            {
                SetProperty(ref finish, value);                
            }
        }
        public TimeSpan Time_Elapsed
        {
            get { return time_elapsed; }
            set
            {
                SetProperty(ref time_elapsed, value);
            }
        }
        public TimeSpan Time_Estimating
        {
            get { return time_estimating; }
            set
            {
                SetProperty(ref time_estimating, value);
            }
        }
        public DateTime DateTime_Start
        {
            get { return datetime_start; }
            set
            {
                SetProperty(ref datetime_start, value);
            }
        }
        public DateTime DateTime_Finish
        {
            get { return datetime_finish; }
            set
            {
                SetProperty(ref datetime_finish, value);
            }
        }

        //DateTime(int Year, int Month, int Day, int Hour, int Min, int Sec) will use this in the converter? Or cs file
        public Task()
        {
            name = "New Task";
            finish = false;
            //time_estimating = new TimeSpan(0,0,0,0);
            //time_elapsed = new TimeSpan(0, 0, 0, 0);
            //datetime_start = DateTime.Now;
            //datetime_finish = DateTime.Now;
        }



    }
}
