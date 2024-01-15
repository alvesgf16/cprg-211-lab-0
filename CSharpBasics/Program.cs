internal class Program
{
  private static void Main(string[] args)
  {
    Console.Write("Enter the low number: ");
    int lowNumber = GetLowPositiveNumber();

    Console.Write("Enter the high number: ");
    int highNumber = GetNumberHigherThan(lowNumber);

    int difference = highNumber - lowNumber;
    Console.WriteLine($"The difference between the high and low numbers is {difference}");

    int quantityOfNumbersBetweenLowAndHigh = difference - 1; // excluding both the low and high numbers
    int[] numbersBetweenLowAndHigh = new int[quantityOfNumbersBetweenLowAndHigh];

    for (int index = 0; index < numbersBetweenLowAndHigh.Length; index += 1)
    {
      numbersBetweenLowAndHigh[index] = index + lowNumber + 1;
    }

    string pathName = @"..\..\..\numbers.txt";
    WriteNumbersToFile(pathName, numbersBetweenLowAndHigh.Reverse().ToArray());
    
    List<double> numbersBetweenHighAndLow = ReadNumbersFromFile(pathName);
    Console.WriteLine($"The sum of the numbers between {lowNumber} and {highNumber} is {numbersBetweenHighAndLow.Sum()}");
    
    Console.WriteLine($"The prime numbers between {lowNumber} and {highNumber} are:");
    foreach (int number in numbersBetweenLowAndHigh)
    {
      if (IsPrime(number))
      {
        Console.WriteLine(number);
      }
    }
  }

  static int GetLowPositiveNumber()
  {
    while (true)
    {
      string userInput = Console.ReadLine()!;
      bool isSuccessful = int.TryParse(userInput, out int result);
      if (isSuccessful && result > 0) return result;
      Console.Write("Invalid input, please enter a positive low number: ");
    }
  }

  static int GetNumberHigherThan(int lowNumber)
  {
    while (true)
    {
      string userInput = Console.ReadLine()!;
      bool isSuccessful = int.TryParse(userInput, out int result);
      if (isSuccessful && result > lowNumber) return result;
      Console.Write($"Invalid input, please enter a highnumber that is greater than {lowNumber}: ");
    }
  }

  static void WriteNumbersToFile(string fileName, int[] numbers)
  {
        using StreamWriter sw = new(fileName);
        foreach (int number in numbers)
        {
            sw.WriteLine(number);
        }
    }

  static List<double> ReadNumbersFromFile(string fileName)
  {
    List<double> numbers = [];
    using (StreamReader sr = new(fileName))
    {
      string line;
      while ((line = sr.ReadLine()!) != null)
      {
        if (double.TryParse(line, out double number)) {
          numbers.Add(number);
        }
      }
      return numbers;
    }
  }

  static bool IsPrime(int number)
  {
    for (int divisor = 2; divisor < number; divisor += 1)
    {
      if (number % divisor == 0)
      {
        return false;
      }
    }
    return true;
  }
}