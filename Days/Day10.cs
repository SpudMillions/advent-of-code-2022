using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using static System.ConsoleColor;

namespace AdventOfCode.Days
{
    public class Day10 : DayBase
    {
        internal Day10() : base(10, 2022, "Cathode-Ray Tube")
        {
        }

        public override void Play()
        {
            var cpu = new SimpleCpu();

            foreach (var instructions in Input.Select(line => line.Split(' ')))
            {
                switch (instructions[0])
                {
                    case "noop":
                        cpu.Noop();
                        cpu.UpdateSignalStrength();
                        cpu.UpdateCrtScreen();
                        break;
                    case "addx":
                        cpu.Tick();
                        cpu.UpdateSignalStrength();
                        cpu.UpdateCrtScreen();
                        cpu.Tick();
                        cpu.UpdateSignalStrength();
                        cpu.UpdateCrtScreen();
                        cpu.AddX(int.Parse(instructions[1]));
                        
                        
                        break;
                }
            }
            Console.WriteLine($"{GetType().Name} : {Title} --- Signal Strength for X Register is {cpu.GetSignalStrength()} jiggawatts. Rendering CRT Screen: \n");
            cpu.PrintCrtScreen();
        }

        private class SimpleCpu
        {
            private readonly string[,] CrtScreen = new string[6, 40];

            private (int, int) SpritePosition = (0,2);
            private int SignalStrength { get; set; }
            private int Cycle { get; set; }
            private int XRegister { get; set; }
            private readonly List<int> CycleCheckPoints = new List<int>() { 20, 60, 100, 140, 180, 220 };

            public SimpleCpu()
            {
                Cycle = 0;
                XRegister = 1;
            }
            
            private int GetClockCircuitCycle()
            {
                return Cycle;
            }

            private int GetXRegisterValue()
            {
                return XRegister;
            }

            public void UpdateSignalStrength()
            {
                if (CycleCheckPoints.Contains(GetClockCircuitCycle()))
                {
                    SignalStrength += (GetClockCircuitCycle() * GetXRegisterValue());
                }
            }

            public void UpdateCrtScreen()
            {
                var currentCycle = GetClockCircuitCycle();

                if (currentCycle <= 40)
                {
                    var y = currentCycle - 1;
                    CrtScreen[0, y] = IsSpriteVisible(y) ? "#" : ".";
                }
                
                if(currentCycle is > 40 and <= 80)
                {
                    var y = currentCycle - 41;
                    CrtScreen[1, y] = IsSpriteVisible(y) ? "#" : ".";
                }
                
                if(currentCycle is > 80 and <= 120)
                {
                    var y = currentCycle - 81;
                    CrtScreen[2, y] = IsSpriteVisible(y) ? "#" : ".";
                }
                
                if(currentCycle is > 120 and <= 160)
                {
                    var y = currentCycle - 121;
                    CrtScreen[3, y] = IsSpriteVisible(y) ? "#" : ".";
                }
                
                if(currentCycle is > 160 and <= 200)
                {
                    var y = currentCycle - 161;
                    CrtScreen[4, y] = IsSpriteVisible(y) ? "#" : ".";
                }
                
                if(currentCycle is > 200 and <= 240)
                {
                    var y = currentCycle - 201;
                    CrtScreen[5, y] = IsSpriteVisible(y) ? "#" : ".";
                }
                
            }
            
            private void UpdateSpritePosition(int V)
            {
                SpritePosition.Item1 += V;
                SpritePosition.Item2 += V;
            }
            
            private void ResetSpritePosition()
            {
                SpritePosition.Item1 = 0;
                SpritePosition.Item2 = 2;
            }
            
            private bool IsSpriteVisible(int y)
            {
                return SpritePosition.Item1 <= y  && y <= SpritePosition.Item2;
            }

            public int GetSignalStrength()
            {
                return SignalStrength;
            }
            
            public void Tick()
            {
                Cycle++;
            }

            public void Noop()
            {
                Tick();
            }

            public void AddX(int V)
            {
                XRegister += V;
                UpdateSpritePosition(V);
            }
            
            public void PrintCrtScreen()
            {
                for (var i = 0; i < CrtScreen.GetLength(0); i++)
                {
                    for (var j = 0; j < CrtScreen.GetLength(1); j++)
                    {
                        if (CrtScreen[i, j] == "#")
                        {
                            Console.ForegroundColor = Green;
                            Console.Write(CrtScreen[i, j]);
                        }
                        else
                        {
                            // my eyes suck so lets remove the . 
                            ConvertToHD();
                        }
                            
                        
                    }
                    Console.ForegroundColor = White;
                    Console.WriteLine();
                }
            }
            
            private void ConvertToHD()
            {
                Console.Write(' ');
            }
        }
    }
}

