using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace DataBinding
{
	public partial class MainPage : ContentPage
	{
		public List<Contact> Contacts { get; set; }

		public MainPage()
		{
			Init();
		}

		private async Task Init()
		{
			var listOfContacts = new List<Contact>();
			listOfContacts = await ContactGenerator.CreateContacts();
			Contacts = listOfContacts;

			BindingContext = this;
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

