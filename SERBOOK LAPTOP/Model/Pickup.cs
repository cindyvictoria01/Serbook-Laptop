using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERBOOK_LAPTOP.Model
{
    class Pickup
    {
        int booking_number;
        string delivery_person, notes;

        public int Booking_number { get => booking_number; set => booking_number = value; }
        public string Delivery_person { get => delivery_person; set => delivery_person = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}
