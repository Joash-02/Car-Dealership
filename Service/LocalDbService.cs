using CarDealership.Database;
using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Service
{
    public class LocalDbService
    {
        private const string DB_NAME = "userdatabase.db3";
        private readonly SQLiteAsyncConnection _connection;


        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Users>();
            _connection.CreateTableAsync<Car>().Wait();
        }

        public async Task<List<Users>> GetUsers()
        {
            return await _connection.Table<Users>().ToListAsync();
        }

        public async Task<Users> GetById(int id)
        {
            return await _connection.Table<Users>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create (Users users)
        {
            await _connection.InsertAsync(users);
        }

        public async Task Update(Users users)
        {
            await _connection.UpdateAsync(users);
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return await _connection.Table<Users>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCars()
        {
            return await _connection.Table<Car>().ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _connection.Table<Car>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateCar(Car cars)
        {
            await _connection.InsertAsync(cars);
        }

        public async Task UpdateCar(Car cars)
        {
            await _connection.UpdateAsync(cars);
        }

        public async Task DeleteCar(Car cars)
        { 
        await _connection.DeleteAsync(cars);
        }

    }
}
