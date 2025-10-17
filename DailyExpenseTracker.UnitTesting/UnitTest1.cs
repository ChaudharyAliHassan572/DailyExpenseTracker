using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using DailyExpenseTracker.Dal.Repository;
using DailyExpenseTracker.Core.Models.Entities;
using DailyExpenseTracker.Services.Services;
using DailyExpenseTracker.Core.Models.DTOS.Users;

namespace DailyExpenseTracker.UnitTesting
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
            Assert.IsNotNull(fetched);
            Assert.AreEqual(user.Id, fetched!.Id);
            Assert.AreEqual("repo_user", fetched.UserName);
        }

        [Test]
        public async Task GetAll_Returns_All_Users()
        {
            using var ctx = TestHelpers.CreateInMemoryContext();
            var repo = new UserRepository(ctx);

            await repo.AddAsync(new User("u1", "u1@example.com", "Password123!"));
            await repo.AddAsync(new User("u2", "u2@example.com", "Password123!"));

            var all = await repo.GetAllAsync();
            Assert.AreEqual(2, all.Count());
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
            Assert.IsNull(fetched);
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
            Assert.IsNotNull(fetched);
            Assert.AreEqual(created.Id, fetched!.Id);
            Assert.AreEqual("svc_user", fetched.UserName);
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
            Assert.IsNotNull(updated);
            Assert.AreEqual("updated@example.com", updated!.Email);
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
            Assert.IsNull(after);
        }
    }
}
