//Librerias
using System;                       
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Espacio de nombres -- name space --contenedor del proyecto
namespace TskPOO2
{
    class Program  //clase principal
    {
        static void Main(string[] args) //metodo principal
        {
            Menu menu = new Menu();
            ControladorEmpleados ce = new ControladorEmpleados();
            ControladorProyectos cp = new ControladorProyectos();

            //(menu.show()==1)? Empleado e1 = ce.Alta() : Proyecto p1 = cp.Alta();
            //if(menu.show() == 1)
            //{
            //    Empleado e1 = ce.Alta();
            //}
            //else
            //{
            //    Proyecto p1 = cp.Alta();
            //}
            switch (menu.show())
            {
                case 1: Empleado e1 = ce.Alta();
                    ce.GuardarEmpleado(e1);
                    ce.GuardarEmpleado(e1, true);
                    ce.ListarEmpleado();
                    break;
                case 2: Proyecto p1 = cp.Alta();
                    cp.GuardarProyecto(p1);
                    cp.GuardarProyecto(p1, true);
                    cp.ListarProyecto();
                    break;
                case 3:
                    cp.AsignarEmpleados();
                    break;
            }

           Console.ReadLine();
        }
    }


}
