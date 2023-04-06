using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model.TaskManager
{
    [Table("TaskManager")]
    public class TaskManagerTable
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("completiondate")]
        public string CompletionDate { get; set; }

        [Column("starttime")]
        public string StartTime { get; set; }

        [Column("endtime")]
        public string EndTime { get; set; }
    }
}
