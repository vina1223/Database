using Database.Model.Activity;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Database.Database
{
    public class ActivityDatabase
    {
        private SQLiteAsyncConnection _connection;

        public string Name { get; set; }    
        public string Date { get; set; }
        public bool Complete { get; set; }

        public List<Activitytable> ActivityTable { get; set; }

        public void CreateDatabase()
        {
            var databaseName = "Activity";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(folderPath, databaseName);
             _connection = new SQLiteAsyncConnection(databasePath, true);
        }

        public async Task CreateTableAsync()
        {
            try
            {
                var result = await _connection.CreateTableAsync<Activitytable>();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        //Fetch 
        public async Task<List<Activitytable>> GetListAsync()
        {
            var results = await _connection.Table<Activitytable>().ToListAsync();
            ActivityTable = results;
            return ActivityTable;  
        }

        public async Task<bool> InsertAsync()
        {
            var activitytable = new Activitytable()
            {
                Name = Name,
                Date = Date,
                Complete = Complete,
            };
            try
            {
                var res = await _connection.InsertAsync(activitytable);
                var Tm = res > 0;
                return Tm;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
          

        }
    }
}
