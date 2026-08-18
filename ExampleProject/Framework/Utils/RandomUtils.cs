using ExampleProject.Framework.Constants;

namespace ExampleProject.Framework.Utils
{
    public static class RandomUtils
    {
        private const int LettersCapitalMinAscii = 65;     // 'A'
        private const int LettersCapitalMaxAscii = 90;     // 'Z'
        private const int LettersLowerMinAscii = 97;       // 'a'
        private const int LettersLowerMaxAscii = 122;      // 'z'
        private const int CyrillicLettersMinAscii = 1040;  // 'А'
        private const int CyrillicLettersMaxAscii = 1103;  // 'я'
        private const int DigitMinAscii = 48;              // '0'
        private const int DigitMaxAscii = 57;              // '9'

        private const string SpecialChars = "!@#$%&*";
        private const int DefaultStringLength = 10;

        private static readonly Random Random = new();

        public static string GetRandomAlphabeticString()
        {
            return GetRandomAlphabeticString(DefaultStringLength);
        }

        public static string GetRandomAlphabeticString(int length)
        {
            var chars = new List<char>();

            while (chars.Count < length)
            {
                int value = Random.Next(
                    LettersCapitalMinAscii,
                    LettersLowerMaxAscii + 1);

                if (value <= LettersCapitalMaxAscii ||
                    value >= LettersLowerMinAscii)
                {
                    chars.Add((char)value);
                }
            }

            return new string(chars.ToArray());
        }

        public static string GeneratePassword(int length)
        {
            const int requiredSymbolsCount = 6;

            if (length < requiredSymbolsCount)
            {
                throw new ArgumentException(
                    $"Password must be at least {requiredSymbolsCount} characters long");
            }

            var password = new List<char>
            {
                GetRandomChar(LettersCapitalMinAscii, LettersCapitalMaxAscii),
                GetRandomChar(LettersLowerMinAscii, LettersLowerMaxAscii),
                GetRandomChar(DigitMinAscii, DigitMaxAscii),
                GetRandomChar(SpecialChars),
                GetRandomChar(CyrillicLettersMinAscii, CyrillicLettersMaxAscii)
            };

            int remainingLength = length - password.Count;

            password.AddRange(
                GetRandomAlphabeticString(remainingLength));

            return ShuffleString(new string(password.ToArray()));
        }

        public static int GetRandomInt(int boundExclusive)
        {
            return Random.Next(boundExclusive);
        }

        public static char GetRandomChar(int minAscii, int maxAscii)
        {
            return (char)Random.Next(minAscii, maxAscii + 1);
        }

        public static char GetRandomChar(string str)
        {
            return str[GetRandomInt(str.Length)];
        }

        public static string ShuffleString(string input)
        {
            var chars = input.ToList();

            for (int i = chars.Count - 1; i > 0; i--)
            {
                int j = Random.Next(i + 1);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }

            return new string(chars.ToArray());
        }

        public static Domains GetRandomDomain()
        {
            Domains[] domains = Enum.GetValues<Domains>();
            return domains[GetRandomInt(domains.Length)];
        }
    }
}