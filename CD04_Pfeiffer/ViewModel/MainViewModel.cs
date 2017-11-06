using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Globalization;


namespace CD04_Pfeiffer.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        // observable collection => store person data
        private ObservableCollection<PersonVM> persons = new ObservableCollection<PersonVM>();
        // (make PersonVM public!)
        public ObservableCollection<PersonVM> Persons
        {
            get
            {
                return persons;
            }

            set
            {
                persons = value;
            }
        }

        // relay command(using ...CommandWpf!) for add button
        private RelayCommand addBtnCommand;
        private int socialSecurityNumber;
        private string lastname ="";
        private string firstname ="";
        private DateTime birthdate;
        
        //properties
        public RelayCommand AddBtnCommand
        {
            get
            {
                return addBtnCommand;
            }
            set
            {
                addBtnCommand = value;
            }
        }

        public int SocialSecurityNumber
        {
            get
            {
                return socialSecurityNumber;
            }

            set
            {
                socialSecurityNumber = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                birthdate = value;
            }
        }

        public MainViewModel()
        {
            // for canexecute: use lambda expression => method don't has to be created (= shortcut)
            AddBtnCommand = new RelayCommand(ExecuteAddToList, () => { if (lastname.Length > 2) { return true; } else { return false; } });
        }

        private void ExecuteAddToList()
        {
            persons.Add(new PersonVM(socialSecurityNumber, lastname, firstname, birthdate));
        }
    }
}