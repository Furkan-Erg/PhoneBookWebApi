using ContactAppBackend.Database.Models;
using ContactAppBackend.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppBackend.Services
{
    public class AuthService
    {
        private readonly AppContext appContext;

        public  AuthService()
        {
            appContext = new AppContext();
        }
        
        public ActionResult<LoginResponseDto> Login(LoginRequestDto dto)
        {
            var result = new LoginResponseDto();
            var user = appContext.Users.FirstOrDefault(e => e.Email == dto.Email 
            && e.Password == dto.Password);
            if (user == null)
            {
                result.Success = false;
                result.UserId = null;
                return result;
            }
            result.Success = true;
            result.UserId = user.Id;
            
            return result;
        }

        public ActionResult<APIResult> Register(CreateUserDto dto)
        {
            var result = new APIResult();

            var emailExist = appContext.Users.FirstOrDefault(e => e.Email == dto.Email);
            if (emailExist != null)
            {
                result.Success = false;
                result.Description = "Email exists";
                return result;
            }
            result.Success = true;
            result.Description = "Register operation to database is finished with success";
            var user = CreateUserRequestToUser(dto);
            appContext.Users.Add(user);
            appContext.SaveChanges();

            return result;

        }
        private static User CreateUserRequestToUser(CreateUserDto dto)
        {
            return new User()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Password=dto.Password,
            };

        }

    }
}
