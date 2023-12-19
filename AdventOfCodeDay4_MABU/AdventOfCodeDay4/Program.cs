using AdventOfCodeDay4;

internal class Program
{

    private static int Points { get; set; }

    private static ScratchCard[]? ScratchCards { get; set; }


    private static void Main()
    {
        ResolvePart1();
        ResolvePart2();
    }



    private static void ResolvePart1()
    {
        string[]? lines = File.ReadAllLines("input.txt");

        foreach (string? line in lines)
        {

            List<int>? winningN = new();
            List<int>? n = new();

            string[]? tmp = line.Split(":");
            string[]? content = tmp[1].Split(" |");

            string? winningString = content[0];
            string? numbersString = content[1];

            winningString = winningString[1..];
            numbersString = numbersString[1..];


            string[]? splitWin = winningString.Split(" ");
            string[]? splitNum = numbersString.Split(" ");

            splitWin = splitWin.Where(n => n != "").ToArray();
            splitNum = splitNum.Where(n => n != "").ToArray();

            foreach (string? number in splitWin)
            {
                winningN.Add(int.Parse(number));
            }

            foreach (string? number in splitNum)
            {
                n.Add(int.Parse(number));
            }

            int countbefore = n.Count();
            n = n.Except(winningN).ToList();
            int countafter = n.Count();


            int foundNumbers = countbefore - countafter;

            if (foundNumbers > 0)
            {
                int tmpPoint = 1;

                while (foundNumbers > 1)
                {
                    tmpPoint = tmpPoint * 2;
                    foundNumbers--;
                }

                Points += tmpPoint;
            }
        }


        Console.WriteLine($"Part 1: {Points}");
    }

    private static void ResolvePart2()
    {
        string[] lines = File.ReadAllLines("input.txt");

        ScratchCards = new ScratchCard[lines.Count() + 1];

        for (int i = 1; i <= lines.Count(); i++)
        {
            ScratchCards[i] = new()
            {
                CardId = i
            };
        }



        foreach (string? line in lines)
        {
            List<int>? n = new();

            string[]? lineContent = line.Split(":");
            string? cardidstr = lineContent[0].Replace("Card ", "");
            int cardid = int.Parse(cardidstr);

            string[]? content = lineContent[1].Split(" |");

            string? winningString = content[0][1..];
            string? numbersString = content[1][1..];

            string[]? splitWin = winningString.Split(" ");
            string[]? splitNum = numbersString.Split(" ");

            splitWin = splitWin.Where(n => n != "").ToArray();
            splitNum = splitNum.Where(n => n != "").ToArray();

            foreach (string? number in splitWin)
            {
                ScratchCards[cardid].WinningNumbers.Add(int.Parse(number));
            }

            foreach (string? number in splitNum)
            {
                n.Add(int.Parse(number));
            }

            ScratchCards[cardid].Numbers = n;

            int countbefore = n.Count();
            n = n.Except(ScratchCards[cardid].WinningNumbers).ToList();
            int countafter = n.Count();



            int foundNumbers = countbefore - countafter;

            for (int i = 0; ScratchCards[cardid].NumberOfCards > i; i++)
            {
                for (int j = 1; j <= foundNumbers; j++)
                {
                    ScratchCards[cardid + j].NumberOfCards++;
                }
            }
        }

        int cards = 0;
        for (int i = 1; i < ScratchCards.Length; i++)
        {
            cards += ScratchCards[i].NumberOfCards;
        }
        Console.WriteLine($"Part 2: {cards}");
    }
}