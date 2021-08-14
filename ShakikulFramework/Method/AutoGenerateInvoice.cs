using System;
using System.CodeDom;
using System.Globalization;
using System.Net;

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
            //var startPoint = 0;
            if (invoiceSource >= 9999999999999999999)
            {
                throw new Exception("Invoice Out of Range please Contact Developer");
            }

            return invoiceSource + 0.01;

            //var inputInvoice = Convert.ToString(invoiceSource);

            //var subInvoice = Convert.ToDouble(inputInvoice.Substring(startPoint));
            //int length=0;

            //loop:
            //if (subInvoice >= 9999)
            //{
            //    length++;
            //    startPoint = length;
            //    subInvoice = Convert.ToDouble(inputInvoice.Substring(startPoint));
            //}

            //if (subInvoice >= 9999)
            //{
            //    goto loop;
            //}

            //double invoice = subInvoice + 1;
            //double finalInvoice = Convert.ToDouble(inputInvoice.Substring(0, length) + invoice);
            //return finalInvoice;
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
            if (mainInvoice == 9999999999999999999)
            {
                throw new Exception("Invoice Out of Range please Contact Developer");
            }
            mainInvoice += 0.01;
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
            if (mainInvoice == 9999999999999999999)
            {
                throw new Exception("Invoice Out of Range please Contact Developer");
            }
            mainInvoice += 0.01;
            return firstInvoiceString + mainInvoice + lastInvoiceString;
        }

    }
}
