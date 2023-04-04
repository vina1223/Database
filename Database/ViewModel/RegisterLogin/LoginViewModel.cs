using CommunityToolkit.Maui.Alerts;
using Database.Database;
using Database.Result;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Database.ViewModel.RegisterLogin
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public RegisterDatabase _registerDatabase;
        public event EventHandler<Results> LoginTODashboardEventHandler;
       
        private string _loginUser { get; set; }
        private string _loginPassword { get; set; }

        public string LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                OnPropertyChanged();
            }
        }

        public string LoginPassword
        {
            get { return _loginPassword; }
            set
            {
                _loginPassword = value;
                OnPropertyChanged();
            }
        }

        public  ICommand LoginCommand { get; set; }
 

        public LoginViewModel()
        {
            _registerDatabase = new RegisterDatabase();
            _ =_registerDatabase.CreateTableAsync();
            _=_registerDatabase.GetListAsync();
            _registerDatabase.CreateDatabase();
            LoginCommand = new Command(Validation);
        
        }

      

        public void Validation()
        {
            if (string.IsNullOrWhiteSpace(LoginUser))
            {
                Toast.Make("Enter the valid UserName", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(LoginPassword))
            {
                Toast.Make("Enter the Valid Password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                _=SendLoginData();
            }
        }
        public async Task SendLoginData()
        {
            _registerDatabase.LoginUser = LoginUser;
            _registerDatabase.LoginPassword= LoginPassword;
            var result = await _registerDatabase.GetListAsync();
            LoginTODashboardEventHandler?.Invoke(this, result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
        }
    }
}
