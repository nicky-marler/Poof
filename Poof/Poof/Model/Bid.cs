using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace Poof.Model
{
    class Bid : ObservableObject
    {
        string name;
        string phone;
        double price_psf;
        double price_total;
        DateTime date_sent;
        DateTime date_received;
        bool selected;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                SetProperty(ref phone, value);
            }
        }
        public double Price_PSF
        {
            get { return price_psf; }
            set
            {
                SetProperty(ref price_psf, value);
            }
        }
        public double Price_Total
        {
            get { return price_total; }
            set
            {
                SetProperty(ref price_total, value);
            }
        }
        public DateTime Date_Sent
        {
            get { return date_sent; }
            set
            {
                SetProperty(ref date_sent, value);
            }
        }
        public DateTime Date_Received
        {
            get { return date_received; }
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


        public Bid()
        {
            name = "New Bid";
            phone = "";
            //price_psf = 0;
            //price_total = 0;
            //date_sent = DateTime.Now;
            //date_received = DateTime.Now;
            selected = false;


        }



    }
}
