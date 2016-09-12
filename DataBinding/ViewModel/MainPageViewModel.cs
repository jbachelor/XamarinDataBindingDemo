using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using DataBinding.Model;
using DataBinding.Services;


namespace DataBinding
{
	public class MainPageViewModel
	{
		public ObservableCollection<Grouping<string, Contact>> Contacts { get; set; }

		public MainPageViewModel()
		{
			ObservableCollection<Contact> listOfContacts = ContactGenerator.CreateCannedContacts();
			IEnumerable<Grouping<string, Contact>> sortedAndGroupedContacts = GetSortedAndGroupedContacts(listOfContacts);

			Contacts = new ObservableCollection<Grouping<string, Contact>>(sortedAndGroupedContacts);
		}

		private static IEnumerable<Grouping<string, Contact>> GetSortedAndGroupedContacts(ObservableCollection<Contact> listOfContacts)
		{
			return from theContact in listOfContacts
				   orderby theContact.FirstName
				   group theContact by theContact.FirstName[0].ToString()
										   into theGroup
				   select new Grouping<string, Contact>(theGroup.Key, theGroup);
		}
	}
}

