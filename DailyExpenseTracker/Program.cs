using DailyExpenseTracker.Dal.Repository;
using DailyExpenseTracker.Services.Services;
using DailyExpenseTracker.Core.Models.DTOS.Users;
using Microsoft.EntityFrameworkCore;

var factory = new DBContextFactory();
using var context = factory.CreateDbContext(args);

await context.Database.EnsureCreatedAsync();

Console.WriteLine("Connected to database: " + context.Database.GetDbConnection().Database);

var userRepository = new UserRepository(context);
var userService = new UserService(userRepository);

try
{
    var unique1 = Guid.NewGuid().ToString("N").Substring(0, 8);
    var unique2 = Guid.NewGuid().ToString("N").Substring(0, 8);

    var create1 = new CreateUserRequestDto
    {
        UserName = $"tester_{unique1}",
        Email = $"tester_{unique1}@example.com",
        Password = "Password123!"
    };

    var create2 = new CreateUserRequestDto
    {
        UserName = $"tester_{unique2}",
        Email = $"tester_{unique2}@example.com",
        Password = "Password123!"
    };

    var user1 = await userService.CreateAsync(create1);
    var user2 = await userService.CreateAsync(create2);

    Console.WriteLine($"Created users:\n - {user1.Id} | {user1.UserName} | {user1.Email}\n - {user2.Id} | {user2.UserName} | {user2.Email}");

    var all = await userService.GetAllAsync();
    Console.WriteLine($"Total users now: {all.Count()}");
}
catch (Exception ex)
{
    Console.WriteLine("Error while Adding Users: " + ex.Message);
    Console.WriteLine(ex.ToString());
}
