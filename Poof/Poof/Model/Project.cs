using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Poof.Model
{
    public class Project : Abstract_Model.Base_Poof
    {
        int frame;
        int slab;
        int living;
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        double? total_cost;
        double completion;
        int my_count;






        public Project()
        {
            Name = "New Project";
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

        public double Completion
        {
            get => completion;
            private set
            {
                SetProperty(ref completion, value);
                OnPropertyChanged(nameof(Completion_Statement));
            }
        }

        public double? Total_Cost
        {
            get => total_cost;
            private set
            {
                SetProperty(ref total_cost, value);
                OnPropertyChanged(nameof(Total_Cost_Statement));
            }
        }


        public int My_Count
        {
            get => my_count;
            set
            {
                SetProperty(ref my_count, value);
                OnPropertyChanged(nameof(Category_Count_Statement));
            }
        }

        public string Total_Cost_Statement
        {
            get => $"Total Cost thus far ${Total_Cost.ToString()}";
        }

        public string Completion_Statement
        {
            get => $"{Completion.ToString()}% Completed";
        }

        public string Category_Count_Statement
        {
            get => $"Categories: {Categories.Count.ToString()}";
        }

        //Run these on Load and on Exit of pages
        public void Get_Completion()
        {
            double Completed_Percent = 0;

            foreach(Category category in Categories)
            {
                category.Compute_Completion();
                Completed_Percent += category.Completion;
            }

           
            double Total = (double)Categories.Count;
            //To prevent dividing by 0
            Completion = Total == 0 ? Total : Math.Round((Completed_Percent / Total), 1);

            if (Completed_Percent / Total == 1)
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
