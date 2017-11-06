﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD04_Pfeiffer
{
    class Person
    {
        // fields
        private Person person;

        private int socialSecurityNumber;
        private string lastname;
        private string firstname;
        private DateTime birthdate = new DateTime(1980, 1, 1);

        // properties
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

        // constructor
        public Person(int socialSecurityNumber, string lastname, string firstname, DateTime birthdate)
        {
            SocialSecurityNumber = socialSecurityNumber;
            Lastname = lastname;
            Firstname = firstname;
            Birthdate = birthdate;
        }

    }
}
