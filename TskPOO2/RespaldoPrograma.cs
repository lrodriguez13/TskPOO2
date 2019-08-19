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
            string nombre = "";
            string apellido = "";
            DateTime ingreso = DateTime.Now;
            float salario = 0.0f;

            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            apellido = Console.ReadLine();
            Console.Write("Fecha de Ingreso: ");
            ingreso = DateTime.Parse(Console.ReadLine());
            Console.Write("Salario: ");
            salario = float.Parse(Console.ReadLine());

            //Parse | Cast significa convertir entre tipos de datos
            //TipoDato.parse("valor") | (DateTime)"valor"
            //Instancia de un objecto
            //Nombre de la clase -- nombre del objeto = new -- constructor ()
            Empleado e1 = new Empleado(nombre, apellido, ingreso, salario);

            //Crear un archivo de escritura
            StreamWriter sw = new StreamWriter(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\output.txt",true);

            //escribir en el archivo
            sw.WriteLine(e1.ToString() + "|" + e1.calcularAntiguedad() + "|" + e1.quitarImpuestos(16));

            //cerrar el archivo
            sw.Close();

            //abrir y leer un archivo
            StreamReader sr = new StreamReader(@"C:\Users\Luis\source\repos\TskPOO2\TskPOO2\output.txt");

            Console.WriteLine(sr.ReadToEnd());

            //cerrar el archivo
            sr.Close();

            //Console.WriteLine(e1.ToString() + "|" + e1.calcularAntiguedad() + "|" + e1.quitarImpuestos(16));
            Console.ReadLine();
        }
    }

    class Empleado
    {
        //Atributos--campos
        private string _nombre;
        private string _apellido;
        private DateTime _fechaIngreso;
        private float _salario;

        //Propiedades (metodos que me permiten interactuar con los demas elementos)
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public float Salario { get => _salario; set => _salario = value; }

        //Constructores
        //Modificador o ambito -- Nombre de la clase identico -- Parametros
        public Empleado() //Constructor vacio
        {

        }

        public Empleado(string pnombre, string papellido, DateTime pfecha, float psalario) //Firma (Parametros)
        {
            _nombre = pnombre;
            _apellido = papellido;
            _fechaIngreso = pfecha;
            _salario = psalario;
        }

        //Metodos --acciones que puede realizar
        //CRUD -- Create Read Update Delete

        //Calcular antiguedad
        //Modificador o ambito -- Tipo de dato de retorno -- Nombre del metodo -- Parametros
        public string calcularAntiguedad()
        {
            int inicio = DateTime.Now.Year - _fechaIngreso.Year;
            DateTime antiguedad = _fechaIngreso.AddYears(inicio);
            if (DateTime.Now.CompareTo(antiguedad) < 0)
            {
                inicio--;
            }
            return inicio.ToString();

        }

        //Calcular Impuestos
        public float quiarImpuestos()
        {
            return _salario - (_salario * 0.34f);
        }

        //Sobrecarga de metodos
        public float quitarImpuestos(int porcentaje)
        {
            return _salario - (_salario * porcentaje/100);
        }

        //Override (sobreescritura) de metodos -- Todas las clases y objetos heredan de la clase object.
        public override string ToString()
        {

            return _apellido + "|" + _nombre + "|" + _fechaIngreso + "|" + _salario;
        }
    }

}
