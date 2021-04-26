using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERBOOK_LAPTOP.DB
{
    class Booking
    {
        int booking_number;
        string delivery_person, laptop_brand, laptop_model, accessories, damage_type, notes;

        public int Booking_number { get => booking_number; set => booking_number = value; }
        public string Delivery_person { get => delivery_person; set => delivery_person = value; }
        public string Laptop_brand { get => laptop_brand; set => laptop_brand = value; }
        public string Laptop_model { get => laptop_model; set => laptop_model = value; }
        public string Accessories { get => accessories; set => accessories = value; }
        public string Damage_type { get => damage_type; set => damage_type = value; }
        public string Notes { get => notes; set => notes = value; }
        public string Status { get; set; }
    }
}
