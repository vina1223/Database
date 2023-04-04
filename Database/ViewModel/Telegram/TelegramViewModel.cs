using Database.Model.Telegram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModel.Telegram
{
    public class TelegramViewModel
    {
        public ObservableCollection<TelegramModel> MenuData { get; set; }

        public ObservableCollection<TelegramModel> MenuData2 { get; set; }

        public TelegramViewModel() 
        {
            MenuData = new ObservableCollection<TelegramModel>
            {
                 new TelegramModel()
                 {
                     Image = "dotnet_net",
                     Name ="New Group",
                     Frame = false,

                 },
                 new TelegramModel()
                 {
                      Image = "dotnet_net",
                     Name ="Contacts",
                     Frame = false,

                 },
                 new TelegramModel()
                 {
                      Image = "dotnet_net",
                     Name ="Calls",
                     Frame = false,

                 },
                 new TelegramModel()
                 {
                      Image = "dotnet_net",
                     Name ="People NearBy",
                     Frame = false,

                 },
                 new TelegramModel()
                 {
                      Image = "dotnet_net",
                     Name ="Save Message",
                     Frame = false,

                 },
                 new TelegramModel()
                 {
                      Image = "dotnet_net",
                     Name ="Setting",
                     Value = 3,
                     Frame = true,
                     Line = true,
                 },


                new TelegramModel()
                {
                     Image = "dotnet_net",
                     Name ="Invite Friends",
                     Frame = false,
                },

                 new TelegramModel()
                {
                     Image = "dotnet_net",
                     Name ="Telegram Featurs",
                     Frame= false,
                },
            };
        }
    }
}
