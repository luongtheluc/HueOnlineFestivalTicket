using System.Text;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using HueOnlineTicketFestival.Models;
using System.Security.Cryptography;

namespace HueOnlineTicketFestival.Prototypes
{
    public class jwtHandler
    {

        public jwtHandler()
        {

        }

        public static string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}