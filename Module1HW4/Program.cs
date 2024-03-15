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
        int evenCounter = 0;

        int[] evenNumbers = new int[numbers.Length];

        for (int i = 0; i < evenNumbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                evenNumbers[i] = numbers[i];
                evenCounter++;
            }
        }

        Array.Sort(evenNumbers);
        Array.Reverse(evenNumbers);
        Array.Resize(ref evenNumbers, evenCounter);

        return evenNumbers;
    }

    public static int[] SortArrayForOddNumbers(int[] numbers)
    {
        int oddCounter = 0;

        int[] oddNumbers = new int[numbers.Length];

        for (int i = 0; i < oddNumbers.Length; i++)
        {
            if (numbers[i] % 2 != 0)
            {
                oddNumbers[i] = numbers[i];
                oddCounter++;
            }
        }

        Array.Sort(oddNumbers);
        Array.Reverse(oddNumbers);
        Array.Resize(ref oddNumbers, oddCounter);

        return oddNumbers;
    }

    public static char[] ChangeToAlphabetLetters(int[] lettersPositions)
    {
        char[] result = new char[lettersPositions.Length];
        int letterShift = 1;

        for (int j = 0; j < lettersPositions.Length; j++)
        {
            int letterIndex = lettersPositions[j] - letterShift;

            if (letterIndex > MaxRandomNumber | letterIndex < 0)
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
        int counter = 0;
        foreach (var letter in letters)
        {
            if (char.IsUpper(letter))
            {
                counter++;
            }
        }

        return counter;
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

        if (isLettersEqual)
        {
            return "Both arrays contains equal amount.";
        }

        return "Second array contains more uppercase letters.";
    }

    public static void Main()
    {
        Console.WriteLine("Enter amount of random numbers: ");

        string userInput = Console.ReadLine();

        int n;

        bool success = int.TryParse(userInput, out n);
        if (!success)
        {
            Console.WriteLine($"Invalid user input.");
            return;
        }

        int[] randomNumbers = new int[n];

        FillArrayWithRandomNumbers(randomNumbers, MinRandomNumber, MaxRandomNumber);

        int[] evenNumbers = SortArrayForEvenNumbers(randomNumbers);

        int[] oddNumbers = SortArrayForOddNumbers(randomNumbers);

        char[] evenNumbersAsLetters = ChangeToAlphabetLetters(evenNumbers);

        char[] oddNumbersAsLetters = ChangeToAlphabetLetters(oddNumbers);

        string evenNumbersResult = string.Empty;

        foreach (var number in evenNumbers)
        {
            evenNumbersResult = evenNumbersResult + number + " ";
        }

        string oddNumbersResult = string.Empty;

        foreach (var number in oddNumbers)
        {
            oddNumbersResult = oddNumbersResult + number + " ";
        }

        string evenNumbersAsLettersResult = string.Empty;

        foreach (var letter in evenNumbersAsLetters)
        {
            evenNumbersAsLettersResult = evenNumbersAsLettersResult + letter + " ";
        }

        string oddNumbersAsLettersResult = string.Empty;

        foreach (var letter in oddNumbersAsLetters)
        {
            oddNumbersAsLettersResult = oddNumbersAsLettersResult + letter + " ";
        }

        Console.WriteLine(ChooseArrayWithMoreUppercaseLetters(evenNumbersAsLetters, oddNumbersAsLetters));
        Console.WriteLine("even: " + evenNumbersResult);
        Console.WriteLine("odd: " + oddNumbersResult);
        Console.WriteLine("even letters: " + evenNumbersAsLettersResult);
        Console.WriteLine("odd letters: " + oddNumbersAsLettersResult);
    }
}