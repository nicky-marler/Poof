using System;


namespace Poof.Model 
{
    public class Task : Abstract_Model.Base_Poof
    {
        public string Description { get; set; }
        bool finish;

        new public bool Finish
        {
            get => finish;
            set
            {
                SetProperty(ref finish, value);
                OnPropertyChanged(nameof(Completion_Statement));
            }
        }

        public string Completion_Statement
        {
            get
            {
                if (Finish)
                {
                    return $"Completed";
                }
                else
                {
                    return $"Not Completed";
                }
            }
        }
        //DateTime(int Year, int Month, int Day, int Hour, int Min, int Sec) will use this in the converter? Or cs file
        public Task()
        {

        }

        

    }
}
