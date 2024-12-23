using System;
using System.Linq;
using System.Text;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        StringBuilder cleaned = new StringBuilder();

        foreach (var item in phoneNumber)
        {
            if (char.IsDigit(item))
                cleaned.Append(item);
        }

        if (cleaned[0] == '1' || cleaned[0] == '0')
            cleaned.Remove(0, 1);

        if (cleaned.ToString().Count() == 10 &&
           (cleaned[0] - '0' <= 9 && cleaned[0] - '0' >= 2) &&
           (cleaned[3] - '0' <= 9 && cleaned[3] - '0' >= 2))
            return cleaned.ToString();
        else
            throw new ArgumentException();

    }
}