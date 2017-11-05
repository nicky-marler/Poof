using System;

namespace Poof.Model
{
    public class Bid : MVVM_Helper.Observable_Object
    {
        string name;
        string phone;
        decimal price;
        DateTime date_sent;
        DateTime date_received;
        bool selected;


        public Bid()
        {
            name = "New Bid";
            phone = "";
            selected = false;


        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
            }
        }
        public string Phone
        {
            get => phone; 
            set
            {
                SetProperty(ref phone, value);
            }
        }

        public decimal Price
        {
            get => price; 
            set
            {
                SetProperty(ref price, value);
            }
        }
        public DateTime Date_Sent
        {
            get => date_sent; 
            set
            {
                SetProperty(ref date_sent, value);
            }
        }
        public DateTime Date_Received
        {
            get => date_received; 
            set
            {
                SetProperty(ref date_received, value);
            }
        }
        public bool Selected
        {
            get { return selected; }
            set
            {
                //Need todo an event? or do ViewModel stuff to handle updatting higher object
                SetProperty(ref selected, value);
            }
        }





    }
}
