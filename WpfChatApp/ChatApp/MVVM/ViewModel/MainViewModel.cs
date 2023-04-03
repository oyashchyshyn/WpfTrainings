using System.Collections.ObjectModel;
using ChatApp.Core;
using ChatApp.Models;
using ChatApp.Services;

namespace ChatApp.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly MessageService _messageService;
        private readonly ContactsService _contactsService;
        public ObservableCollection<MessageModel> Messages { get; } = new ObservableCollection<MessageModel>();
        public ObservableCollection<ContactModel> Contacts { get; } = new ObservableCollection<ContactModel>();

        #region Commands

        public RelayCommand SendCommand { get; }

        #endregion

        #region Properties

        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MainViewModel(
            MessageService messageService, 
            ContactsService contactsService
            )
        {
            _messageService = messageService;
            _contactsService = contactsService;

            SendCommand = new RelayCommand(o =>
            {
                CreateMessage();
            });
        }

        public void ApplyData()
        {
            foreach (var message in _messageService.GetMessages())
            {
                Messages.Add(message);
            }
            
            foreach (var contact in _contactsService.GetContacts())
            {
                contact.Messages = Messages;
                Contacts.Add(contact);
            }
        }
        
        private void CreateMessage()
        {
            Messages.Add(new MessageModel
            {
                Message = Message,
                IsFirstMessage = false
            });

            Message = string.Empty;
        }
    }
}
