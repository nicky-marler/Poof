﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poof.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Category : ContentPage
	{
		public Category ()
		{
			InitializeComponent ();
            BindingContext = ((App)Application.Current).Data;
        }

        public async void Delete_Category()
        {
            var Answer = await DisplayAlert("Delete", "Are you sure?", "Yes", "No");
            if (Answer)
            {
                await Navigation.PopAsync();
                ((App)Application.Current).Data.Selected_Project.Categories.Remove(((App)Application.Current).Data.Selected_Category);
                ((App)Application.Current).Data.Selected_Project.Get_Completion();
                ((App)Application.Current).Data.Selected_Project.Get_Cost();
                ((App)Application.Current).Data.Selected_Project.My_Count--;
            }
        }
    }
}