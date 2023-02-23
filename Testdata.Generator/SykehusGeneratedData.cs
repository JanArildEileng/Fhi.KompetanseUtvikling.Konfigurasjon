namespace Testdata.Generator
{
    public class SykehusGeneratedData
    {
        public int SecretKey { get; }
        public string SecretValue { get; }

        public List<Sykehus.Domene.Sykehus> Sykehus { get; set; } = new List<Sykehus.Domene.Sykehus>();

        public SykehusGeneratedData(int secretKey, string secretValue)
        {
            SecretKey = secretKey;
            SecretValue = secretValue;
        }

        internal void AddSykehus(Sykehus.Domene.Sykehus sykehus)
        {
            Sykehus.Add(sykehus);
        }
     
    }
}
