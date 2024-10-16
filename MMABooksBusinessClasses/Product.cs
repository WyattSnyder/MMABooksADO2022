using System;
using System.Collections.Generic;
using System.Text;

using MMABooksBusinessClasses;



namespace MMABooksBusinessClasses
{

    public class Product
    {
        //public Func<string?> productCode { get; set; }

        public Product() { }
        public Product(string productCode, String description, string unitPrice, int onHandsQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandsQuantity = onHandsQuantity;
        }

        //instance variables
        private string productCode;
        private string description;
        private string unitPrice;
        private int onHandsQuantity;

        public string ProductCode {
            get 
            { 
                return productCode;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 10)
                    productCode = value;
                else
                    throw new ArgumentException("Product code must contain between 1 and 10 charcters");
            }
        }
        public string Description {
            get
            {
                return description;
            }
            set
            {
                if (value.Length < 50)
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentException("Description must contain nor more than 50 characters");
                }       
            }
        }
        public string UnitPrice 
        { 
            get
            { 
                return unitPrice;
            } 
            set 
            {
                if (unitPrice.Length > 0)
                {
                    unitPrice = value;
                }
                else 
                {
                    throw new ArgumentException("Price must be above $0.00");
                }
            }
        }

        public int OnHandsQuantity 
        { 
            get 
            {
                return onHandsQuantity;
            }
            set 
            {
                if(onHandsQuantity > 0) 
                {
                    onHandsQuantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Quantity is out of stock");
                }
            }
        }

        

        public override string ToString()
        {
            return base.ToString();
        }
        
       
    }
}

