namespace CryptoSoft
{
    internal static class Program
    {
        static int Main(string[] args)
        {
            Encryptor encryptor = new Encryptor(args[0], args[1], args[2]);
            return (int)encryptor.EncryptXOR(); ;
        }
    }
}