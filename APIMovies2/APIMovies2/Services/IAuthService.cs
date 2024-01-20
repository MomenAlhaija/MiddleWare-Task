using APIMovies2.Model;

namespace APIMovies2.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> getTokenAsync(TokenReguestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);

    }


}
