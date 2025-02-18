namespace SampleAesCryptography
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a string to encrypt: " );
            var inputText = Console.ReadLine();

            while (String.IsNullOrEmpty(inputText))
            {
                Console.WriteLine("Didn't detect a valid input, please try again");
                inputText = Console.ReadLine();
            }

            Console.WriteLine($"Your input text was \"{inputText}\"");

            Console.WriteLine("Encrpyting...");
            var encryptedBytes = AesCryptographyHelper.EncryptString(inputText);
            Console.WriteLine($"Encrypted bytes are: {System.Text.Encoding.UTF8.GetString(encryptedBytes)}");

            var decryptedBytes = AesCryptographyHelper.DecryptBytesToString(encryptedBytes);
            Console.WriteLine($"Decrypted string is: {decryptedBytes}");

        }
    }
}
