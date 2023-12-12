internal class Program
{
    private static void Main()
    {
        string? input = LoadInputFromFile();

        int r1 = HandleInput(input);

        string? input2 = ConvertTextToNumber(input);
        int r2 = HandleInput(input2);

        Console.WriteLine($"Part 1: {r1}");
        Console.WriteLine($"Part 2: {r2}");
    }

    private static int HandleInput(string input)
    {
        string[] lines = input.Split("\r\n");
        int totalSum = 0;

        foreach (string line in lines)
        {
            totalSum += ParseAndExecuteDay1(line);
        }

        return totalSum;
    }

    private static int ParseAndExecuteDay1(string text)
    {
        string firstNumber = FindFirstNumber(text);
        string lastNumber = FindLastNumber(text);

        return int.Parse(firstNumber + lastNumber);
    }

    private static string LoadInputFromFile()
    {
        return File.ReadAllText("input.txt");
    }

    private static string FindFirstNumber(string text)
    {
        foreach (char character in text)
        {
            if (char.IsDigit(character))
            {
                return character.ToString();
            }
        }

        throw new Exception("No digit found in string!");
    }

    private static string FindLastNumber(string text)
    {
        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(text[i]))
            {
                return text[i].ToString();
            }
        }

        throw new Exception("No digit found in string!");
    }

    // Thanks Seya :)
    private static string ConvertTextToNumber(string input)
    {
        return input.Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "th3ee")
            .Replace("four", "fo4r")
            .Replace("five", "fi5e")
            .Replace("six", "s6x")
            .Replace("seven", "se7en")
            .Replace("eight", "ei8th")
            .Replace("nine", "ni9e");
    }
}