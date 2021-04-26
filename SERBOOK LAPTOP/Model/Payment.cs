using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERBOOK_LAPTOP.Model
{
    class Payment
    {
        int booking_number;
        string payment_method, account_name, email_address;

        public int Booking_number { get => booking_number; set => booking_number = value; }
        public string Payment_method { get => payment_method; set => payment_method = value; }
        public string Account_name { get => account_name; set => account_name = value; }
        public string Email_address { get => email_address; set => email_address = value; }
    }
}
