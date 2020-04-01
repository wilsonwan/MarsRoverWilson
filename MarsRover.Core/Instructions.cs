using System;
using System.Collections.Generic;
using MarsRover.Core.Enums;

namespace MarsRover.Core
{
    public class Instructions
    {
        public List<CommandInput> Inputs { get; set; }
        public Map Map { get; set; }
        public Rover Rover { get; set; }

        public static void Process(Instructions instructions)
        {
            try
            {
                foreach (var input in instructions.Inputs)
                {
                    if (input != CommandInput.M)
                    {
                        instructions.Rover.Rotate(input);
                    }
                    else
                    {
                        instructions.Rover.Move(instructions.Map);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}