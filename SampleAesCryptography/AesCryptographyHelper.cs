using System.Security.Cryptography;

namespace SampleAesCryptography
{
    public static class AesCryptographyHelper
    {
        public static Aes AesCryptography { get; } = Aes.Create();

        public static byte[] EncryptString(string inputText)
        {
            try
            {
                if (string.IsNullOrEmpty(inputText))
                {
                    throw new ArgumentNullException("inputText");
                }

                var encryptor = AesCryptography.CreateEncryptor(AesCryptography.Key, AesCryptography.IV);
                using (var memoryStreamEncrypt = new MemoryStream())
                {
                    using (var cryptoStreamEncrypt = new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                        {
                            streamWriterEncrypt.Write(inputText);
                        }
                    }
                    return memoryStreamEncrypt.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EncryptString() error: {ex.Message}");
                return [];
            }
        }

        public static string DecryptBytesToString(byte[] inputBytes)
        {
            var decryptor = AesCryptography.CreateDecryptor(AesCryptography.Key, AesCryptography.IV);
            var decryptedText = "";


            try
            {
                using (var memoryStreamDecrypt = new MemoryStream(inputBytes))
                {
                    using (var cryptoStreamDecrypt = new CryptoStream(memoryStreamDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReaderDecrypt = new StreamReader(cryptoStreamDecrypt))
                        {
                            decryptedText = streamReaderDecrypt.ReadToEnd();
                        }
                    }
                }
                return decryptedText;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DecryptBytesToString() exception: {ex.Message}");
                return String.Empty;
            }
        }
    }
}
