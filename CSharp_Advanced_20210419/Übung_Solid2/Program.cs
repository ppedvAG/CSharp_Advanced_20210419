using System;

namespace Übung_Solid2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Bad Sample
    public class BadEmail
    {
        public void SendEmail()
        {
            // code to send mail
        }
    }

    public class BadNotification
    {
        private BadEmail _email;
        public BadNotification()
        {
            _email = new BadEmail();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }
    #endregion


    #region 

    public interface IEmail
    {
        void SendEmail();
    }
    public class Email : IEmail
    {
        public void SendEmail()
        {
            // code to send Email
        }
    }

    public interface INotification
    {
        void PromotionalNotification();
    }

    public class Notification : INotification
    {
        private IEmail _email;
        
        public Notification(IEmail email)
        {
            _email = email;
        }
        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }
    #endregion
}
