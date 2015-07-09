using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniandes.Entity
{
    public class Paciente
    {
        public int/*       */id_paciente  /*      */{ get; set; }
        public string /*   */nombres_paciente /*  */{ get; set; }
        public string /*   */apellidos_paciente/* */{ get; set; }
        public string /*   */ident_paciente /*    */{ get; set; }
        public int /*      */tipo_id /*           */{ get; set; }
        public int /*      */genero_paciente /*   */{ get; set; }
        public DateTime /* */fecha_nacimiento /*  */{ get; set; }
        public string /*   */direccion_paciente/**/ { get; set; }
        public string /*   */telefono_paciente /* */{ get; set; }
        public string /*   */movil_paciente/*    */ { get; set; }
        public DateTime /* */fecha_registro /*    */{ get; set; }
        public string /*   */mail_paciente /*     */{ get; set; }
        public string /*   */userId /*            */{ get; set; }
    }
}
