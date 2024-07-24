namespace Adm.Core.Extensions;

public static class StringExtensions
{
    private static readonly string[] DoubleChars =
    {
        "sh", "ch", "ya", "yo", "yu", "o'", "o`",
        "o‘", "o’", "g'", "g’", "g`", "g‘", "g’"
    };

    public static string GetFIO(this string input)
    {
        if (input == string.Empty || input is null)
            return string.Empty;

        string text = string.Empty;
        try
        {
            input = input.Trim();
            string[] fio = input.Split(new string[1] { " " }, StringSplitOptions.None);

            if (fio.Length >= 3)
            {
                string value = fio[1].Substring(0, (!DoubleChars.Any((string a) => fio[1].ToLower().StartsWith(a))) ? 1 : 2);
                string value2 = fio[2].Substring(0, (!DoubleChars.Any((string a) => fio[1].ToLower().StartsWith(a))) ? 1 : 2);
                text = $"{value}.{value2}.{fio[0]}";
            }
            else
                text = $"{fio[1].Substring(0, (!DoubleChars.Any((string a) => fio[1].ToLower().StartsWith(a))) ? 1 : 2)}.{fio[0]}";
        }
        catch { }

        if (text == string.Empty)
            return input;

        return text;
    }

    public static string GetFullFIO(string lastName, string firstName, string middleName)
    {
        if (string.IsNullOrEmpty(lastName))
            lastName = string.Empty;

        if (string.IsNullOrEmpty(firstName))
            firstName = string.Empty;

        if (string.IsNullOrEmpty(middleName))
            middleName = string.Empty;

        middleName = middleName.RemoveEnter();

        return lastName.RemoveEnter() + " " + firstName.RemoveEnter() + ((middleName.Length > 0) ? (" " + middleName) : "");
    }

    public static string RemoveEnter(this string input)
    {
        if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
            return input;

        return input
            .Replace("\n", " ").Replace("\r", " ").Replace("\t", " ")
            .Replace("  ", " ").Replace(",", "").Replace(".", "");
    }
}