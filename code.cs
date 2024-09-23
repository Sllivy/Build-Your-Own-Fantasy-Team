using System;
using System.Collections.Generic;
using static Build_your_own_fantasy_team.Character;

namespace Build_your_own_fantasy_team
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Character> team = new List<Character>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nFantasy Team Builder");
                Console.WriteLine("1. Add Character");
                Console.WriteLine("2. View Team");
                Console.WriteLine("3. Remove Character");
                Console.WriteLine("4. Display Team Stats");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCharacter(team);
                        break;
                    case "2":
                        ViewTeam(team);
                        break;
                    case "3":
                        RemoveCharacter(team);
                        break;
                    case "4":
                        DisplayTeamStats(team);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void AddCharacter(List<Character> team)
        {
            Console.WriteLine("Enter character type (Warrior/Mage/Archer):");
            string type = Console.ReadLine().ToLower();

            Console.WriteLine("Enter Character name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Health:");
            int health = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Strength:");
            int strength = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "warrior":
                    Console.WriteLine("Enter armor value:");
                    int armor = int.Parse(Console.ReadLine());
                    team.Add(new Warrior(name, health, strength, armor));
                    break;

                case "mage":
                    Console.WriteLine("Enter magic power:");
                    int magicPower = int.Parse(Console.ReadLine());
                    team.Add(new Mage(name, health, strength, magicPower));
                    break;

                case "archer":
                    Console.WriteLine("Enter agility:");
                    int agility = int.Parse(Console.ReadLine());
                    team.Add(new Archer(name, health, strength, agility));
                    break;

                default:
                    Console.WriteLine("Invalid character type.");
                    break;
            }
        }

        static void RemoveCharacter(List<Character> team)
        {
            Console.Write("Enter the name of the character to remove:");
            string name = Console.ReadLine();
            team.RemoveAll(c => c.Name == name);
        }

        static void DisplayTeamStats(List<Character> team)
        {
            int totalHealth = 0;
            int totalStrength = 0;

            foreach (Character c in team)
            {
                totalHealth += c.Health;
                totalStrength += c.Strength;
            }

            if (team.Count > 0)
            {
                Console.WriteLine($"Total Team Health: {totalHealth}");
                Console.WriteLine($"Average Team Strength: {totalStrength / team.Count}");
            }
            else
            {
                Console.WriteLine("No characters in the team.");
            }
        }

        static void ViewTeam(List<Character> team)
        {
            if (team.Count > 0)
            {
                foreach (var character in team)
                {
                    Console.WriteLine(character.ToString()); // Assuming ToString() is overridden in Character and subclasses
                }
            }
            else
            {
                Console.WriteLine("No characters in the team.");
            }
        }
    }
}
