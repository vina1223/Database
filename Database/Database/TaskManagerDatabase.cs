using Database.Model.TaskManager;
using Database.Result;
using SQLite;

namespace Database.Database
{
    public class TaskManagerDatabase
    {
        private SQLiteAsyncConnection _connection;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Id { get; set; }

        public List<TaskManagerTable> TaskListActivity { get; set; }

        // create Database
        public void CreateDatabase()
        {
            var databaseName = "TaskMagerdatabase";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(folderPath, databaseName);
            _connection = new SQLiteAsyncConnection(databasePath, true);
        }


        // Create Database Table
        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<TaskManagerTable>();
        }

        // fetch from Database
        public async Task<List<TaskManagerTable>> GetListAsync()
        {
            var results =  await _connection.Table<TaskManagerTable>().ToListAsync();
            TaskListActivity = results;
            return TaskListActivity;
        }

        // Insert into Database
        public async Task<bool> InserAsync()
        {
            var taskManager = new TaskManagerTable()
            {
                Name = Name,
                Description = Description,
                CompletionDate = Date,
                StartTime = StartTime,
                EndTime = EndTime,
            };
            return await _connection.InsertAsync(taskManager) > 0;
        }

        // Delete 
        public async Task<bool> DeleteAsync()
        {
            var activitytable = new TaskManagerTable()
            {
                Id = Id,
            };
            return await _connection.DeleteAsync(activitytable) > 0;
        }

        // Update Data to DataBase
        public async Task<Results> GetDataAsync()
        {
            try
            {
                var list = await _connection.Table<TaskManagerTable>().ToListAsync();
                var records = list.Where(x => x.Id == Id).FirstOrDefault();
                Name = records.Name;
                Description = records.Description;
                Date = records.CompletionDate;
                StartTime = records.StartTime;
                EndTime = records.EndTime;

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public async Task<bool> UpdateDataAsync()
        {
            var update = new TaskManagerTable()
            {
                Name=Name,
                Id=Id,
                Description= Description,
                CompletionDate = Date,
                StartTime = StartTime,
                EndTime = EndTime,
            };
            try
            {
                var results = await _connection.UpdateAsync(update);
                var newResults = results > 0;
                return newResults;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }


    }
}
