using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.AuthRepos
{
    public static class JwtConfig
    {
        public readonly static string ISSUER = "AuthServer";
        public readonly static string AUDIENCE = "AuthClient";
        public readonly static string KEY = "secret_key 12345678910 vnjfdavnk;fdvbhnkjdfnbvo;d";
        public readonly static int LIFETIME = 60;
    }
}
