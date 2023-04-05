using CommunityToolkit.Maui.Alerts;
using Database.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Database.ViewModel.Activity
{
    public class AddActivityViewModel : INotifyPropertyChanged
    {
        public ActivityDatabase _activityDatabase;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler NextEvent;

        private string _name;
        private string _date;
        private bool _complete;
       
        public string Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public bool Complete
        {
            get { return _complete; }
            set
            {
                _complete = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddActivityCommand { get; private set; }
        public AddActivityViewModel()
        {
            _activityDatabase = new ActivityDatabase();
            _activityDatabase.CreateDatabase();
            _ = _activityDatabase.CreateTableAsync();
            AddActivityCommand = new Command(() => { _ = SendData(); });
        }

        public async Task SendData()
        {
            _activityDatabase.Name = Name;
            _activityDatabase.Date = Date;
            _activityDatabase.Complete = Complete;
            var insertrecords = await _activityDatabase.InsertAsync();
            if (insertrecords == true)
            {
                Toast.Make("Success", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                NextEvent?.Invoke(this, new EventArgs());
            }
            else
            {
                Toast.Make("Fail", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
