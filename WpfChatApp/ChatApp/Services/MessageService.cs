using System;
using System.Collections.Generic;
using ChatApp.Models;

namespace ChatApp.Services
{
    public class MessageService
    {
        public IEnumerable<MessageModel> GetMessages()
        {
            var listMessages = new List<MessageModel>
            {
                new MessageModel
                {
                    UserName = "Allison",
                    UserNameColor = "#409AFF",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    IsFirstMessage = true
                }
            };

            for (var i = 0; i < 4; i++)
            {
                listMessages.Add(new MessageModel
                {
                    UserName = "Bunny",
                    UserNameColor = "#409AFF",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Last",
                    Time = DateTime.Now,
                    IsNativeOrigin = true
                });
            }

            return listMessages;
        }
    }
}