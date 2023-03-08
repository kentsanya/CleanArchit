using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchit.Presantation.MVC.AuthithicationOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "CleanArchitServer";
        public const string AUDIENCE = "CustomAuthClient";
        private const string KEY = "mycustomkey_keysurprize2468";
        public static SymmetricSecurityKey GetSecurityKey() 
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
            
    }
}
