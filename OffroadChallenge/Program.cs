namespace OffroadChallenge;

public class Program
{
    static void Main()
    {
        Stack<int> initialFuel = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        Queue<int> addConsumption = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        Queue<int> neededFuel = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        int initialStackCount = initialFuel.Count();
        int altitudeCount = 0;
        Queue<int> reachedAltitudes = new();

        while (initialFuel.Count > 0)
        {
            int result = initialFuel.Pop() - addConsumption.Dequeue();
            altitudeCount++;
            if (result >= neededFuel.Dequeue())
            {
                Console.WriteLine($"John has reached: Altitude {altitudeCount}");
                reachedAltitudes.Enqueue(altitudeCount);
            }
            else if (result < neededFuel.Dequeue())
            {
                Console.WriteLine($"John did not reach: Altitude {altitudeCount}");
                break;
            }
        }

        if (reachedAltitudes.Count == 0)
        {
            Console.WriteLine("John failed to reach the top.");
            Console.WriteLine("John didn't reach any altitude.");
        }
        else if (reachedAltitudes.Count > 0 &&
            reachedAltitudes.Count < initialStackCount)
        {
            Console.WriteLine("John failed to reach the top.");
            Console.Write("Reached altitudes: ");
            for (int i = 0; i < reachedAltitudes.Count - 1; i++)
            {
                Console.Write($"Altitude {reachedAltitudes.Dequeue()}, ");
            }
            Console.Write($"Altitude {reachedAltitudes.Dequeue()}");
        }
        else if (reachedAltitudes.Count == initialStackCount)
        {
            Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
        }
    }
}