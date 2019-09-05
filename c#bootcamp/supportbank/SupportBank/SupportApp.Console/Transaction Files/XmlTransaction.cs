using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SupportApp.Console.Transaction_Files
{
    public class XmlTransaction
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlElement("Parties")]
        public XmlParties Parties { get; set; }

        [XmlElement("Description")]
        public string Narrative { get; set; }

        [XmlElement("Value")]
        public string Amount { get; set; }

        public Transaction ToTransaction()
        {
            return new Transaction(Date, Parties.To, Parties.From, Narrative, decimal.Parse(Amount));
        }
    }

    public class XmlParties
    {
        [XmlElement("To")]
        public string To { get; set; }

        [XmlElement("From")]
        public string From { get; set; }
    }
}
