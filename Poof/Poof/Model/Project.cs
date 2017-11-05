using System;
using System.Linq;
using System.Collections.Generic;

namespace Poof.Model
{
    public class Project : Abstract_Model.Base_Poof
    {
        int frame;
        int slab;
        int living;
        List<Category> Categories { get; set; } = new List<Category>(10);
        double? total_cost;
        decimal completion;



        public Project()
        {

        }

        public int Living
        {
            get => living;
            set
            {
                SetProperty(ref living, value);
            }
        }

        public int Slab
        {
            get => slab;
             set
            {
                SetProperty(ref slab, value);
            }
        }

        public int Frame
        {
            get => frame;
            set
            {
                SetProperty(ref frame, value);
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

        public double? Total_Cost
        {
            get => total_cost;
            private set
            {
                SetProperty(ref total_cost, value);
            }
        }


        //Run these on Load and on Exit of pages
        public void Get_Completion()
        {
            decimal Completed = (decimal)Categories.Count((Category category) => category.Finish == true);
            decimal Total = (decimal)Categories.Count;
            //To prevent dividing by 0
            Completion = Total == 0 ? Total : Math.Round(100 * (Completed / Total), 1);

            if (Completed / Total == 1)
            {
                //might need to be MAX()
                DateTime_Finish = (from category in Categories select category.DateTime_Finish).Min();
                DateTime_Start = (from category in Categories select category.DateTime_Start).Min();

                //Set datetime to most recent task
                Finish = true;
            }
        }

        public void Get_Cost()    
        {
            double? total = 0;
            foreach(Category category in Categories)
            {
                total += category.Selected_Bid;
            }

            Total_Cost = total;
        }
    }
}
