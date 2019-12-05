using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA_APP
{
    public static class AuthHelper
    {
        private static string Password = "password";

        public static bool validate(string value) {
            return value == Password;
        }
    }
}
