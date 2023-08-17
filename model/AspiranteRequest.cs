using System.Runtime.Serialization;


namespace WebServicesEnrollment.model
{
    [DataContract]

    public class AspiranteRequest
    {
        [DataMember]
        public string Apellidos {get; set;}
        [DataMember]
        public string Nombres {get; set;}
        [DataMember]
        public string Direccion {get; set;}
        [DataMember]
        public string Telefono {get; set;}
        [DataMember]
        public string Email {get; set;}
        [DataMember]
        public string CarreraId {get; set;}
        [DataMember]
        public string ExamenId {get; set;}
        [DataMember]
        public string JornadaId{get; set;}
       

    }
}