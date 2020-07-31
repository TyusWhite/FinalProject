using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCare_System.Entidades
{
    public class SPaciente
    {
        private  string _nombre;
        private  string _apellido;
        private  string _telefono;
        private  string _celular;
        private  string _ocupacion;
        private  string _sexo;
        private  string _estadoCivil;
        private  string _fechaNacimiento;
        private  string _direccion;
       

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Celular { get => _celular; set => _celular = value; }
        public string Ocupacion { get => _ocupacion; set => _ocupacion = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public string EstadoCivil { get => _estadoCivil; set => _estadoCivil = value; }
        public string FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        

        //constructor vacio
       public SPaciente()
        {

        }
        
        //constructor con parametros que inicializa todos los atributos de la clase.
       /* public SPaciente(string nombre, string apellido, string telefono,string celular, string ocupacion,string sexo,string estadovil,string fechaNacimiento, string direccion)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._telefono = telefono;
            this._celular = celular;
            this._ocupacion = ocupacion;
            this._sexo = sexo;
            this._estadoCivil = estadovil;
            this._fechaNacimiento = fechaNacimiento;
            this._direccion = direccion;

        }*/
        
    }
}
