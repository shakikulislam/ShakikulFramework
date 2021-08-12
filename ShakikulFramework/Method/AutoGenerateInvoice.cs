using System;

namespace ShakikulFramework.Method
{
    public class AutoGenerateInvoice
    {
        /// <summary>
        /// This Method perfectly use only integer type invoice numbers
        /// And return type only double
        /// Using double because double type support max 9999999999999999999 big space.
        /// This space is not possible of int type.
        /// </summary>
        /// <param name="invoiceSource"></param>
        /// <returns></returns>
        public double Invoice(double invoiceSource)
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
            var mainInvoice = Convert.ToDouble(invoiceSource.Substring(firstInvoiceStringLength));
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
            var mainInvoice = Convert.ToDouble(invoiceSource.Substring(firstInvoiceStringLength,invoiceSourceLength-(firstInvoiceStringLength+lastInvoiceStringLength)));
            mainInvoice += 1;
            return firstInvoiceString + mainInvoice + lastInvoiceString;
        }

    }
}
