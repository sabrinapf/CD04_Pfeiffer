using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD04_Pfeiffer.ViewModel
{
    // make it public
    public class PersonVM : ViewModelBase
    {
        // fields
        private Person person;

        //private int socialSecurityNumber;
        //private string lastname;
        //private string firstname;
        //private DateTime birthdate;

        // properties (incl RaisePropertyChanged("...") to make changes visible;
        // Social Security Number
        public int SocialSecurityNumber
        {
            get
            {
                return person.SocialSecurityNumber;
            }

            set
            {
                person.SocialSecurityNumber = value;
                RaisePropertyChanged("SocialSecurityNumber");
            }
        }

        // Lastname        
        public string Lastname
        {
            get
            {
                return person.Lastname;
            }

            set
            {
                person.Lastname = value;
                RaisePropertyChanged("Lastname");
            }
        }

        // Firstname       
        public string Firstname
        {
            get
            {
                return person.Firstname;
            }

            set
            {
                person.Firstname = value;
                RaisePropertyChanged("Firstname");
            }
        }

        // Birthdate       
        public DateTime Birthdate
        {
            get
            {
                return person.Birthdate;
            }

            set
            {
                person.Birthdate = value;
                RaisePropertyChanged();
            }
        }


        // constructor
        public PersonVM(int socialSecurityNumber, string lastname, string firstname, DateTime birthdate)
        {
            this.person = new Person(socialSecurityNumber, lastname, firstname, birthdate);
        }
    }
}
