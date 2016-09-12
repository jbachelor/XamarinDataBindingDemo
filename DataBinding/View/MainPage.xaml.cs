using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using DataBinding.Model;
using DataBinding.Services;

namespace DataBinding.View
{
	public partial class MainPage : ContentPage
	{
		public MainPageViewModel ThisMainPageViewModel;

		public MainPage()
		{
			ThisMainPageViewModel = new MainPageViewModel();
			BindingContext = ThisMainPageViewModel;
			InitializeComponent();
		}

		public void OnItemTapped(object obj, ItemTappedEventArgs args)
		{
			if (args == null) return;
			var selectedContact = args.Item as Contact;
			if (selectedContact == null) return;

			DisplayAlert("Aha!", $"You tapped {selectedContact.FirstName} {selectedContact.LastName}", "ok");
		}
	}
}

