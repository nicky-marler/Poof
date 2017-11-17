using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Poof.ViewModel
{
    public class Poof_ViewModel : MVVM_Helper.Base_ViewModel
    {
        public INavigation Page_Navigation { get; set; }

        public Model.Project Test_Seed { get; set; }
        public ObservableCollection<Model.Project> Projects { get; set; } = new ObservableCollection<Model.Project>();

        public Model.Project Selected_Project { get; set; }
        public Model.Category Selected_Category { get; set; }
        public Model.Task Selected_Task { get; set; }
        public Model.Bid Selected_Bid { get; set; }

        public Command New_Project_Command { get; }
        public Command New_Category_Command { get; }
        public Command Open_CategoryList_Command { get; }


        public Poof_ViewModel()
        {

            Test_Seed = Project_Seed();
            Test_Seed.Get_Completion();
            Test_Seed.Get_Cost();
            Projects.Add(Test_Seed);

            New_Project_Command = new Command(async () => await New_Project(), () => !IsBusy);
            New_Category_Command = new Command(async () => await New_Category(), () => !IsBusy);
            Open_CategoryList_Command = new Command(async () => await Open_CategoryList(), () => !IsBusy);

        }

        public async Task New_Project()
        {
            Model.Project New_Project = new Model.Project();
            New_Project.Categories = new ObservableCollection<Model.Category>();
            New_Project.Get_Completion();
            New_Project.Get_Cost();
            Projects.Add(New_Project);
            //Telling the page that it'a new Item
            Selected_Project = New_Project;
            await Page_Navigation.PushAsync(new View.Project_View());
        }
        public async Task New_Category()
        {
            Model.Category New_Category = new Model.Category();
            New_Category.Bids = new List<Model.Bid>();
            New_Category.Tasks = new List<Model.Task>();
            Selected_Project.Categories.Add(New_Category);
            Selected_Project.My_Count++;
            Selected_Category = New_Category;
            Selected_Category.Get_Cost();
            await Page_Navigation.PushAsync(new View.Category());
        }

        public async Task Open_CategoryList()
        {
            await Page_Navigation.PushAsync(new View.Category_List());
        }


        private Model.Project Project_Seed() => new Model.Project
        {
            Name = "Senior Capstone",
            Frame = 100,
            Living = 500,
            Slab = 800,
            Categories = new ObservableCollection<Model.Category>
            {
                new Model.Category
                {
                    Name = "Drywall",
                    Bids = new List<Model.Bid>
                    {
                        new Model.Bid
                        {
                            Name = "Bobs Dry",
                            Date_Sent = new DateTime(2017, 9, 10),
                            Date_Received = new DateTime(2017, 9, 12),
                            Phone = "800 123-4567",
                            Price = 107,
                            Selected = true

                        },
                        new Model.Bid
                        {
                            Name = "Wall Up",
                            Date_Sent = new DateTime(2017, 7, 17),
                            Date_Received = new DateTime(2017, 7, 19),
                            Phone = "911 YOU-WALL",
                            Price = 54
                        }
                    },
                    Tasks = new List<Model.Task>
                    {
                        new Model.Task
                        {
                            Name = "Call Mom",
                            Description ="So she doesn't get mad",
                            Finish = false
                        }
                    }
                },
                new Model.Category
                {
                    Name = "Framing",
                    Bids = new List<Model.Bid>
                    {
                        new Model.Bid
                        {
                            Name = "Frame Job",
                            Date_Sent = new DateTime(2017, 9, 10),
                            Date_Received = new DateTime(2017, 9, 12),
                            Phone = "800 Frame Us",
                            Price = 37,
                            Selected = true

                        },
                        new Model.Bid
                        {
                            Name = "Fram for Dummies",
                            Date_Sent = new DateTime(2017, 10, 19),
                            Date_Received = new DateTime(2017, 10, 19),
                            Phone = "123 Dummies ",
                            Price = 99
                        }
                    },
                    Tasks = new List<Model.Task>
                    {
                        new Model.Task
                        {
                            Name = "Do something",
                            Description ="Lift something",
                            Finish = false
                        },
                        new Model.Task
                        {
                            Name = "Do all the things",
                            Description ="drink coffee and do it",
                            Finish = true
                        }
                    }
                },
                new Model.Category
                {
                    Name = "Slab",
                    Bids = new List<Model.Bid>
                    {
                        new Model.Bid
                        {
                            Name = "Slap Slab",
                            Date_Sent = new DateTime(2017, 6, 3),
                            Date_Received = new DateTime(2017, 7, 1),
                            Phone = "XXX XXX-XXXX",
                            Price = 543,
                            Selected = true

                        },
                        new Model.Bid
                        {
                            Name = "Slick and Slab",
                            Date_Sent = new DateTime(2017, 3, 11),
                            Date_Received = new DateTime(2017, 3, 19),
                            Phone = "411 How-Slab",
                            Price = 278
                        }
                    },
                    Tasks = new List<Model.Task>
                    {
                        new Model.Task
                        {
                            Name = "Do work",
                            Description ="Lift the heavy thing",
                            Finish = true
                        },
                        new Model.Task
                        {
                            Name = "Lay cement",
                            Description ="meh",
                            Finish = false
                        },
                        new Model.Task
                        {
                            Name = "Yell at co-worker",
                            Description ="Yell very loudly",
                            Finish = false
                        }
                    }
                }
            }
        };
    }
}
