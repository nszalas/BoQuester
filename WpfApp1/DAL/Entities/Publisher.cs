using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DAL.Entities
{
    class Publisher
    {
        public sbyte? Publisher_id { get; set; }
        public string Name { get; set; }

        public Publisher(MySqlDataReader reader)
        {
            Publisher_id = sbyte.Parse(reader["publisher_id"].ToString());
            Name = reader["name"].ToString();
        }
        public Publisher(string name)
        {
            Publisher_id = null;
            Name = name.Trim();
        }

        public Publisher(Publisher publisher)
        {
            Publisher_id = publisher.Publisher_id;
            Name = publisher.Name;
        }


    }
}
