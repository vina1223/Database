using Database.Model.Activity;
using Database.Result;
using SQLite;

namespace Database.Database
{
    public class ActivityDatabase
    {
        private SQLiteAsyncConnection _connection;

        public string Name { get; set; }    
        public string Date { get; set; }
        public bool Complete { get; set; }
        public int Id { get; set; }

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

        public async Task<bool> DeleteAsync()
        {
            var activitytable = new Activitytable()
            {
                Id=Id,
            };
            return await _connection.DeleteAsync(activitytable)>0;
        }

        public async Task<Results> UpdateAsync()
        {
            try
            {
                
            var list = await _connection.Table<Activitytable>().ToListAsync();

            var records = list.Where(x => x.Id == Id).FirstOrDefault();
            Name = records.Name;
            Date = records.Date;
            Complete = records.Complete;

                if (records == null)
                {
                    return new Results()
                    {
                        IsSuccess = false,
                    };
                }
                else
                {
                    return new Results()
                    {
                        IsSuccess = true,
                        Id = Id,
                    };
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
           
        }

      
    }
}
