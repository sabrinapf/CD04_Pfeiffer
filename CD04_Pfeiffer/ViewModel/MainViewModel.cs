using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Globalization;


namespace CD04_Pfeiffer.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        #region OBSERVABLE COLLECTION: FIELD & PROPERTY
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
        #endregion

        #region RELAYCOMMANDS: FIELDS & PROPERTIES
        // relay command(using ...CommandWpf!) for add button
        private RelayCommand addBtnCommand;
        private RelayCommand loadDataBtnCommand;
        private RelayCommand saveDataBtnCommand;

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
        public RelayCommand LoadDataBtnCommand
        {
            get
            {
                return loadDataBtnCommand;
            }

            set
            {
                loadDataBtnCommand = value;
            }
        }
        public RelayCommand SaveDataBtnCommand
        {
            get
            {
                return saveDataBtnCommand;
            }

            set
            {
                saveDataBtnCommand = value;
            }
        }

        #endregion

        #region PROPERTIES & FIELDS - PERSON

        private int socialSecurityNumber;
        private string lastname = "";
        private string firstname = "";
        private DateTime birthdate = new DateTime(1980, 1, 1);

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

        #endregion

        public MainViewModel()
        {
            // for canexecute: use lambda expression => method don't has to be created (= shortcut)
            AddBtnCommand = new RelayCommand(ExecuteAddToList, () => { if (lastname.Length > 2) { return true; } else { return false; } });
            SaveDataBtnCommand = new RelayCommand(ExecuteSaveData, CanExecuteSaveData);
            LoadDataBtnCommand = new RelayCommand(ExecuteLoadData, CanExecuteLoadData);
        }

        // method: Add to list
        private void ExecuteAddToList()
        {
            persons.Add(new PersonVM(socialSecurityNumber, lastname, firstname, birthdate));
        }

        // method: Save data
        private void ExecuteSaveData()
        {
            throw new NotImplementedException();
        }
        // only enabled if ...
        private bool CanExecuteSaveData()   
        {
            throw new NotImplementedException();
        }

        // method: Load data
        private void ExecuteLoadData()
        {
            throw new NotImplementedException();
        }
        // only enabled if ...
        private bool CanExecuteLoadData()
        {
            throw new NotImplementedException();
        }     
    }
}