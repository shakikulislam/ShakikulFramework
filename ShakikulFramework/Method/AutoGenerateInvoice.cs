using System;

namespace ShakikulFramework.Method
{
    public class AutoGenerateInvoice
    {
        /// <summary>
        /// This Method use only integer type invoice numbers
        /// And return type only integer
        /// </summary>
        /// <param name="invoiceSource"></param>
        /// <returns></returns>
        public int Invoice(int invoiceSource)
        {
            return (invoiceSource + 1);
        }

        /// <summary>
        /// MD SHAKIKUL ISLAM
        /// </summary>
        /// <param name="invoiceSource"></param>
        /// <param name="firstInvoiceString"></param>
        /// <returns></returns>
        public string Invoice(string invoiceSource, string firstInvoiceString)
        {
            var firstInvoiceStringLength = firstInvoiceString.Length;
            var mainInvoice = Convert.ToInt32(invoiceSource.Substring(firstInvoiceStringLength));
            mainInvoice += 1;
            return firstInvoiceString + mainInvoice;
        }

        /// <summary>
        /// MD SHAKIKUL ISLAM
        /// </summary>
        /// <param name="invoiceSource"></param>
        /// <param name="firstInvoiceString"></param>
        /// <param name="lastInvoiceString"></param>
        /// <returns></returns>
        public string Invoice(string invoiceSource, string firstInvoiceString, string lastInvoiceString)
        {
            var invoiceSourceLength = invoiceSource.Length;
            var firstInvoiceStringLength = firstInvoiceString.Length;
            var lastInvoiceStringLength = lastInvoiceString.Length;
            var mainInvoice = Convert.ToInt32(invoiceSource.Substring(firstInvoiceStringLength,invoiceSourceLength-(firstInvoiceStringLength+lastInvoiceStringLength)));
            mainInvoice += 1;
            return firstInvoiceString + mainInvoice + lastInvoiceString;
        }

    }
}
