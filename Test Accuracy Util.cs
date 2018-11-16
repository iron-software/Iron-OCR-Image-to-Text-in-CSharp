using System;
using System.IO;

namespace ImageToTextTutorial
{
    internal static class Accuracy
    {
        /// <summary>
        /// Compares an IronOcr.OcrResult against a Text File with the true text of a document. 
        /// 
        /// Copyright 2018 https://ironsoftware.com/csharp/ocr/
        /// </summary>
        /// <param name="Result">the IronOCR OcrResult</param>
        /// <param name="ComparisonFilePath">A text file path which contains the exact text of the original document.</param>
        /// <returns></returns>
        public static decimal Compare(IronOcr.OcrResult Result, string ComparisonFilePath)
        {
            string OCRText = Result.Text;
            string TrueText = File.ReadAllText(ComparisonFilePath);

            OCRText = NormalizeWhiteSpace(OCRText);
            TrueText = NormalizeWhiteSpace(TrueText);

            OCRText = NormalizePunctuation(OCRText);
            TrueText = NormalizePunctuation(TrueText);

            int StringDistance = LevenshteinStringDistance(OCRText, TrueText);

            decimal PercentageMatch = 100M * ((decimal)TrueText.Length - (decimal)StringDistance) / (decimal)TrueText.Length;

            decimal RoundedResult = Math.Round(PercentageMatch, 1);
            Console.WriteLine("");
            Console.WriteLine("OCR Accuracy was {0} %", RoundedResult);
            Console.WriteLine("");
            return RoundedResult;
        }

        private static string NormalizePunctuation(String input)
        {
            input = input.Replace("`", "'");
            input = input.Replace("‘", "'");
            input = input.Replace("’", "'");
            input = input.Replace("—", "-");
            input = input.Replace('“', '"');
            input = input.Replace('”', '"');

            return input;
        }

        private static string NormalizeWhiteSpace(String input)
        {
            string cleanedString = System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ");
            return cleanedString;
        }

        public static int LevenshteinStringDistance(string s, string t)
        {
            // From https://www.dotnetperls.com/levenshtein

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}