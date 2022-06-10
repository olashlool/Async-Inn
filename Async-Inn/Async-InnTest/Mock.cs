using Microsoft.Data.Sqlite;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using Async_Inn.Data;
using Async_Inn.Models;
using System.Collections.Generic;
using System.Text;
using Async_Inn.Models.DTOs;

namespace AsyncInnTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}