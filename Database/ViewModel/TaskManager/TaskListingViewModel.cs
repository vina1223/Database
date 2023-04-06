using CommunityToolkit.Maui.Core.Extensions;
using Database.Database;
using Database.Model.TaskManager;
using Database.Result;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Database.ViewModel.TaskManager
{
    public class TaskListingViewModel : INotifyPropertyChanged
    {
        private TaskManagerDatabase _taskManagerDatabase;
        private ObservableCollection<TaskManagerTable> _tasklistManager;
        public event EventHandler AddEvent;
        public event EventHandler<Results> EditDataEvent;
        public ObservableCollection<TaskManagerTable> TaskListActivity
        {
            get { return _tasklistManager; }
            set
            {
                _tasklistManager = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddTaskCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public TaskListingViewModel()
        {
            _taskManagerDatabase = new TaskManagerDatabase();
            _taskManagerDatabase.CreateDatabase();
            _=_taskManagerDatabase.CreateTableAsync();
            AddTaskCommand = new Command(AddTask);
            DeleteCommand = new Command<TaskManagerTable>(DeleteData);
            RefreshCommand = new Command(()=> { _=GetRefreshedData(); });
            EditCommand = new Command<TaskManagerTable>((TaskManagerTable) => { _ = UpDateData(TaskManagerTable); });
        }

        public async void DeleteData(TaskManagerTable e)
        {
            _taskManagerDatabase.Id = e.Id;
            var result = await _taskManagerDatabase.DeleteAsync();
            TaskListActivity.Remove(e);
        }

        public async Task UpDateData(TaskManagerTable e)
        {
            _taskManagerDatabase.Id = e.Id;
            var newResult = await _taskManagerDatabase.GetDataAsync();
            EditDataEvent?.Invoke(this, newResult);
        }

        public void AddTask()
        {
            AddEvent?.Invoke(this, new EventArgs());
        }

       public async Task GetData()
        {
            var result = await _taskManagerDatabase.GetListAsync();
            TaskListActivity = _taskManagerDatabase.TaskListActivity.ToObservableCollection();
        }

        public async Task GetRefreshedData()
        {
            IsRefreshing = true;
            var result = await _taskManagerDatabase.GetListAsync();
            TaskListActivity = _taskManagerDatabase.TaskListActivity.ToObservableCollection();
            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
