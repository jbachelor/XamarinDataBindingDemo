using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using DataBinding.Model;

namespace DataBinding.Services
{
	public class ContactGenerator
	{
		private static List<string> _firstNames = new List<string> {
			"aiden", "Liam", "Lucas", "Noah", "Mason", "Ethan", "Caden", "Jacob", "logan", "jayden", "Elijah", "Jack", "Luke", "Michael", "Benjamin",
			"alexander", "James", "Jayce", "Caleb", "Connor", "William", "Carter", "ryan", "oliver", "Matthew", "Daniel", "Gabriel", "Henry", "Owen",
			"grayson", "Lincoln", "Jordan", "Tristan", "Jason", "Josiah", "Xavier", "camden", "chase", "Declan", "Carson", "Colin", "Brody", "Asher",
			"jeremiah", "Micah", "Easton", "Xander", "Ryder", "Nathaniel", "Elliot", "sean", "jon", "Christine", "Emma", "Bella", "Roxy"
		};

		private static List<string> _lastNames = new List<string>
		{
			"SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "MILLER", "DAVIS", "GARCIA", "RODRIGUEZ", "WILSON", "MARTINEZ", "ANDERSON", "TAYLOR", "THOMAS HERNANDEZ",
			"RICHARDSON", "WOOD", "WATSON", "BROOKS", "BENNETT GRAY", "JAMES", "REYES", "CRUZ", "HUGHES", "PRICE", "MYERS", "LONG", "FOSTER SANDERS", "ROSS",
			"MORALES", "POWELL", "SULLIVAN", "RUSSELL ORTIZ", "JENKINS", "GUTIERREZ", "PERRY", "BUTLER", "BARNES FISHER", "HENDERSON", "COLEMAN", "SIMMONS", "PATTERSON",
			"JORDAN", "REYNOLDS", "BACHELOR", "WELSCH"
		};

		public static ObservableCollection<Contact> CreateContacts()
		{
			var random = new Random();
			var contacts = new ObservableCollection<Contact>();

			for (int i = 0; i < 50; i++)
			{
				string firstName = _firstNames[random.Next(_firstNames.Count - 1)];
				string lastName = _lastNames[random.Next(_lastNames.Count - 1)];
				firstName = InitCap(firstName);
				lastName = InitCap(lastName);
				string email = $"{ConvertToCamelCase(firstName[0].ToString())}{ConvertToCamelCase(lastName)}@gmail.com";

				if (contacts.Any(c => c.FirstName == firstName && c.LastName == lastName))
				{
					i--;
					continue;
				}

				contacts.Add(new Contact
				{
					FirstName = firstName,
					LastName = lastName,
					Email = email
				});
			}

			return contacts;
		}

		static string ConvertToCamelCase(string text)
		{
			var inputArray = text.ToLower().Trim().Split(' ', '-', '.');
			StringBuilder result = new StringBuilder(inputArray[0].ToLower());

			for (int i = 1; i < inputArray.Length; i++)
			{
				result.Append(InitCap(inputArray[i]));
			}

			return result.ToString();
		}

		static string InitCap(string wordToInitCap)
		{
			if (string.IsNullOrWhiteSpace(wordToInitCap))
				throw new ArgumentNullException(nameof(wordToInitCap));

			string result = wordToInitCap.ToLower();
			string firstChar = wordToInitCap[0].ToString().ToUpper();
			result = $"{firstChar}{result.Substring(1)}";
			return result;
		}
	}
}

