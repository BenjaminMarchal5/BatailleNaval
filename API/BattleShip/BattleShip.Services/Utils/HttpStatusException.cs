using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Services.Utils
{
    /// <summary>
    /// Classe représentant les exceptions liées aux codes http
    /// </summary>
    public class HttpStatusException : Exception
    {
        /// <summary>
        /// Code de statut http
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Constructeur permettant de crée un code de réponse http
        /// </summary>
        /// <param name="statusCode">Nombre correspondant au code</param>
        /// <param name="message">Message à associer au code http</param>
        public HttpStatusException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
