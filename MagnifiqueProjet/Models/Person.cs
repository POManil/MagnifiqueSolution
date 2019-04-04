using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnifiqueProjet.Models
{
    class Person
    {
        private string _FirstName;
        private string _LastName;
        private int _BusinessEntityID;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public int BusinessEntityID
        {
            get { return _BusinessEntityID; }
            set { _BusinessEntityID = value; }
        }


    }
}
