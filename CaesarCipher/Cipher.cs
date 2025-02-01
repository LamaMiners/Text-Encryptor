using System.Text;

namespace CaesarCipher;

public class Cipher
{
    public string EncryptCaesar(char[] message, int shift)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in message)
        {
            if (char.IsUpper(c))
            {
                sb.Append((char)((((c - 'A') + shift) % 26 + 26) % 26 + 'A'));
            }
            else if (char.IsLower(c))
            {
                sb.Append((char)((((c - 'a') + shift) % 26 + 26) % 26 + 'a'));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    public string DecryptCaesar(char[] message, int shift)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in message)
        {
            if (char.IsUpper(c))
            {
                sb.Append((char)((((c - 'A') - shift) % 26 + 26) % 26 + 'A'));
            }
            else if (char.IsLower(c))
            {
                sb.Append((char)((((c - 'a') - shift) % 26 + 26) % 26 + 'a'));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    public string EncryptVigenere(char[] message, string key)
    {
        StringBuilder sb = new StringBuilder();
        int keyLength = key.Length;

        for (int i = 0; i < message.Length; i++)
        {
            char m = message[i];
            char k = key[i % keyLength];

            if (char.IsUpper(m))
            {
                int shift = char.IsUpper(k) ? k - 'A' : k - 'a';
                char encrypted = (char)((((m - 'A') + shift) % 26) + 'A');
                sb.Append(encrypted);
            }
            else if (char.IsLower(m))
            {
                int shift = char.IsUpper(k) ? k - 'A' : k - 'a';
                char encrypted = (char)((((m - 'a') + shift) % 26) + 'a');
                sb.Append(encrypted);
            }
            else
            {
                sb.Append(m);
            }
        }

        return sb.ToString();
    }




}
