using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.PageObjects.BusinessObjects
{
    public class AddOrderElements
    {
        //declarare valori pentru inserare in formularul de comanda
        public string Name { get; set; } = "Automation";
        public string City { get; set; } = "Iasi";
        public string Country { get; set; } = "Romania";
        public string CreditCard { get; set; } = "500500500";
        public string Month { get; set; } = "12";
        public string Year { get; set; } = "2025";

    }
}
