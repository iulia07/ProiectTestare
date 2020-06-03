using FinalProject.PageObjects.BusinessObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.PageObjects
{
    public class Product
    {
        

        public Product(ProductCategory productCategory,string productName)
        {
            ProductCategory = productCategory;
            ProductName = productName;
        }

        public ProductCategory ProductCategory { get; set; }
        public string ProductName { get; set; }

       
    }
}
