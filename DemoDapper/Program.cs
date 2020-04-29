using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Consulta cc = new Consulta();

            //Crear Cliente
            Cliente cliente = new Cliente()
            {
                Nombre = "Andres",
                ApellidoPaterno = "Santos",
                ApellidoMaterno = "Gutierrez"

            };
            //Insertar Cliente
            cc.InsertarSP(cliente);


            IEnumerable<Cliente> lista = cc.ListarCliente();       

            foreach (var item in lista)
            {
                Console.WriteLine(item.IdCliente + ": " + item.Nombre + " " + item.ApellidoPaterno);
            }
            
            Console.ReadKey();
        }
    }
}
