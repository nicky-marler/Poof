using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Documents;

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
        public Command New_Task_Command { get; }
        public Command New_Bid_Command { get; }
        public Command Open_CategoryList_Command { get; }
        public Command Open_BidList_Command { get; }
        public Command Open_TaskList_Command { get; }
        public Command Fetch_Data_Command { get; }


        public Poof_ViewModel()
        {

            //Test_Seed = Project_Seed();
            //Test_Seed.Get_Completion();
            //Test_Seed.Get_Cost();
            //Projects.Add(Test_Seed);
            


            New_Project_Command = new Command(async () => await New_Project(), () => !IsBusy);
            New_Category_Command = new Command(async () => await New_Category(), () => !IsBusy);
            New_Task_Command = new Command(async () => await New_Task(), () => !IsBusy);
            New_Bid_Command = new Command(async () => await New_Bid(), () => !IsBusy);
            Open_CategoryList_Command = new Command(async () => await Open_CategoryList(), () => !IsBusy);
            Open_BidList_Command = new Command(async () => await Open_BidList(), () => !IsBusy);
            Open_TaskList_Command = new Command(async () => await Open_TaskList(), () => !IsBusy);
            Fetch_Data_Command = new Command(async () => await Fetch_Data(), () => !IsBusy);

           

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
        public async Task New_Task()
        {
            Model.Task New_Task = new Model.Task();
            New_Task.Name = "New Task";
            New_Task.Description = "";
            New_Task.Finish = false;
            Selected_Category.Tasks.Add(New_Task);
            Selected_Category.Task_Count++;
            Selected_Task = New_Task;
            Selected_Category.Get_Cost();
            await Page_Navigation.PushAsync(new View.Task());
        }
        public async Task New_Bid()
        {
            Model.Bid New_Bid = new Model.Bid();
            New_Bid.Name = "New Bid";
            New_Bid.Selected = false;
            New_Bid.Price = 0.0;
            Selected_Category.Bids.Add(New_Bid);
            Selected_Category.Task_Count++;
            Selected_Bid = New_Bid;
            Selected_Category.Get_Cost();
            await Page_Navigation.PushAsync(new View.Bid());
        }

        public async Task Open_CategoryList()
        {
            await Page_Navigation.PushAsync(new View.Category_List());
        }

        public async Task Open_BidList()
        {
            await Page_Navigation.PushAsync(new View.Bid_List());
        }

        public async Task Open_TaskList()
        {
            await Page_Navigation.PushAsync(new View.Task_List());
        }

        public async Task Fetch_Data()
        {
            IsBusy = true;
            Projects.Clear();
            try
            {
                var Query = Azure.QueryManager.Set_Query();
                while (Query.HasMoreResults)
                {
                    foreach (Model.Document DB_Document in await Query.ExecuteNextAsync<Model.Document>())
                    {
                        //Creates Business object to be added to the list
                        Model.Project New_Project = new Model.Project
                        {
                            ID = DB_Document.Id,
                            Name = DB_Document.Name,
                            Frame = DB_Document.Frame,
                            Living = DB_Document.Living,
                            Slab = DB_Document.Slab,
                            Categories = DB_Document.Categories

                        };
                        New_Project.Get_Completion();
                        New_Project.Get_Cost();

                        Projects.Add(New_Project);                           
                 

                    }
                }
                IsBusy = false;

            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
        }

        //For local testing
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
