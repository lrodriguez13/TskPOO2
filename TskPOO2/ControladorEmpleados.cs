using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace TskPOO2
{
    class ControladorEmpleados
    {
        //try
        //catch()
        //finally -- sirve para cerrar conexiones de datos, archivos
        public Empleado Alta()
        {
            string nombre = "";
            string apellido = "";
            DateTime ingreso = DateTime.Now;
            float salario = 0.0f;

            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            apellido = Console.ReadLine();
            Console.Write("Fecha de Ingreso: ");
            try
            {
                ingreso = DateTime.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ingreso = DateTime.Now;
            }
            Console.Write("Salario: ");
            try
            {
                salario = float.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                salario = 0.0f;
            }

            //Parse | Cast significa convertir entre tipos de datos
            //TipoDato.parse("valor") | (DateTime)"valor"
            //Instancia de un objecto
            //Nombre de la clase -- nombre del objeto = new -- constructor ()
            Empleado e1 = new Empleado(nombre, apellido, ingreso, salario);
            return e1;
        }
        public void GuardarEmpleado(Empleado e1)
        {
            //Crear un archivo de escritura
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\empleados.txt", true))
            {
                try
                {
                    //escribir en el archivo
                    sw.WriteLine(e1.ToString() + "|" + e1.calcularAntiguedad() + "|" + e1.quitarImpuestos(16));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //cerrar el archivo
                    sw.Close();
                }
            }
        }

        public void GuardarEmpleado(Empleado e1, bool bd)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    //origen -- a donde me voy a conecter
                    //catalogo -- base de datos, ejemplo a un ambiente
                    //credenciales
                    //Instruccion
                    string sqlInsert = "INSERT INTO EMPLEADO(Nombre, Apellido, FechaIngreso, Salario)";
                    sqlInsert = sqlInsert + "values('" 
                        + e1.Nombre +"','"
                        + e1.Apellido +"',convert(datetime,'"
                        + e1.FechaIngreso +"'),"
                        + e1.Salario
                        +")";
                    //Comando
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    conn.Open();
                    //Ejecucion
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
             }

        }

        public void ListarEmpleado()
        {
            //Using es una palabra reservada 
            using (StreamReader sr = new StreamReader(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\empleados.txt")) //Se abre el archivo
            {
                try
                {
                    Console.WriteLine(sr.ReadToEnd()); //Intento escribir
                }
                catch(Exception ex)  //cacha el error
                {
                    Console.WriteLine(ex.Message);  //escribe el mensaje al usuario
                }
                finally
                {
                    sr.Close(); //cierra el archivo
                }
            }
            //abrir y leer un archivo
            //StreamReader sr = new StreamReader(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\empleados.txt");
        }
    }
}
