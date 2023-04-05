using Database.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core.Extensions;
using Database.Model.Activity;
using System.Windows.Input;
using Database.Result;

namespace Database.ViewModel.Activity
{
    public class ActivityViewModel : INotifyPropertyChanged
    {
        public ActivityDatabase _activitydatabase;
        public AddActivityViewModel _addActivity;
        


        private string _name;
        private string _date;
        private bool _complete;
        private ObservableCollection<Activitytable> _myActivity;
        public event EventHandler NavigationEvent;
        public event EventHandler<Results> UpdateEvent;

        public ObservableCollection<Activitytable> MyActivity
        {
            get { return _myActivity; }
            set
            {
                _myActivity = value;
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
        private Color _ChangeColor;
        public Color ChangeColor
        {
            get { return _ChangeColor; }
            set
            {
                _ChangeColor = value;
                if (Complete == true)
                {
                    _ChangeColor = Colors.Green;
                }
                else
                {
                    _ChangeColor = Colors.Red;
                }
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

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditButton { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public ActivityViewModel()
        {
            _activitydatabase = new ActivityDatabase();
            _activitydatabase.CreateDatabase();
           _= _activitydatabase.CreateTableAsync();
            AddCommand = new Command(NaviagtionMethod);
            DeleteCommand = new Command<Activitytable>(Delete);
            EditButton = new Command<Activitytable>((Activitytable) => { EditAsync(Activitytable); });  
        }

        public async Task EditAsync(Activitytable e)
        {
            _activitydatabase.Id = e.Id;
            var updateResult = 
            UpdateEvent?.Invoke(this, updateResult);
        }

        public async Task GetData()
        {
            var result = await _activitydatabase.GetListAsync();
            MyActivity = _activitydatabase.ActivityTable.ToObservableCollection();
            Complete = _addActivity.Complete;   
        }

        public async void Delete(Activitytable e)
        {
            var result = await _activitydatabase.DeleteAsync();
            MyActivity.Remove(e);
        }

       

        public void NaviagtionMethod()
        {
            NavigationEvent?.Invoke(this, new EventArgs());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
