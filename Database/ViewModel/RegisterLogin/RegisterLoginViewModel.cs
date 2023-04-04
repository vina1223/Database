using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Database.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Database.ViewModel.RegisterLogin
{
    public class RegisterLoginViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;
        private string _conformPassword;

        private RegisterDatabase _registerdatabase;
        public event EventHandler NextpageEvent;

        public string UserName
        {
            get => _userName; 
            set 
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                OnPropertyChanged();
            }
        }

        public string _changed;
        public string Changed
        {
            get { return _changed; }
            set
            {
                _changed = value;
                
                OnPropertyChanged();
            }
        } 

        public string ConformPassword
        {
            get { return _conformPassword; }
            set
            {
                _conformPassword = value;
                OnPropertyChanged();
            }
        }

        public bool _buttonEnable;
        public bool ButtonEnable
        {
            get => _buttonEnable; 
            set
            {
                _buttonEnable = value;
                
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; private set; }
        public ICommand NextPage { get; set; }

        public RegisterLoginViewModel()
        {
            _registerdatabase = new RegisterDatabase();
            _registerdatabase.CreateDatabase();
            _=_registerdatabase.CreateTableAsync();
            _=_registerdatabase.GetListAsync();
            RegisterCommand = new Command(Validation);
            NextPage = new Command(Navigation);
        }

        public void Navigation()
        {
            NextpageEvent?.Invoke(this, new EventArgs());
        }

        public void Validation()
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrWhiteSpace(UserName))
            {
                Toast.Make("InValid UserName", ToastDuration.Short).Show();
            }
            else if (string.IsNullOrEmpty(Password) && string.IsNullOrWhiteSpace(Password))
            {
                Toast.Make("InValid Password", ToastDuration.Short).Show();
            }
            else if (Password != ConformPassword)
            {
                Toast.Make("Password Not Matched", ToastDuration.Short).Show();
            }
            else
            {
                SendDetails();
            }
        }
        public async Task SendDetails()
        {
                _registerdatabase.UserName = UserName;
                _registerdatabase.Password = Password;
                var insertrecord = await _registerdatabase.InsertDataAsync();

            if (insertrecord == false)
            {
                await Toast.Make("Fail to insert", ToastDuration.Short).Show();
            }
            else
            {
                await Toast.Make("Success", ToastDuration.Short).Show();
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));  
        }    

    }
}
