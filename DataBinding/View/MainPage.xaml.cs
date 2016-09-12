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
		public ObservableCollection<Grouping<string, Contact>> ContactGroup;

		public MainPage()
		{
			Init();
			BindingContext = ContactGroup;
			InitializeComponent();
		}

		private void Init()
		{
			var listOfContacts = ContactGenerator.CreateContacts();

			var sorted =
				from c in listOfContacts
				orderby c.FirstName
				group c by c.FirstName[0].ToString()
							   into theGroup
				select new Grouping<string, Contact>(theGroup.Key, theGroup);

			ContactGroup = new ObservableCollection<Grouping<string, Contact>>(sorted);
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

