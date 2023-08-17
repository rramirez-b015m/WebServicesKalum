using System.Runtime.Serialization;

namespace WebServicesEnrollment.model
{
    [DataContract]
    public class EnrollmentResponse
    {
        [DataMember]
        public int StatusCode {get; set;}
        [DataMember]
        public string Message {get; set;}
        [DataMember]
        public string Carne {get; set;}


    }
}