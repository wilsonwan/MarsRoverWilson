using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MarsRover.Core.Enums;

namespace MarsRover.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var inputs = File.ReadAllText($"{currentDirectory}\\Inputs.txt");
            Console.SetIn(new StringReader(inputs));

            var instructionList = new List<Instructions>();
            var currentInput = Console.ReadLine();

            var coordinates = (currentInput ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var map = new Map()
            {
                MaxX = coordinates.FirstOrDefault(),
                MaxY = coordinates.Skip(1).FirstOrDefault(),
            };

            while (!string.IsNullOrEmpty(currentInput = Console.ReadLine()))
            {
                var instructions = new Instructions()
                {
                    Map = map
                };

                var roverCoordinates = (currentInput ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                instructions.Rover = new Rover(
                    int.Parse(roverCoordinates.FirstOrDefault()),
                    int.Parse(roverCoordinates.Skip(1).FirstOrDefault()),
                    roverCoordinates.Skip(2).FirstOrDefault()
                );

                currentInput = Console.ReadLine();
                instructions.Inputs = currentInput.Select(c => Enum.Parse<CommandInput>(c.ToString())).ToList();

                instructionList.Add(instructions);
                map.Rovers.Add(instructions.Rover);
            }

            foreach (var c in instructionList)
                Instructions.Process(c);

            foreach (var c in instructionList)
                Console.WriteLine($"{c.Rover.XPosition} {c.Rover.YPosition} {c.Rover.Direction}");
        }
    }
}