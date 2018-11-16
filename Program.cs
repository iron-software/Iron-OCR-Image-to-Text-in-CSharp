using IronOcr;
using System;

namespace ImageToTextTutorial
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Example 1 - AutoOcr Screenshot OCR Example");
            Console.WriteLine("------------------------------------------");
            Examples.Example1();

            Console.WriteLine("Example 2 - Advanced OCR with High Quality Scanned Input");
            Console.WriteLine("--------------------------------------------------------");
            Examples.Example2();
            Console.WriteLine();
            Console.WriteLine("Example 2A - Advanced OCR with Low Quality Scanned Input");
            Console.WriteLine("--------------------------------------------------------");
            Examples.Example2A();
            Console.WriteLine();

            Console.WriteLine("Example 3 - Crop Areas - Scanning only part of an Image");
            Console.WriteLine("-------------------------------------------------------");
            Examples.Example3();
            Console.WriteLine();

            Console.WriteLine("Example 4 - International Languages - Arabic Example  ");
            Console.WriteLine("-------------------------------------------------------");
            Examples.Example4();
            Console.WriteLine();

            Console.Read();
        }
    }

    internal static class Examples
    {
        public static void Example1()
        {
            // AutoOcr automatically detects input image properties and makes
            // an educated best guess at the optimal OCR settings.
            AutoOcr Ocr = new AutoOcr() { ReadBarCodes = false };
            var Results = Ocr.Read("img/Screenshot.png");
            Console.WriteLine(Results.Text);

            // Check accuracy
            Accuracy.Compare(Results, "txt/Example1.txt");
        }

        public static void Example2()
        {
            // Advanced OCR with High Quality Scanned Input
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = true,
                EnhanceResolution = false,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.Document,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 4
            };

            var Results = Ocr.Read("img/Potter.tiff");

            // Check accuracy
            Accuracy.Compare(Results, "txt/Example2.txt");
        }

        public static void Example2A()
        {
            // Advanced OCR with Low Quality Scanned Input
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = true,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.Document,
                RotateAndStraighten = true,
                ReadBarCodes = false,
                ColorDepth = 4
            };

            var Results = Ocr.Read("img/Potter.LowQuality.tiff");

            Accuracy.Compare(Results, "txt/Example2.txt");
        }

        public static void Example3()
        {
            //Crop Areas - Scanning only part of an Image
            var Ocr = new AutoOcr();

            var Area = new System.Drawing.Rectangle() { X = 215, Y = 1250, Height = 280, Width = 1335 };
            var Results = Ocr.Read("img/ComSci.Png", Area);

            Console.WriteLine(Results.Text);

            // Check accuracy
            Accuracy.Compare(Results, "txt/Example3.txt");
        }

        public static void Example4()
        {
            //International Languages - Arabic Example

            var Ocr = new AutoOcr()
            {
                Language = IronOcr.Languages.Arabic.OcrLanguagePack
            };

            var Results = Ocr.Read("img/arabic.gif");

            Console.WriteLine("{0} Characters of Arabic Read", Results.Text.Length);
            // Note that the .Net Console can not yet display Arabic characters... they all print as question marks.
        }
    }
}