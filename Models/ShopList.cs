using System;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace Vieru_Marina_Lab7.Models
{
    public class ShopList
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]

        public string Description { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Shop))]
        public int ShopID { get; set; }
    }
}
