using System.Text.RegularExpressions;

namespace RegexPractice
{
    public static class RegexProblems
    {
        /// <summary>
        /// Validates a username based on specific rules.
        /// Can only contain letters (a-z, A-Z), numbers (0-9), and underscores (_)
        /// Must start with a letter
        /// Must be between 5 to 15 characters long
        /// </summary>
        /// <param name="username">The username string to validate.</param>
        /// <returns>True if the username is valid, false otherwise.</returns>
        public static bool ValidateUsername(string username)
        {
            if (username == null)
            {
                return false;
            }
            // Regex pattern explanation:
            // ^                  - Start of the string
            // [a-zA-Z]           - Must start with a letter (uppercase or lowercase)
            // [a-zA-Z0-9_]{4,14} - Followed by 4 to 14 characters which can be letters, numbers, or underscores.
            //                      (This ensures a total length of 5 to 15 characters, including the first letter)
            // $                  - End of the string
            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";
            return Regex.IsMatch(username, pattern);
        }
        public static bool ValidateLicensePlate(string licensePlate)
        {
            if (licensePlate == null)
            {
                return false;
            }
            // Regex pattern explanation:
            // ^                  - Start of the string
            // [A-Z]{2}           - Exactly two uppercase letters
            // [0-9]{4}           - Exactly four digits
            // $                  - End of the string
            string pattern = @"^[A-Z]{2}[0-9]{4}$";
            return Regex.IsMatch(licensePlate, pattern);
        }
        public static bool ValidateHexColorCode(string hexColorCode)
        {
            if (hexColorCode == null)
            {
                return false;
            }
            // Regex pattern explanation:
            // ^                  - Start of the string
            // #                  - Must start with a '#'
            // [0-9a-fA-F]{6}     - Followed by exactly 6 hexadecimal characters (0-9, a-f, A-F)
            // $                  - End of the string
            string pattern = @"^#([0-9a-fA-F]{6})$";
            return Regex.IsMatch(hexColorCode, pattern);
        }
        public static List<string> ExtractEmails(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }
            // Regex pattern explanation:
            // \b                  - Word boundary
            // [A-Za-z0-9._%+-]+   - One or more alphanumeric characters, dots, underscores, percents, plus, or hyphens
            // @                   - The at symbol
            // [A-Za-z0-9.-]+      - One or more alphanumeric characters, dots, or hyphens
            // \.                  - A literal dot
            // [A-Za-z]{2,}        - Two or more letters for the domain extension
            // \b                  - Word boundary
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }
        public static List<string> ExtractCapitalizedWords(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }
            // Regex pattern explanation:
            // \b                  - Word boundary
            // [A-Z]               - A single uppercase letter
            // [a-z]*              - Followed by zero or more lowercase letters
            // \b                  - Word boundary
            string pattern = @"\b[A-Z][a-zA-Z]*\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }

        public static List<string> ExtractDates(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }
            // Regex pattern explanation:
            // \b                                        - Word boundary
            // (0[1-9]|[12][0-9]|3[01])                 - Day (01-31)
            // /                                         - Slash separator
            // (0[1-9]|1[0-2])                          - Month (01-12)
            // /                                         - Slash separator
            // \d{4}                                     - Year (4 digits)
            // \b                                        - Word boundary
            string pattern = @"\b(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }

        public static List<string> ExtractLinks(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }
            // Matches http/https URLs and trims common trailing punctuation.
            string pattern = @"\bhttps?://[^\s""'<>]+";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches
                .Cast<Match>()
                .Select(m => m.Value.TrimEnd('.', ',', ';', ':', '!', '?', ')', ']', '}', '"', '\''))
                .ToList();
        }

        public static string ReplaceMultipleSpaces(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }
            // Replace two or more consecutive spaces with a single space.
            return Regex.Replace(text, @" {2,}", " ");
        }

        public static string CensorBadWords(string text, IEnumerable<string> badWords)
        {
            if (text == null)
            {
                return string.Empty;
            }
            if (badWords == null)
            {
                return text;
            }

            List<string> escapedBadWords = badWords
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => Regex.Escape(w.Trim()))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (escapedBadWords.Count == 0)
            {
                return text;
            }

            string pattern = $@"\b(?:{string.Join("|", escapedBadWords)})\b";
            return Regex.Replace(text, pattern, "****", RegexOptions.IgnoreCase);
        }

        public static bool ValidateIPv4(string ipAddress)
        {
            if (ipAddress == null)
            {
                return false;
            }
            // Each octet: 0-255, separated by dots.
            string octet = @"(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)";
            string pattern = $"^{octet}(\\.{octet}){{3}}$";
            return Regex.IsMatch(ipAddress, pattern);
        }

        public static bool ValidateCreditCardNumber(string cardNumber)
        {
            if (cardNumber == null)
            {
                return false;
            }
            // Normalize common separators.
            string normalized = Regex.Replace(cardNumber, @"[\s-]", "");

            // Visa: starts with 4, 16 digits; MasterCard: starts with 5, 16 digits.
            string pattern = @"^[45]\d{15}$";
            return Regex.IsMatch(normalized, pattern);
        }

        public static List<string> ExtractProgrammingLanguages(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }

            string[] languages =
            {
                "JavaScript",
                "TypeScript",
                "Python",
                "Java",
                "Go",
                "C#",
                "C++",
                "C",
                "Rust",
                "Kotlin",
                "Swift",
                "Ruby",
                "PHP",
                "Scala",
                "Dart",
                "R",
            };

            string[] escaped = languages
                .OrderByDescending(l => l.Length)
                .Select(Regex.Escape)
                .ToArray();

            // Use non-word boundaries so tokens like "C#" and "C++" are handled correctly.
            string pattern = $@"(?<!\w)(?:{string.Join("|", escaped)})(?!\w)";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }

        public static List<string> ExtractCurrencyValues(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }
            // Matches currency values like "$45.99" or "$ 10.50" and normalizes whitespace.
            string pattern = @"\$\s*\d+(?:\.\d{2})?";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches
                .Cast<Match>()
                .Select(m => Regex.Replace(m.Value, @"\s+", ""))
                .ToList();
        }

        public static List<string> FindRepeatingWords(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }
            // Finds immediately repeating words like "is is" or "repeated repeated".
            string pattern = @"\b(?<word>[A-Za-z]+)\b(?:\s+\k<word>\b)+";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            var results = new List<string>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (Match match in matches)
            {
                string word = match.Groups["word"].Value;
                if (seen.Add(word))
                {
                    results.Add(word);
                }
            }

            return results;
        }

        public static bool ValidateSSN(string ssn)
        {
            if (ssn == null)
            {
                return false;
            }
            string pattern = @"^\d{3}-\d{2}-\d{4}$";
            return Regex.IsMatch(ssn, pattern);
        }
    }
}
