using Application.Bases;

namespace Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException:BaseException
    {
        public UserAlreadyExistException() :base("Aynı kullanıcı bilgilerine sahip kullanıcı bulunmaktadır.!") { }
    }
}
