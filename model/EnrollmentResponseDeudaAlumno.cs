using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebServicesEnrollment.model
{
    [DataContract]
    public class EnrollmentResponseDeudaAlumno
    {

        [DataMember]
        public int StatusCode {get; set;}
        [DataMember]
        public string Message {get; set;}
        [DataMember]
        public string correlativo { get; set; }

        [DataMember]
        public string anio { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public string fechacargo { get; set; }

        [DataMember]
        public string fechaaplica { get; set; }

        [DataMember]
        public string monto { get; set; }


    }
}