using Database.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database.ViewModel.TaskManager
{
    public class UpdateListViewModel :INotifyPropertyChanged
    {
        private TaskManagerDatabase _taskManagerDatabase;
        public event EventHandler<bool> UpdateEvent;

        private int _id;
        private string _name;
        private string _description;
        private string _date;
        private string _startTime;
        private string _endTime;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }

        }

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

        public ICommand UpdateCommand { get; private set; }

        public UpdateListViewModel()
        {
            _taskManagerDatabase = new TaskManagerDatabase();
            _taskManagerDatabase.CreateDatabase();
            _ = _taskManagerDatabase.CreateTableAsync();
            UpdateCommand = new Command(() => { _ = UpDateData(); });
        }

        public async Task DataDisplay()
        {
            _taskManagerDatabase.Id = Id;
            await _taskManagerDatabase.GetDataAsync();
            Name = _taskManagerDatabase.Name;
            Description = _taskManagerDatabase.Description;
            Date=_taskManagerDatabase.Date;
            StartTime = _taskManagerDatabase.StartTime;
            EndTime = _taskManagerDatabase.EndTime;
        }

        public async Task UpDateData()
        {
            _taskManagerDatabase.Id = Id;
            _taskManagerDatabase.Name = Name;
            _taskManagerDatabase.Date = Date;
            _taskManagerDatabase.StartTime = StartTime;
            _taskManagerDatabase.EndTime = EndTime;
            _taskManagerDatabase.Description = Description;
            var result = await _taskManagerDatabase.UpdateDataAsync();
            UpdateEvent?.Invoke(this, result);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
        }
    }
}
