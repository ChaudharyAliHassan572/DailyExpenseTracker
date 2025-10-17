using DailyExpenseTracker.Core.Models.DTOS.Users;
using DailyExpenseTracker.Core.Models.Entities;
using DailyExpenseTracker.Dal.Repository;
using DailyExpenseTracker.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace DailyExpenseTracker.NUnitTesting
{

    internal static class TestHelpers
    {
        public static DBContext CreateInMemoryContext(string? dbName = null)
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(dbName ?? Guid.NewGuid().ToString())
                .Options;
            return new DBContext(options);
        }
    }

    [TestFixture]
    public class UserRepositoryTests
    {
        [Test]
        public async Task Add_And_GetById_Works()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);

            var user = new User("repo_user", "repo_user@example.com", "Password123!");
            await repo.AddAsync(user);

            var fetched = await repo.GetByIdAsync(user.Id);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched!.Id, Is.EqualTo(user.Id));
            Assert.That(fetched.UserName, Is.EqualTo("repo_user"));
        }

        [Test]
        public async Task GetAll_Returns_All_Users()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);

            await repo.AddAsync(new User("u1", "u1@example.com", "Password123!"));
            await repo.AddAsync(new User("u2", "u2@example.com", "Password123!"));

            var all = await repo.GetAllAsync();
            Assert.That(all.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task Delete_Removes_User()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);

            var user = new User("del_user", "del_user@example.com", "Password123!");
            await repo.AddAsync(user);

            await repo.DeleteAsync(user.Id);

            var fetched = await repo.GetByIdAsync(user.Id);
            Assert.That(fetched, Is.Null);
        }
    }

    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public async Task Create_And_Get_ById_Works()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);
            var service = new UserService(repo);

            var created = await service.CreateAsync(new CreateUserRequestDto
            {
                UserName = "svc_user",
                Email = "svc_user@example.com",
                Password = "Password123!"
            });

            var fetched = await service.GetByIdAsync(created.Id);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched!.Id, Is.EqualTo(created.Id));
            Assert.That(fetched.UserName, Is.EqualTo("svc_user"));
        }

        [Test]
        public async Task Update_Changes_Email_And_Password()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);
            var service = new UserService(repo);

            var created = await service.CreateAsync(new CreateUserRequestDto
            {
                UserName = "svc_update",
                Email = "svc_update@example.com",
                Password = "Password123!"
            });

            await service.UpdateAsync(created.Id, new UpdateUserRequestDto
            {
                Email = "updated@example.com",
                Password = "NewPassword123!"
            });

            var updated = await service.GetByIdAsync(created.Id);
            Assert.That(updated, Is.Not.Null);
            Assert.That(updated!.Email, Is.EqualTo("updated@example.com"));
        }

        [Test]
        public async Task Delete_Removes_User()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);
            var service = new UserService(repo);

            var created = await service.CreateAsync(new CreateUserRequestDto
            {
                UserName = "svc_delete",
                Email = "svc_delete@example.com",
                Password = "Password123!"
            });

            await service.DeleteAsync(created.Id);

            var after = await service.GetByIdAsync(created.Id);
            Assert.That(after, Is.Null);
        }
    }

}
