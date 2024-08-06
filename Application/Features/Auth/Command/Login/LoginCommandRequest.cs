using MediatR;
using System.ComponentModel;

namespace Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        //deneme yapılırken her zaman yazmamak için default değer veriliyor
        [DefaultValue("ercan@mail.com")]
        public string Email { get; set; }
        [DefaultValue("123456")]
        public string Password { get; set; }
    }
   
}
