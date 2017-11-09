using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
        private String birthdate;

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

        public String Birthdate
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

        // path to file incl. file name
        private const string file = @"data.csv";
        
        public MainViewModel()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // for canexecute: use lambda expression => method don't has to be created (= shortcut)
            AddBtnCommand = new RelayCommand(ExecuteAddToList, () => { if (lastname.Length > 2) { return true; } else { return false; } });
            SaveDataBtnCommand = new RelayCommand(ExecuteSaveData, CanExecuteSaveData);
            LoadDataBtnCommand = new RelayCommand(ExecuteLoadData, CanExecuteLoadData);
        }

        // method: Add to list
        private void ExecuteAddToList()
        {
            persons.Add(new PersonVM(socialSecurityNumber, lastname, firstname, DateTime.Parse(birthdate)));
        }

        // method: Save data
        private void ExecuteSaveData()
        {
            // first, delete possible file
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            // for every person in observable collection
            foreach (var person in Persons)
            {
                // write all properties to the file, seperated by ';'
                File.AppendAllText(file, string.Format("{0};{1};{2};{3};\n", person.SocialSecurityNumber, person.Lastname, person.Firstname, person.Birthdate));
            }
        }
        // only enabled if ...
        private bool CanExecuteSaveData()
        {
            if (Persons.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // method: Load data
        private void ExecuteLoadData()
        {
            // first, clear observable collection Persons
            Persons.Clear();
            // create new list of type person, name = personList
            List<Person> personList = new List<Person>();

            // Read each line (equals the dataset of a person) of the file into a string array. Each element of the array is one line of the file.
            String[] lines = File.ReadAllLines(file);

            // split the lines => get single properties for each person (repeat as often as necessary)
            foreach (var item in lines)
            {
                // split lines
                var itemValue = item.Split(';');

                // add properties to personList (ssn, lname, fname, bdate)
                personList.Add(new Person(int.Parse(itemValue[0]), itemValue[1], itemValue[2], DateTime.Parse(itemValue[3])));
            }
            // for every person in the list repeat:
            foreach (var person in personList)
            {
                // add person to observable collection (created already in the beginning)
                Persons.Add(new PersonVM(person.SocialSecurityNumber, person.Lastname, person.Firstname, person.Birthdate));
            }
        }
        // only enabled if ...
        private bool CanExecuteLoadData()
        {
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}