using DailyExpenseTracker.Core.Models.DTOS.Users;

namespace DETSoft.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto?> GetByIdAsync(Guid id);
        Task<UserResponseDto> CreateAsync(CreateUserRequestDto dto);
        Task UpdateAsync(Guid id, UpdateUserRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
