using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ris2_Lab5.Lab5
{
    partial class Bike : Item
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String model;

        public String Model
        {
            get { return model; }
            set { model = value; }
        }
        private String type;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        private String person_age;

        public String Person_age
        {
            get { return person_age; }
            set { person_age = value; }
        }

        public Bike(int id, string model, string type, string person_age)
        {
            this.id = id;
            this.model = model;
            this.type = type;
            this.person_age = person_age;
        }
    }
}
