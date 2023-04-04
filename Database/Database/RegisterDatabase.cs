using Database.Model.RegsterModel;
using Database.Result;
using SQLite;
namespace Database.Database
{
    public class RegisterDatabase
    {
        private SQLiteAsyncConnection _connection;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginUser { get; set; }
        public string LoginPassword { get; set; }
        public int  Id { get; set; }

        public void CreateDatabase()
        {
            var databaseName = "Table";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(folderPath, databaseName);
            _connection = new SQLiteAsyncConnection(databasePath, true);
        }

        public async Task CreateTableAsync()
        {
            try
            {
                var result = await _connection.CreateTableAsync<RegisterTable>();
                Console.WriteLine(result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        public async Task<Results> GetListAsync()
        {
           
                var lists = await _connection.Table<RegisterTable>().ToListAsync();
                var validate = lists.Where(x => x.Password == LoginPassword && x.UserName == LoginUser).FirstOrDefault();
            if (validate == null)
            {
                return new Results()
                {
                    IsSuccess = false,
                    Message = "Login Fail"
                };
            }

            else
            {
                return new Results()
                {
                    IsSuccess = true,
                    Id = validate.Id,
                };
            }
        }

        public async Task ValidateId()
        {
            var list = await _connection.Table<RegisterTable>().ToListAsync();
            var validateId = list.Where(x => x.Id == Id).FirstOrDefault();
            UserName = validateId.UserName;
            
        }

        public async Task<bool> InsertDataAsync()
        {
            var registerTable = new RegisterTable()
            {
                UserName = UserName,
                Password = Password,   
            };
            try
            {
                var insertrecord = await _connection.InsertAsync(registerTable);
                var result = insertrecord >0; 
                return result;
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
