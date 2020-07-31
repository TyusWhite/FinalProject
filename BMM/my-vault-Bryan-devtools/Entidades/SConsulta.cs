using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCare_System.Entidades
{
  public class SConsulta
    {
        private int CmbPaciente;
        private int CmbDoctor;
        private string descripcion;
        private string fecha_hora;

        
        public string Descripcion { get => descripcion; set => descripcion = value; }
       
        public int CmbPaciente1 { get => CmbPaciente; set => CmbPaciente = value; }
        public int CmbDoctor1 { get => CmbDoctor; set => CmbDoctor = value; }
        public string Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
    }
}
