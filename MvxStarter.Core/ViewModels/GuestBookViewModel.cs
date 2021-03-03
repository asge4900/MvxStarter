using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxStarter.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MvxStarter.Core.ViewModels
{
    public class GuestBookViewModel : MvxViewModel
    {
        private ObservableCollection<PersonModel> people = new ObservableCollection<PersonModel>();
       
        private string firstName;

        private string lastName;

        public GuestBookViewModel()
        {
            AddGuestCommand = new MvxCommand(AddGuest);                
        }


        public ObservableCollection<PersonModel> People
        {
            get => people;
            set => SetProperty(ref people, value);
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public bool CanAddGuest => FirstName?.Length > 0 && LastName?.Length > 0;

        public IMvxCommand AddGuestCommand { get; set; }


        public void AddGuest()
        {
            PersonModel p = new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName
            };

            FirstName = string.Empty;
            LastName = string.Empty;

            People.Add(p);
        }
    }
}
