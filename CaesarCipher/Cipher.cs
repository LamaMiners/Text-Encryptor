using System.Text;

namespace CaesarCipher;

public class Cipher
{
    public string Encrypt(char[] message, int shift)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in message)
        {
            // Handle uppercase letters (A-Z)
            if (char.IsUpper(c))
            {
                sb.Append((char)((((c - 'A') + shift) % 26 + 26) % 26 + 'A'));
            }
            // Handle lowercase letters (a-z)
            else if (char.IsLower(c))
            {
                sb.Append((char)((((c - 'a') + shift) % 26 + 26) % 26 + 'a'));
            }
            // For non-alphabetic characters, don't change them
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
