namespace ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClubPartyStartUp
    {
        public static void Main()
        {
            int hallsCapacity = int.Parse(Console.ReadLine());

            string[] inputOfPeopleAndHalls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<char> allHalls = new Queue<char>();
            Queue<int> groupsInHall = new Queue<int>();

            for (int i = inputOfPeopleAndHalls.Length - 1; i >= 0; i--)
            {
                if (char.TryParse(inputOfPeopleAndHalls[i], out char currentHall) && !char.IsDigit(currentHall))
                {
                    allHalls.Enqueue(currentHall);
                }
                else if (int.TryParse(inputOfPeopleAndHalls[i], out int currentGroupOfPeople))
                {
                    while (true)
                    {
                        if (allHalls.Count == 0)
                        {
                            break;
                        }

                        if (groupsInHall.Sum() + currentGroupOfPeople > hallsCapacity)
                        {
                            Console.WriteLine($"{allHalls.Dequeue()} -> {string.Join(", ", groupsInHall)}");
                            groupsInHall.Clear();
                        }
                        else if (groupsInHall.Sum() + currentGroupOfPeople <= hallsCapacity)
                        {
                            groupsInHall.Enqueue(currentGroupOfPeople);
                            break;
                        }
                    }
                }
            }
        }
    }
}