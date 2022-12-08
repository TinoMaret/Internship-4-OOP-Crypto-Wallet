namespace Crypto.Classes.Assets
{
    public class FungibleAsset: Asset
    {
        public string MeasuringUnit { get; private set; }
        public double ValueInUSD { get; private set; }
        public double ChangedSinceLastTime { get; set; }
        public FungibleAsset(string NameOfNewAsset, string MeasuringUnitOfNewAsset, double ValueInUSDOfNewAsset) : base(NameOfNewAsset) {
            MeasuringUnit = MeasuringUnitOfNewAsset;
            ValueInUSD = ValueInUSDOfNewAsset;
        }

        public void ChangeValueInUSD() {
            Random random = new Random();
            double ChangePercentage = random.Next(-25, 26) / 1000;
            ValueInUSD += ValueInUSD * ChangePercentage;
        }

        public string ShowChangeSinceLastSeen() {
            double temp = ChangedSinceLastTime;
            ChangedSinceLastTime = ValueInUSD;
            return (temp / ValueInUSD).ToString();
        }

        public override string ToString() {
            return base.ToString() + $"Oznaka Asseta - {MeasuringUnit} \n";
        }
    }
}
