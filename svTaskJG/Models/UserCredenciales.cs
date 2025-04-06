using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svTaskJG.Models
{
    public class UserCredenciales
    {
        public int id { get; set; }
        public string tokenDeAcceso { get; set; }
        public string tipoDeToken { get; set; }
        public string mensaje { get; set; }
    }
}
