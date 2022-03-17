using ContactAppBackend.Database.Models;
using ContactAppBackend.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppBackend.Services
{
    public class UserService
    {
        private readonly AppContext appContext  ;
        public UserService()
        {
            this.appContext = new AppContext();
        }
        public ActionResult<APIResult> CreateUser(CreateUserDto dto)
        {
            var result = new APIResult();

            User user = CreateUserRequestToUser(dto);

            this.appContext.Users.Add(user);
            result.Success = true;
            result.Description = "Kullanıcı kaydedildi";
            this.appContext.SaveChanges();
            return result;

        }

        public ActionResult<IEnumerable<User>> GetUsers() 
        {
            return appContext.Users.ToList();
        }

        public ActionResult<User> FindUserById(int id)
        {
            var user = this.appContext.Users.Find(id);
            Console.WriteLine(user);
            return user;
        }
        private static User CreateUserRequestToUser(CreateUserDto dto)
        {
            return new User()
            {
                Name = dto.Name,
                Surname= dto.Surname,
                Email = dto.Email, 
            };

        }

    }
}
