using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO.Database;
using ToolBox.ADO.Mapper;

namespace Services
{
    public class PersonRepository
    {
        private readonly Connection conn;

        public PersonRepository()
        {
            conn = new Connection(@"Data Source=FORMA203\TFTIC;Initial Catalog=AdventureWorks2008R2;User ID=sa;Password=tftic@2012;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", "System.Data.SqlClient");
        }

        public IEnumerable<Person> GetAll()
        {
            Command cmd = new Command("select BusinessEntityID, LastName, FirstName from Person.Person");
            return conn.ExecuteReader(cmd, ReaderToEntityMapper.ReaderTo<Person>);
        }
    }
}
