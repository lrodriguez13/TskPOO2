//Librerias
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
    internal class ControladorProyectos
    {
        public Proyecto Alta()
        {
            string nombre = "";
            string descripcion = "";
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now;
            float presupuesto = 0.0f;
            int devs = 0;
            int qas = 0;

            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Descripcion: ");
            descripcion = Console.ReadLine();
            Console.Write("Fecha de Inicio: ");
            try
            {
                fechaInicio = DateTime.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                fechaInicio = DateTime.Now;
            }
            Console.Write("Fecha Final: ");
            try
            {
                fechaFin = DateTime.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                fechaFin = DateTime.Now;
            }
            Console.WriteLine("Presupuesto: ");
            try
            {
                presupuesto = float.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                presupuesto = 0.0f;
            }
            Console.WriteLine("Numero de Dev's: ");
            try
            {
                devs = int.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                devs = 0;
            }
            Console.WriteLine("Numero de QA's: ");
            try
            {
                qas = int.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                qas = 0;
            }

            //Parse | Cast significa convertir entre tipos de datos
            //TipoDato.parse("valor") | (DateTime)"valor"
            //Instancia de un objecto
            //Nombre de la clase -- nombre del objeto = new -- constructor ()
            Proyecto p1 = new Proyecto(nombre, descripcion, fechaInicio, fechaFin, presupuesto, devs, qas);
            return p1;
        }

        public void AsignarEmpleados()
        {
            int IdProyecto=0, IdEmpleado=0;
            Console.Write("Ingresa el Id del Proyecto: ");
            try
            {
                IdProyecto = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Ingresa el Id del Empleado: ");
            try
            {
                IdEmpleado = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            GuardarAsignacion(IdProyecto, IdEmpleado);
            Console.WriteLine("Asignacion realizada.");
        }

        public void GuardarAsignacion(int idProyecto, int idEmpleado)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    string sqlInsert = "INSERT INTO EMPLEADOSPROYECTO(Id_Proyecto, Id_Empleado)";
                    sqlInsert = sqlInsert + "values("
                        + idProyecto + ","
                        + idEmpleado + ")";

                    //Comando
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    conn.Open();
                    //Ejecucion
                    cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void GuardarProyecto(Proyecto p1)
        {
            //Crear un archivo de escritura
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\proyectos.txt", true))
            {
                try
                {
                    //escribir en el archivo
                    sw.WriteLine(p1.ToString());
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

        public void GuardarProyecto(Proyecto p1, bool bd)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    string sqlInsert = "INSERT INTO PROYECTO(Nombre, Descripcion, FechaInicio, FechaFinal, Presupuesto, DEVs, QAs)";
                    sqlInsert = sqlInsert + "values('"
                        + p1.Nombre + "','"
                        + p1.Descripcion + "',convert(datetime,'"
                        + p1.FechaInicio + "'),convert(datetime,'"
                        + p1.FechaFin + "'),"
                        + p1.Presupuesto + ","
                        + p1.Devs + ","
                        + p1.Qas
                        + ")";

                    //Comando
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    conn.Open();
                    //Ejecucion
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void ListarProyecto()
        {
            //abrir y leer un archivo
            using (StreamReader sr = new StreamReader(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\proyectos.txt"))
            {
                try
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //cerrar el archivo
                    sr.Close();
                }
            }
        }
    }
}