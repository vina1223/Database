using CommunityToolkit.Maui.Alerts;
using Database.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Database.ViewModel.TaskManager
{
    public class CreateNewtaskViewModel : INotifyPropertyChanged
    {
        private TaskManagerDatabase _taskManagerDatabase;
        public event EventHandler AddEvent;

        private string _name;
        private string _description;
        private string _date;
        private string _startTime;
        private string _endTime;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }    
            set
            {
                _description = value;
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

        public string StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged();
            }
        }

        public string EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateTaskCommand { get; private set; }

        public CreateNewtaskViewModel()
        {
            _taskManagerDatabase = new TaskManagerDatabase();
            _taskManagerDatabase.CreateDatabase();
           _= _taskManagerDatabase.CreateTableAsync();
            CreateTaskCommand = new Command(() => { _ = SendNewTaskData(); });
            
        }

        public async Task SendNewTaskData()
        {
            _taskManagerDatabase.Name = Name;
            _taskManagerDatabase.Description = Description;
            _taskManagerDatabase.Date = Date;
            _taskManagerDatabase.StartTime = StartTime;
            _taskManagerDatabase.EndTime = EndTime;
            var result = await _taskManagerDatabase.InserAsync();
            if(result == true)
            {
                _=Toast.Make("Success", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                AddEvent?.Invoke(this, new EventArgs());

            }
            else
            {
               _=Toast.Make("Fail", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
