using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ris2_Lab5.Lab5
{
    class Order
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int bike_id;

        private DateTime start_time;

        public DateTime Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }

        private int hours_count;

        public int Hours_count
        {
            get { return hours_count; }
            set { hours_count = value; }
        }

        public int Bike_id
        {
            get { return bike_id; }
            set { bike_id = value; }
        }
        public static List<Order> getOrderList()
        {
            List<Order> orderList = new List<Order>();

            XElement root = XElement.Load("orders.xml");
            IEnumerable<XElement> orders =
                from el in root.Elements("Order")
                select el;
            foreach (XElement el in orders)
            {
                int id = Int32.Parse(el.Element("Id").Value);
                int bike_id = Int32.Parse(el.Element("BikeId").Value);
                DateTime start_time = DateTime.Parse(el.Element("StartTime").Value);
                int hours_count = Int32.Parse(el.Element("HoursCount").Value);
                Order order = new Order(id, bike_id, start_time, hours_count);
                orderList.Add(order);
            }

            return orderList;
        }

        public String toString()
        {
            return id + ".) bike#" + bike_id + "; " + start_time + " - " + hours_count + "ч."; 
        }

        public static void SaveOrder(Order order)
        {
            XElement root = XElement.Load("orders.xml");
            root.Add(new XElement("Order",
                new XElement("Id", order.id),
                new XElement("BikeId", order.bike_id),
                new XElement("StartTime", order.start_time),
                new XElement("HoursCount", order.hours_count)));
            root.Save("orders.xml");
        }

        public Order(int id, int bike_id, DateTime start_time, int hours_count)
        {
            this.id = id;
            this.bike_id = bike_id;
            this.start_time = start_time;
            this.hours_count = hours_count;
        }
    }
}
