using Entities.Entities;


namespace Behaviour.Interfaces
{
    public interface IUserService
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
