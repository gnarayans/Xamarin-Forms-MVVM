using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleMVVM.Models;
using Xamarin.Forms;

namespace SimpleMVVM.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
        }

        private User user = new User();

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (User.Username == "admin" && User.Password == "admin")
                    {
                        App.Current.MainPage.DisplayAlert("Notification", "Successfully Login", "Okay");
                        // Open next page
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Notification", "Error Login", "Okay");
                    }
                });
            }
        }
       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
