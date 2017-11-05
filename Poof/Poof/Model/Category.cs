using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Poof.Model
{
    public class Category : Abstract_Model.Base_Poof
    {
      
        double? average_bid;
        double? selected_bid;

        decimal completion;

        public ObservableCollection<Bid> Bids { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }


        public Category()
        {

            Bids = new ObservableCollection<Bid>();
            Tasks = new ObservableCollection<Task>();
        }

        public double? Average_Bid
        {
            get => average_bid;
            private set
            {
                SetProperty(ref average_bid, value);
            }
        }

        public double? Selected_Bid
        {
            get => selected_bid;
            set
            {
                SetProperty(ref selected_bid, value);
            }
        }

        public decimal Completion
        {
            get => completion;
            private set
            {
                SetProperty(ref completion, value);
            }
        }

        public decimal? Compute_Bid_Average()
        {
            if (Bids.Count == 0)
            {
                return 0;
            }
            decimal total = 0;
            foreach (Bid bid in Bids)
            {
                total += bid.Price;
            }

            return Math.Round(total / Bids.Count(),2);
        }
        //View model stuff?
        public void Compute_Completion()
        {
            decimal Completed = Tasks.Count((Task task) => task.Finish == true);
            decimal Total = Tasks.Count;
            //To prevent dividing by 0
            Completion = Total == 0 ? Total : Math.Round(100 * (Completed / Total), 1);
            //Check for higher up finsih
            if (Completed / Total == 1)
            {
                //might need to be MAX()
                DateTime_Finish = (from task in Tasks select task.DateTime_Finish).Min();
                DateTime_Start = (from task in Tasks select task.DateTime_Start).Min();

                //Set datetime to most recent task
                Finish = true;
            }
        }

    }
}
