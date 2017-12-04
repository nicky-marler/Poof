using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Database_Seed
{
    class Program
    {
        private DocumentClient client;

        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                //p.GetStartedDemo().Wait();
                p.SeedDB().Wait();
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
            finally
            {
                Console.WriteLine("End, press any key to exit.");
                Console.ReadKey();

            }
        }

        private void WriteToConsole(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        private async Task CreateDocumentIfNotExists(string databaseName, string collectionName, Model.Project project_seed)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, project_seed.Id) );
                this.WriteToConsole("Found {0}", "Items");
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), project_seed);
                    this.WriteToConsole("Created Item {0}", project_seed.Name);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task SeedDB()
        {
            this.client = new DocumentClient(new Uri(Azure_Connection.EndpointUri), Azure_Connection.Key);

            Model.Project Project_0 = new Model.Project
            {
                Id = "Test",
                Name = "Class Upload",
                Frame = 100,
                Living = 500,
                Slab = 800,
                Categories = new List<Model.Category>
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
                            Finish = true
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
                            Finish = true
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
                            Finish = true
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
            await this.CreateDocumentIfNotExists(Azure_Connection.DB, Azure_Connection.Collection, Project_0);

        }

    }
}
