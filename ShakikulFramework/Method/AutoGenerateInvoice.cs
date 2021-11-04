using System;

namespace ShakikulFramework.Method
{
    public class AutoGenerateInvoice
    {
        private double invoiceLimit = 18446744073709551615;

        private double Increment(double increment)
        {
            if (!(increment > 0))
            {
                throw new Exception("Please enter positive value");
            }
            
            return increment;
        }

        private void Maximum(double invoiceSource)
        {
            if (invoiceSource >= invoiceLimit)
            {
                throw new Exception("Invoice Out of Range please Contact Developer");
            }
        }

        /// <summary>
        /// MD SHAKIKUL ISLAM
        /// This Method perfectly use only integer type invoice numbers
        /// And return type only double
        /// Using double because double type support max 9999999999999999999 big space.
        /// This space is not possible of int type.
        /// </summary>
        /// <returns></returns>
        public double Invoice(double invoiceSource, double increment)
        {
            //var startPoint = 0;
            Maximum(invoiceSource);

            return invoiceSource + Increment(increment);

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
        /// <returns></returns>
        public string Invoice(string invoiceSource, string firstInvoiceString, double increment)
        {
            var firstInvoiceStringLength = firstInvoiceString.Length;
            var mainInvoice = Convert.ToDouble(invoiceSource.Substring(firstInvoiceStringLength));
            
            Maximum(mainInvoice);

            mainInvoice += Increment(increment);
            return firstInvoiceString + mainInvoice;
        }

        /// <summary>
        /// MD SHAKIKUL ISLAM
        /// </summary>
        /// <returns></returns>
        public string Invoice(string invoiceSource, string firstInvoiceString, string lastInvoiceString, double increment)
        {
            var invoiceSourceLength = invoiceSource.Length;
            var firstInvoiceStringLength = firstInvoiceString.Length;
            var lastInvoiceStringLength = lastInvoiceString.Length;
            var mainInvoice = Convert.ToDouble(invoiceSource.Substring(firstInvoiceStringLength,invoiceSourceLength-(firstInvoiceStringLength+lastInvoiceStringLength)));
            
            Maximum(mainInvoice);

            mainInvoice += Increment(increment);

            return firstInvoiceString + mainInvoice + lastInvoiceString;
        }

    }
}
