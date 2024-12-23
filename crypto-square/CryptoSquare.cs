using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        return Regex.Replace(plaintext.ToLower(), "[^a-zA-Z0-9]", String.Empty);
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        string normalized = NormalizedPlaintext(plaintext);
        int lenght = normalized.Count();
        int c = (int)Math.Ceiling(Math.Sqrt(lenght));

        for (int i = 0; i < lenght; i += c)
        {
            if (lenght - i < c)
            {
                var last = normalized.Substring(i, lenght - i);

                while (last.Length != c)
                {
                    last = last + " ";
                }
                yield return last;
            }
            else
            {
                yield return normalized.Substring(i, c);
            }
        }
    }

    public static string Encoded(string plaintext)
    {
        return Ciphertext(plaintext).Replace(" ", "");
    }

    public static string Ciphertext(string plaintext)
    {
        var plaintextArray = PlaintextSegments(plaintext).ToList();
        StringBuilder message = new StringBuilder();

        if (String.IsNullOrEmpty(plaintext))
            return plaintext;

        int lenght = NormalizedPlaintext(plaintext).Count();
        int c = (int)Math.Ceiling(Math.Sqrt(lenght));
        int x = lenght / c;

        if (c * x < lenght)
            x += 1;

        for (int i = 0; i < plaintextArray[0].Count(); i++)
        {
            foreach (var item in plaintextArray)
            {
                message.Append(item[i]);
            }
            if (i != plaintextArray[0].Count() - 1)
                message.Append(" ");
        }

        return message.ToString();
    }
}