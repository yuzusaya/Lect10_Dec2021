using Lect10.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lect10.Services
{
    public static class Constants
    {
        public const string DatabaseFilename = "ItemDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;
        public ItemDatabase()
        {
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemByIdAsync(int id)
        {
            return database.Table<Item>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> AddOrUpdateItemAsync(Item item)
        {
            if(item.Id == 0)
            {
                return database.InsertAsync(item);
            }
            return database.UpdateAsync(item);
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
    }
}
