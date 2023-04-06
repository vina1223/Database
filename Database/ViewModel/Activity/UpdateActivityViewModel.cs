using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Database.Database;
using Database.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database.ViewModel.Activity
{
    public class UpdateActivityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ActivityDatabase _activtityDatatbase;
        public event EventHandler<bool> UpdateEvent;


        private string _name;
        private string _date;
        private bool _complete;
        private int _id;


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

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
            
        }

        public ICommand UpdateActivityCommand { get; private set;}

        public UpdateActivityViewModel()
        {
            _activtityDatatbase = new ActivityDatabase();
            _activtityDatatbase.CreateDatabase();
            _ = _activtityDatatbase.CreateTableAsync();
            UpdateActivityCommand = new Command(()=> { _=UpdateData(); });
        }

        public async Task DisplayDetails()
        {
            _activtityDatatbase.Id = Id;
            await _activtityDatatbase.GetDataAsync();
            Name = _activtityDatatbase.Name;
            Date = _activtityDatatbase.Date;
            Complete = _activtityDatatbase.Complete;
        }

        public async Task UpdateData()
        {
            _activtityDatatbase.Name = Name;
            _activtityDatatbase.Date = Date;
            _activtityDatatbase.Complete = Complete;
            _activtityDatatbase.Id =Id;
            var result = await _activtityDatatbase.UpdateAsync();
            UpdateEvent?.Invoke(this, result);  
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));  
        }    
    }
}
