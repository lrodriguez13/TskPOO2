using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TskPOO2
{
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
            return _salario - (_salario * porcentaje / 100);
        }

        //Override (sobreescritura) de metodos -- Todas las clases y objetos heredan de la clase object.
        public override string ToString()
        {

            return _apellido + "|" + _nombre + "|" + _fechaIngreso + "|" + _salario;
        }
    }
}
