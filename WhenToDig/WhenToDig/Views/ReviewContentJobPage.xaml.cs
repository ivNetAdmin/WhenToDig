﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenToDig.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhenToDig.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReviewContentJobPage : ContentPage
	{
		public ReviewContentJobPage (ReviewContentJobViewModel vm)
		{
			InitializeComponent ();
            BindingContext = vm;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            YearList.SelectedItem = "All";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((ReviewContentJobViewModel)BindingContext).DisposeRealm();
        }
    }
}