using SQLite;

namespace Database.Model.Activity
{
    [Table("Activity")]
    public class Activitytable
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Date")]
        public string Date { get; set; }

        [Column("Complete")]
        public bool Complete { get; set; }
    }
}
