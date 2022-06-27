using System;
using System.Runtime.Serialization;

namespace BirlesikOdeme.Library.DTO
{
    
    [DataContract]
    public class customerDTO : BaseDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string BirtDate { get; set; }
        [DataMember]
        public string IdentityNo { get; set; }
        [DataMember]
        public string IdentityNoVerified { get; set; }
        [DataMember]
        public string Mail { get; set; }
    }
}