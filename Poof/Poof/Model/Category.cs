using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Poof.Model
{
    class Category : MVVM_Helper.Observable_Object
    {
        string name;
        int total_square_feet;
        double average_bid_cost;

        double? selected_cost;
        decimal? completion_percentage;

        //DateTime(int Year, int Month, int Day)
        DateTime datetime_start;
        DateTime datetime_finish;

        bool finish;

        //This will need to be handeled by ViewModel
        //public Bid Selected_Bid { get; set; }

        public ObservableCollection<Bid> Bid_List { get; set; }
        public ObservableCollection<Task> Task_List { get; set; }

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




        public Category()
        {
            Bid_List = new ObservableCollection<Bid>();
            Task_List = new ObservableCollection<Task>();
        }

        public void Percentage_Completed()
        {
            //Can't divide by 0
            if(Task_List.Count == 0)
            {
                completion_percentage = 0;
            }
            else
            {
                //This gives the percent completion of the list.
                //
                //A lambda expression is used to count the finished tasks which is divided by its total
                //The two counts are converted to decimal becuase of integer division does not give deciaml value
                //The new decimal after division is then multiplied by 100 for a percent value and has the excess rounded off.
                completion_percentage = Math.Round(100* ((decimal)Task_List.Count((Task task) => task.Finish = true) / (decimal)Task_List.Count),1);
            }
        }

    }
}
