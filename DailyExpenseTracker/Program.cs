using DailyExpenseTracker.Dal.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

// 1. Load appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// 2. Get connection string
var connectionString = configuration.GetConnectionString("DefaultConnection");

// 3. Build DbContextOptions
var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
optionsBuilder.UseSqlServer(connectionString);

// 4. Create DbContext
using var context = new DBContext(optionsBuilder.Options);

// Test: ensure it connects
Console.WriteLine("Connected to database: " + context.Database.GetDbConnection().Database);
