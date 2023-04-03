using System.Collections.ObjectModel;
using System.Linq;

namespace ChatApp.Models
{
    public class ContactModel
    {
        public string UserName { get; set; }
        public string ImageSource { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        public string LastMessage => Messages.Any() ? Messages.Last().Message : string.Empty;
    }
}
