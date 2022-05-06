
namespace ShakikulFramework.Method
{
    public class PaymentMethod
    {
        private static readonly string _cash = "Cash";
        private static readonly string _bKash = "bKash";
        private static readonly string _rocket = "Rocket";
        private static readonly string _card = "Card";
        private static readonly string _check = "Check";
        public static string Cash
        {
            get { return _cash; }
        }
        public static string bKash
        {
            get { return _bKash; }
        }
        public static string Rocket
        {
            get { return _rocket; }
        }
        public static string Card
        {
            get { return _card; }
        }
        public static string Check
        {
            get { return _check; }
        }

    }
}
