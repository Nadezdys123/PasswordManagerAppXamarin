using System.Collections.Generic;
using System.Threading.Tasks;
using PasswordManagerApp.Models;
using SQLite;

namespace PasswordManagerApp
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DataClass>().Wait();
        }

        public Task<List<DataClass>> GetDataAsync()
        {
            return _database.Table<DataClass>().ToListAsync();
        }

        public Task<int> SaveDataAsync(DataClass data)
        {
            return _database.InsertAsync(data);
        }
    }
}