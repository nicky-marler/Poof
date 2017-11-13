using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Poof.Model
{
    public class Category : Abstract_Model.Base_Poof
    {
      
        double average_bid;

        double completion;


        public List<Bid> Bids { get; set; }
        public List<Task> Tasks { get; set; }


        public Category()
        {

            Bids = new List<Bid>();
            Tasks = new List<Task>();
        }

        public double Average_Bid
        {
            get => average_bid;
            private set
            {
                SetProperty(ref average_bid, value);
            }
        }

        public double? Selected_Bid
        {
            get
            {
                if (Bids.Exists(bid => bid.Selected == true))
                {
                    return Bids?.Find(bid => bid.Selected == true).Price;
                }
                return 0;
            }          
        }

        public double Completion
        {
            get => completion;
            private set
            {
                SetProperty(ref completion, value);
            }
        }

        public string Completion_Statement
        {
            get => $"{Completion.ToString()}% Completed";
        }

        public double? Compute_Bid_Average()
        {
            if (Bids?.Count == 0)
            {
                return 0;
            }
            double total = 0;
            foreach (Bid bid in Bids)
            {
                total += bid.Price;
            }

            return Math.Round(total / Bids.Count(),2);
        }
        //View model stuff?
        public void Compute_Completion()
        {
            double Completed = Tasks.Count((Task task) => task.Finish == true);
            double Total = Tasks.Count;
            //To prevent dividing by 0
            Completion = Total == 0 ? Total : Math.Round(100 * (Completed / Total), 1);
            //Check for higher up finsih
            if (Completed / Total == 1)
            {
                //might need to be MAX() likely remove
                DateTime_Finish = (from task in Tasks select task.DateTime_Finish).Min();
                DateTime_Start = (from task in Tasks select task.DateTime_Start).Min();

                //Set datetime to most recent task
                Finish = true;
            }
        }

    }
}
