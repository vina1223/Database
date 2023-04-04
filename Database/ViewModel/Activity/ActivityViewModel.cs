using Database.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core.Extensions;
using System.Text;
using System.Threading.Tasks;
using Database.Model.Activity;
using System.Windows.Input;

namespace Database.ViewModel.Activity
{
    public class ActivityViewModel : INotifyPropertyChanged
    {
        public ActivityDatabase _activitydatabase;
       


        private string _name;
        private string _date;
        private bool _complete;
        private ObservableCollection<Activitytable> _myActivity;
        public event EventHandler NavigationEvent;

        public ObservableCollection<Activitytable> MyActivity
        {
            get { return _myActivity; }
            set
            {
                _myActivity = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; private set; }

        public ActivityViewModel()
        {
            _activitydatabase = new ActivityDatabase();
            _activitydatabase.CreateDatabase();
           _= _activitydatabase.CreateTableAsync();
            AddCommand = new Command(NaviagtionMethod);

        }

        public async Task GetData()
        {
            var result = await _activitydatabase.GetListAsync();
            MyActivity = _activitydatabase.ActivityTable.ToObservableCollection();
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
