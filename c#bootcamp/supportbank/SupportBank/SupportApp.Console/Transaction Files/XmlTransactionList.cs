using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SupportApp.Console.Transaction_Files
{
    [XmlRoot(ElementName = "TransactionList")]
    public class XmlTransactionList
    {
        [XmlElement("SupportTransaction", typeof(XmlTransaction))]
        public List<XmlTransaction> XmlList { get; set; }

        public List<Transaction> ToTransactions()
        {
            return XmlList.Select(transaction => transaction.ToTransaction()).ToList();
        }
    }
}