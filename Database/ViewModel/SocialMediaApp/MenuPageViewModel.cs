using Database.Model.SocialMediaApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database.ViewModel.SocialMediaApp
{
    public class MenuPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuPageModel> MyItem { get; set; }

        private string _name;
        private ImageSource _image;
        private Color _profile;
        public string Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Image 
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }
        public Color Profile 
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickChange { get; private set; }

        public MenuPageViewModel()
        {
            ClickChange = new Command(BackgroundChanged);
            MyItem = new ObservableCollection<MenuPageModel>
           {
               new MenuPageModel
               {
                   Image = "profile",
                   Name = "Profile"
               },
               new MenuPageModel
               {
                   Image ="message",
                   Name ="Message",
               },
               new MenuPageModel
               {
                   Image ="activity",
                   Name = "Activity",
               },
               new MenuPageModel
               {
                   Image ="list",
                   Name= "List",
               },
           };
        }

        public void BackgroundChanged()
        {
            if(ClickChange.Equals(true))
            {
                Name = Colors.White.ToString();
                Profile = Colors.SkyBlue;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
