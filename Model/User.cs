﻿using Microsoft.Maui.Layouts;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Model
{
    public class User
    {
        private string _name;
        private string _email;
        private DateTime _dateOfBirth;
        public string Name {
            get { 
                return _name; 
            }
            set {
                if(!IsNameValid(value))
                {
                    throw new Exception("NAME INCORRECT");
                }
                _name = value;
            } 
            }
        public string Email {
            get { return _email; } 
            set {
                if(!new EmailAddressAttribute().IsValid(value)) 
                {
                    throw new Exception("EMAIL INVALID");
                }
                _email = value;
            } }
        public DateTime DateOfBirth { get{ return _dateOfBirth; }
            set {
            if(!CheckAge(value) || !IsDateOfBirthValid(value))
                {
                    throw new Exception("INVALID BIRTH DATE");
                }
            } }
        public List<string> Cities { get; set; }
        public Bitmap ProfielImage { get; set; }
        public List<User> Matches { get; set; }
        public List<Drink> Favourites { get; set; }
        public List<Drink> Likes { get; set; }
        public List<Drink> Dislikes { get; set; }

        public User(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public static bool CheckAge(DateTime date) //checkt of iemand wel 18 is
        {
            DateTime dateNow = DateTime.Now;

            if (date.AddYears(18).CompareTo(dateNow) > 0)
            {
            return false;
            }
            return true;
        }

        public static bool IsNameValid(string name)// checkt of de naam geen aparte tekens bevat en niet langer is dan 50 en niet korter dan 1
        {
            name = name.Trim();
            return (name.Length > 0 && name.Length <= 50 && name.All(char.IsLetter));
        }

        public static bool IsDateOfBirthValid(DateTime date)// checked of de datum die wordt ingevuld niet in de toekomst is.
        {
            DateTime dateNow = DateTime.Now;
            if (date > dateNow)
            {
                return false;
            }
            return true;
        }

        public User GetDummyUser() //returned een dummy user voor dummy gebruik
        {
            return new User("dummyUser", "email@email.com", new DateTime(1, 1, 1999));
        }


    }
}