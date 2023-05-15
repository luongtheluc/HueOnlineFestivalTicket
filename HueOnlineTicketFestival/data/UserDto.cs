using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace HueOnlineTicketFestival.data
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;


    }
}