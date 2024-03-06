public class Program
{
    public const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public const int MinRandomNumber = 1;

    public const int MaxRandomNumber = 26;

    public static void FillArrayWithRandomNumbers(int[] array, int min, int max)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomNumber = new Random().Next(min, max);
            array[i] = randomNumber;
        }
    }

    public static int[] SortArrayForEvenNumbers(int[] numbers)
    {
        return numbers.Where(i => i % 2 == 0).ToArray();
    }

    public static int[] SortArrayForOddNumbers(int[] numbers)
    {
        return numbers.Where(i => i % 2 != 0).ToArray();
    }

    public static char[] ChangeToAlphabetLetters(int[] lettersPositions)
    {
        char[] result = new char[lettersPositions.Length];

        for (int j = 0; j < lettersPositions.Length; j++)
        {
            int letterIndex = lettersPositions[j] - 1;

            if (letterIndex > MaxRandomNumber)
            {
                throw new ArgumentException("Letter position is out of array range");
            }

            switch (Alphabet[letterIndex])
            {
                case 'a':
                    result[j] = 'A';
                    break;
                case 'e':
                    result[j] = 'E';
                    break;
                case 'i':
                    result[j] = 'I';
                    break;
                case 'd':
                    result[j] = 'D';
                    break;
                case 'h':
                    result[j] = 'H';
                    break;
                default:
                    result[j] = Alphabet[letterIndex];
                    break;
            }
        }

        return result;
    }

    public static int CountArrayUppercaseLetters(char[] letters)
    {
        return letters.Where(i => char.IsUpper(i)).ToArray().Length;
    }

    public static string ChooseArrayWithMoreUppercaseLetters(char[] firstArray, char[] secondArray)
    {
        bool isFirstContainsMore = CountArrayUppercaseLetters(firstArray) >
                                        CountArrayUppercaseLetters(secondArray);

        bool isLettersEqual = CountArrayUppercaseLetters(firstArray) ==
                              CountArrayUppercaseLetters(secondArray);

        if (isFirstContainsMore)
        {
            return "First array contains more uppercase letters.";
        }
        else if (isLettersEqual)
        {
            return "Both arrays contains equal amount.";
        }
        else
        {
            return "Second array contains more uppercase letters.";
        }
    }

    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        int[] randomNumbers = new int[n];

        FillArrayWithRandomNumbers(randomNumbers, MinRandomNumber, MaxRandomNumber);

        int[] evenNumbers = SortArrayForEvenNumbers(randomNumbers);

        int[] oddNumbers = SortArrayForOddNumbers(randomNumbers);

        char[] evenNumbersAsLetters = ChangeToAlphabetLetters(evenNumbers);

        char[] oddNumbersAsLetters = ChangeToAlphabetLetters(oddNumbers);

        string evenNumbersResult = string.Concat(evenNumbers.Select(x => x.ToString() + " "));
        string oddNumbersResult = string.Concat(oddNumbers.Select(x => x.ToString() + " "));
        string evenNumbersAsLettersResult = string.Concat(evenNumbersAsLetters.Select(x => x.ToString() + " "));
        string oddNumbersAsLettersResult = string.Concat(oddNumbersAsLetters.Select(x => x.ToString() + " "));

        Console.WriteLine(ChooseArrayWithMoreUppercaseLetters(evenNumbersAsLetters, oddNumbersAsLetters));
        Console.WriteLine("even: " + evenNumbersResult);
        Console.WriteLine("odd: " + oddNumbersResult);
        Console.WriteLine("even: " + evenNumbersAsLettersResult);
        Console.WriteLine("odd: " + oddNumbersAsLettersResult);
    }
}