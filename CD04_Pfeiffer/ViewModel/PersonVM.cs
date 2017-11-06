using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
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

        private int socialSecurityNumber;
        private string lastname;
        private string firstname;
        private DateTime birthdate;

        // properties (incl RaisePropertyChanged("...") to make changes visible;
        // Social Security Number
        public int SocialSecurityNumber
        {
            get
            {
                return socialSecurityNumber;
            }

            set
            {
                socialSecurityNumber = value;
                RaisePropertyChanged("SocialSecurityNumber");
            }
        }

        // Lastname        
        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
                RaisePropertyChanged("Lastname");
            }
        }

        // Firstname       
        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
                RaisePropertyChanged("Firstname");
            }
        }

        // Birthdate       
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                birthdate = value;
                RaisePropertyChanged("Birthdate");
            }
        }


        // constructor
        public PersonVM(int socialSecurityNumber, string lastname, string firstname, DateTime birthdate)
        {
            this.person = new Person(socialSecurityNumber, lastname, firstname, birthdate);
        }
    }
}
