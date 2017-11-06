using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

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

        // path to file
        private string path = "C:\\Users\\Brini\\Documents\\Visual Studio 2015\\Projects\\CD04_Pfeiffer\\CD04_Pfeiffer";
        // file name
        private const string fileName = @"data.csv";

        public MainViewModel()
        {
            // for canexecute: use lambda expression => method don't has to be created (= shortcut)
            AddBtnCommand = new RelayCommand(ExecuteAddToList, () => { if (lastname.Length > 2) { return true; } else { return false; } });
            SaveDataBtnCommand = new RelayCommand(ExecuteSaveData);
            LoadDataBtnCommand = new RelayCommand(ExecuteLoadData);
        }

        // method: Add to list
        private void ExecuteAddToList()
        {
            persons.Add(new PersonVM(socialSecurityNumber, lastname, firstname, birthdate));
        }

        // method: Save data
        private void ExecuteSaveData()
        {
            // first, delete possible file
            if (File.Exists(path + fileName))
            {
                File.Delete(path + fileName);
            }
            // for every person in observable collection
            foreach (var person in Persons)
            {
                // write all properties to the file, seperated by ';'
                File.AppendAllText(path + fileName, string.Format("{0};{1};{2};{3};\n", person.SocialSecurityNumber, person.Lastname, person.Firstname, person.Birthdate));
            }
        }
        // only enabled if ...
        private bool CanExecuteSaveData()   
        {
            if (Persons.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
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
            string[] lines = File.ReadAllLines(path + fileName);

            // split the lines => get single properties for each person (repeat as often as necessary)
            foreach (var item in lines)
            {
                // split lines
                var itemValue = item.Split(';');
                // add properties to personList (ssn, lname, fname, bdate)
                personList.Add(new Person(int.Parse(itemValue[0]),itemValue[1], itemValue[2], DateTime.ParseExact(itemValue[3], "dd.MM.yyyy", CultureInfo.InvariantCulture)));
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
            if (File.Exists(path + fileName))
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