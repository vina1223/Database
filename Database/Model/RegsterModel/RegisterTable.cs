using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model.RegsterModel
{

    [Table("RegisterTable")]
    public class RegisterTable
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
