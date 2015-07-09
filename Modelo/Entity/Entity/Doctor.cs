using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniandes.Entity
{
    public class Doctor
    {
        public int id_doctor { get; set; }
        public string doctorId { get; set; }
        public string nombres_doctor { get; set; }
        public string apellidos_doctor { get; set; }
        public string ident_doctor { get; set; }
        public int tipo_id { get; set; }
        public int id_especialidad { get; set; }
        public string mail_doctor { get; set; }
    }
}
