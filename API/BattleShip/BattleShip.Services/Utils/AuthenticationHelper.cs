using BattleShip.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Utils
{
    /// <summary>
    /// Classe permettant de gérer l'authentification
    /// </summary>
    public static class AuthenticationHelper
    {
        /// <summary>
        /// Secret utilisé pour l'encodage
        /// </summary>
        public const string SECRET = "b0BNpnxjoO0WeT_Zqx7tImRt";

        /// <summary>
        /// Méthode permettant de générer le Jwt pour un utilisateur
        /// </summary>
        /// <param name="user">Utilisateur pour lequel crée un token</param>
        /// <returns>Le token crée</returns>
        public static string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role.ToUpper(), user.Role.ToUpper())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET)), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    /// <summary>
    /// Classe représentant les différents rôles disponibles pour un utilisateur
    /// </summary>
    public static class UserRoles
    {
        public const string SuperAdmin = "SUPERADMIN";
        public const string Admin = "ADMIN,SUPERADMIN";
        public const string User = "USER,ADMIN,SUPERADMIN";
    }
}
