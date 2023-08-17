using System.Runtime.Serialization;


namespace WebServicesEnrollment.model
{
    [DataContract]
    public class AspiranteResponse
    {
        [DataMember]
        public int StatusCode {get; set;}
        [DataMember]
        public string Message {get; set;}
        [DataMember]
        public string NoExpediente {get; set;}
    }
}