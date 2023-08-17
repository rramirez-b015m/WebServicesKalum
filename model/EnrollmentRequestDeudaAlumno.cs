
using System.Runtime.Serialization;

namespace WebServicesEnrollment.model
{
    [DataContract]
    public class EnrollmentRequestDeudaAlumno
    {
        
        [DataMember]
        public string carnealumno { get; set; }

    }
}

