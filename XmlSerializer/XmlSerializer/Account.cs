using System;

namespace XmlSerializer
{
    [XmlObject]
    public class Account
    {
        [XmlProperty]
        public int Id { get; set; }

        [XmlProperty]
        public string Iban { get; set; }

        [XmlProperty]
        public string Currency { get; set; }

        [XmlProperty]
        public decimal Balance { get; set; }
    }
}