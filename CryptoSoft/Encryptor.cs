using System.Diagnostics;
using System.Text;

namespace CryptoSoft
{
    public class Encryptor
    {
        private string PathSource { get; set; }
        private string PathDestination { get; set; }
        private string Password { get; set; }
        private FileStream FileSource { get; set; }
        private FileStream FileDestination { get; set; }

        public Encryptor(string pathSource, string pathDestination, string password)
        {
            PathSource = pathSource;
            PathDestination = pathDestination;
            Password = password;
            FileSource = new FileStream(PathSource, FileMode.Open);
            FileDestination = new FileStream(PathDestination, FileMode.OpenOrCreate);
        }

        public long EncryptXOR()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            byte[]? buffer = ReadNext();
            while (buffer != null)
            {
                byte[] encryptedBuffer = Encrypt(buffer);
                WriteNext(encryptedBuffer);
                buffer = ReadNext();
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private byte[] Encrypt(byte[] buffer)
        {
            byte[] encryptedBuffer = new byte[buffer.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                encryptedBuffer[i] = (byte)(buffer[i] ^ Password[i % Password.Length]);
            }
            return encryptedBuffer;
        }

        public byte[]? ReadNext()
        {
            byte[] buffer = new byte[1024 * 16];
            int bytesRead = FileSource.Read(buffer, 0, 1024 * 16);
            if (bytesRead == 0)
            {
                return null;
            }
            return buffer;
        }

        public void WriteNext(byte[] buffer)
        {
            FileDestination.Write(buffer, 0, buffer.Length);
        }
    }
}
