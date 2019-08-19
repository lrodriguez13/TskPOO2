using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TskPOO2
{
    class Menu
    {
        public int show()
        {
            int opc = 0;

            do
            {
                Console.WriteLine("1. Empleados");
                Console.WriteLine("2. Proyectos");
                Console.WriteLine("3. Asignaciones");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona la opcion deseada: "); //Escribe sobre la misma linea
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    if (opc > 0 && opc < 5) ; else Console.WriteLine("Opcion no valida.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (opc < 1 || opc > 4);
            return opc;
        }
    }
}
