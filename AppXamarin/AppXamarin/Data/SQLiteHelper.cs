using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppXamarin.Models;
using System.Threading.Tasks;

namespace AppXamarin.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection conn;

        public SQLiteHelper(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<User>().Wait();
            conn.CreateTableAsync<Product>().Wait();
        }

        #region User CRUD
        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id == 0)
            {
                return conn.InsertAsync(user);
            }
            else
            {
                return null;
            }
        }

        public Task<List<User>> GetUsersAsync()
        {
            return conn.Table<User>().ToListAsync();
        }

        public Task<User> Login(User user)
        {
            return conn.Table<User>().Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
        }
        
        public Task<User> AdminAccount(string email)
        {
            return conn.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }
        #endregion

        #region Product CRUD
        public Task<int> SaveProductAsync(Product product)
        {
            if (product.Id == 0)
            {
                return conn.InsertAsync(product);
            }
            else
            {
                return null;
            }
        }

        //Delete Product
        public Task<int> DeleteProductAsync(int id)
        {
            return conn.DeleteAsync<Product>(id);
        }

        public Task<List<Product>> GetProductsAsync(string categoryName)
        {
            if(categoryName.Equals("Todos")) return conn.Table<Product>().ToListAsync();
            else return conn.Table<Product>().Where(p => p.Category == categoryName).ToListAsync();
        }

        #endregion

        #region Category
        public Task<List<string>> GetCategoryNames()
        {
            var data = conn.QueryAsync<Product>("SELECT DISTINCT Category FROM Product");

            return data.ContinueWith(t =>
            {
                List<string> categories = new List<string>();
                
                categories.Add("Todos");
                
                foreach (var item in t.Result)
                {
                    categories.Add(item.Category);
                }
                return categories;
            });
        }
        #endregion
    }   
}
