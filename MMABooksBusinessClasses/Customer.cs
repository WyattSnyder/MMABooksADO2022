﻿using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        //instance variables

        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;

        public int CustomerID
        {
            get
            {
                return CustomerID;
            }

            set
            {
                if (value > 0)
                    customerID = value;
                else
                    throw new ArgumentOutOfRangeException("CustomerID must be a positive integer"); 
            }
        }

        public string Name
        {
            get
            {
                return name;
            } set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                    name = value;
                else
                    throw new ArgumentOutOfRangeException("Name must be at least 1 charcter and no more than a 100 characters");
            }
        }

        public string Address { 
            get 
            { 
                return address;
            }
            set 
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    address = value;
                else throw new ArgumentOutOfRangeException("Address must contain at least 1 charcter and cannot exceed 50 characters");
            } 
        }

        public string City { 
            get 
            {
                return city;
            } 
            set 
            {
                if (Char.IsUpper(value[0]))
                {
                    city = value;
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("City characters must be capitalized");
                }
            }
        }

        public string State { get
            {
                return state;
            }
            set 
            {
                if (value.Length > 0 && value.Length <= 2 && Char.IsUpper(value[0]))
                {
                    State = value;
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("Make sure State is Two Capitalized characters");
                }
            }
        }

        public string ZipCode { get 
            {
                return zipcode;
            } 
            set 
            {
                if (value.Length > 0 && value.Length <= 15)
                {
                    zipcode = value;
                }
                else 
                {
                throw new ArgumentOutOfRangeException("Zipcode must be between 1 and 15 characters");
                }
            } 
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
