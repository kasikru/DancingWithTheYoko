using System;
using System.Collections;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string strand)
    {
        StringBuilder rna = new StringBuilder();

        foreach (var item in strand)
        {
            switch (item)
            {
                case 'G':
                    rna.Append('C');
                    break;
                case 'C':
                    rna.Append('G');
                    break;
                case 'T':
                    rna.Append('A');
                    break;
                case 'A':
                    rna.Append('U');
                    break;
            };
        }

        return rna.ToString();
    }
}