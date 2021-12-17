using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lect10.Models
{
    public class Item
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
