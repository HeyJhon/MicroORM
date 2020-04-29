using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDapper
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNac { get; set; }

        public string Direccion { get; set; }

        public string CodigoPostal { get; set; }
    }
}
