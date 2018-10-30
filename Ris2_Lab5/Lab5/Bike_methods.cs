using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ris2_Lab5.Lab5
{
    partial class Bike : Item
    {
        private readonly Double price_per_hour = 3;
        private const Double penalty_per_minute = 0.1;
        

        public Double Price_per_hour
        {
            get { return price_per_hour; }
        } 

        public String toString()
        {
            return id + ". " + model + " (" + type + ") - " + person_age;
        }

        public Double Price()
        {
            Double price = 0;
            return price;
        }

        public String FullInfo()
        {
            String full_info = "";
            return full_info;
        }

        public static List<Bike> getBikeList()
        {
            List<Bike> bikeList = new List<Bike>(); 

            XElement root = XElement.Load("bikes.xml");
            IEnumerable<XElement> bikes =
                from el in root.Elements("Bike")
                select el;
            foreach (XElement el in bikes)
            {
                int id = Int32.Parse(el.Element("Id").Value);
                String model = el.Element("Model").Value;
                String type = el.Element("Type").Value;
                String person_age = el.Element("PersonAge").Value;
                Bike bike = new Bike(id, model, type, person_age);
                bikeList.Add(bike);
            }

            return bikeList;
        }
    }
}
