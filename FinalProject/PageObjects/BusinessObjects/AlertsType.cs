using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.PageObjects.BusinessObjects
{
    public class AlertsType
    {
        //declarare mesaj pentru fiecare tip de alerta intalnita 
        public string WrongPasswordAlert => "Wrong password.";
        public string UserAlreadyExistsAlert => "This user already exist.";
        public string SignUpSuccessfullAlert => "Sign up successful.";
        public string ProductAddedSuccessfully => "Product added.";
        public string EnterRequiredFields => "Please fill out Name and Creditcard.";
        public string MessageSentSuccessfully => "Thanks for the message!!";
    }
}
