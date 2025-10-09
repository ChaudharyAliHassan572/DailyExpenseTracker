using DETSoft.Core.Services;
using DETSoft.Core.Repository;
using DailyExpenseTracker.Core.Models.DTOS.Users;
using DailyExpenseTracker.Core.Models.Entities;

namespace DailyExpenseTracker.Services.Services
{
        public class UserService : IUserService
        {
            private readonly IUserRepository _repo;

            public UserService(IUserRepository repo)
            {
                _repo = repo;
            }

            public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
            {
                var users = await _repo.GetAllAsync();
                return users.Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email
                });
            }

            public async Task<UserResponseDto?> GetByIdAsync(Guid Id)
            {
                var u = await _repo.GetByIdAsync(Id);
                return u == null ? null : new UserResponseDto { Id = u.Id, UserName = u.UserName, Email = u.Email };
            }

            public async Task<UserResponseDto> CreateAsync(CreateUserRequestDto dto)
            {
                var user = new User(dto.UserName, dto.Email, dto.Password);
                await _repo.AddAsync(user);
                return new UserResponseDto { Id = user.Id, UserName = user.UserName, Email = user.Email };
            }

            public async Task UpdateAsync(Guid Id, UpdateUserRequestDto dto)
            {
                var user = await _repo.GetByIdAsync(Id);
                if (user == null) throw new Exception("User not found");
                user.UpdateEmail(dto.Email ?? user.Email);
                user.UpdatePassword(dto.Password ?? user.PasswordHash);
                await _repo.UpdateAsync(user);
            }

            public async Task DeleteAsync(Guid Id)
            {
                await _repo.DeleteAsync(Id);
            }
        }
}
