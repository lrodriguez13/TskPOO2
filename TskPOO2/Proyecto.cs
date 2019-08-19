using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TskPOO2
{
    class Proyecto
    {
        //Atributos--campos
        private string _nombre;
        private string _descripcion;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private float _presupuesto;
        private int _devs;
        private int _qas;

        //Propiedades (metodos que me permiten interactuar con los demas elementos)
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime FechaInicio { get => _fechaInicio; set => _fechaInicio = value; }
        public DateTime FechaFin { get => _fechaFin; set => _fechaFin = value; }
        public float Presupuesto { get => _presupuesto; set => _presupuesto = value; }
        public int Devs { get => _devs; set => _devs = value; }
        public int Qas { get => _qas; set => _qas = value; }

        //Constructores
        //Modificador o ambito -- Nombre de la clase identico -- Parametros
        public Proyecto() //Constructor vacio
        {

        }

        public Proyecto(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, float presupuesto, int devs, int qas)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _presupuesto = presupuesto;
            _devs = devs;
            _qas = qas;
        }

        //Metodos --acciones que puede realizar
        //CRUD -- Create Read Update Delete

        //Override (sobreescritura) de metodos -- Todas las clases y objetos heredan de la clase object.
        public override string ToString()
        {

            return _nombre + "|" + _descripcion + "|" + _fechaInicio + "|" + _fechaFin + "|" + _presupuesto + "|" + _devs + "|" + _qas;
        }
    }
}
