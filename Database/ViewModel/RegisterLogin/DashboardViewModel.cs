using Database.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModel.RegisterLogin
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public RegisterDatabase _registerDatabase;

        public string _userName;
        public int Id { get; set; }
        public string UserName 
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }    
        public DashboardViewModel() 
        {
            _registerDatabase = new RegisterDatabase();
            _registerDatabase.CreateDatabase();
            _ = _registerDatabase.CreateTableAsync();
        }

        public async Task Validate()
        {
            _registerDatabase.Id = Id;
            await _registerDatabase.ValidateId();
            UserName = _registerDatabase.UserName;  
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
        }
    }
}
