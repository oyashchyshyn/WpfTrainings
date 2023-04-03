using System.Collections.Generic;
using ChatApp.Models;

namespace ChatApp.Services
{
    public class ContactsService
    {
        public IEnumerable<ContactModel> GetContacts()
        {
            var listContacts = new List<ContactModel>();

            for (var i = 0; i < 5; i++)
            {
                listContacts.Add(new ContactModel
                {
                    UserName = $"Allison {i}",
                    ImageSource = "https://i.imgur.com/i2szTsp.png"
                });
            }

            return listContacts;
        }
    }
}