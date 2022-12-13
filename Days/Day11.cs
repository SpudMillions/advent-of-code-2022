using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day11 : DayBase
    {
        internal Day11() : base(11, 2022, "Monkey in the Middle")
        {
        }

        public override void Play()
        {
            var monkeys = CreateMonkeys(Input);
            var rounds = 0;

            while (rounds < 20)
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var item in monkey.StartingItems)
                    {
                        var valueToOperateWith = monkey.OperationString == "old" ? item : long.Parse(monkey.OperationString);
                        var newWorryLevel =(long)Math.Floor((double)(monkey.Operation(item, valueToOperateWith))/3);
                        monkey.IncreaseItemInspectedCount();
  
                        if (newWorryLevel % monkey.OperationValue == 0)
                        {
                            var monkeyToCatch = monkeys.First(x => x.Id == monkey.TrueTarget);
                            monkeyToCatch.AddItem(newWorryLevel);
                        }
                        else
                        {
                            var monkeyToCatch = monkeys.First(x => x.Id == monkey.FalseTarget);
                            monkeyToCatch.AddItem(newWorryLevel);
                        }
                    }
                    
                    monkey.StartingItems.Clear();
                }
                rounds++;
            }
            var topTwo = monkeys.OrderByDescending(x => x.InspectedItemCount).Take(2).ToList();
            var result = topTwo[0].InspectedItemCount * topTwo[1].InspectedItemCount;
            Console.WriteLine($"{GetType().Name} : {Title} --- Monkey Business After 1000 rounds: {result}.");
            
            
            var monkeys2 = CreateMonkeys(Input);
            var rounds2 = 0;

            while (rounds2 < 10000)
            {
                var ProductOfOperationValues = monkeys2.Aggregate(1, (c, m) => c * m.OperationValue);
                foreach (var monkey in monkeys2)
                {
                    foreach (var item in monkey.StartingItems)
                    {
                        var valueToOperateWith = monkey.OperationString == "old" ? item : long.Parse(monkey.OperationString);
                        var newWorryLevel = monkey.Operation(item, valueToOperateWith) % ProductOfOperationValues;
                        monkey.IncreaseItemInspectedCount();

                        if ((newWorryLevel) % (monkey.OperationValue) == 0)
                        {
                            var monkeyToCatch = monkeys2.First(x => x.Id == monkey.TrueTarget);
                            monkeyToCatch.AddItem(newWorryLevel);
                        }
                        else
                        {
                            var monkeyToCatch = monkeys2.First(x => x.Id == monkey.FalseTarget);
                            monkeyToCatch.AddItem(newWorryLevel);
                        }
                    }
                    
                    monkey.StartingItems.Clear();
                }
                rounds2++;

                if (rounds2 % 10000 == 0)
                {
                    var topTwo2 = monkeys2.OrderByDescending(x => x.InspectedItemCount).Take(2).ToList();
                    var result2 = topTwo2[0].InspectedItemCount * topTwo2[1].InspectedItemCount;
                    Console.WriteLine($"{GetType().Name} : {Title} --- Monkey Business After {rounds2} rounds: {result2}.");
                }
            }
        }

        private IEnumerable<Monkey> CreateMonkeys(List<string> input)
        {
            var monkeys = new List<Monkey>();
            var monkeyCount = 0;
            foreach (var line in input)
            {
                if (line.StartsWith("Monkey"))
                {
                    var monkeyData = new List<string>();
                    for (var i = monkeyCount; i < (monkeyCount + 6); i++)
                    {
                        monkeyData.Add(input[i]);
                    }

                    var id = int.Parse(monkeyData[0].Split(" ")[1].Replace(':', ' ').Trim());
                    var startingItems = new Queue<long>();
                    monkeyData[1].Split(":")[1].Split(",").ToList()
                        .ForEach(x => startingItems.Enqueue(long.Parse(x)));
                    
                    var operation = monkeyData[2].Split(":")[1].Trim();
                    var testDivisor = int.Parse(monkeyData[3].Split(" ")[5].Trim());
                    var trueTarget = int.Parse(monkeyData[4].Split(" ")[9].Trim());
                    var falseTarget = int.Parse(monkeyData[5].Split(" ")[9].Trim());
                    monkeys.Add(new Monkey(id, startingItems, operation, testDivisor, trueTarget, falseTarget));
                    
                    monkeyData.Clear();
                }
                
                monkeyCount++;
                
            }

            return monkeys;
        }
    }
    public enum Operation
    {
        Add,
        Multiply,
    }
    
    public class Monkey
    {
        //made everything public to get answer faster
        //TODO: refactor to private
        public readonly int Id;
        public Queue<long> StartingItems { get; set; }
        public long InspectedItemCount { get; private set; }
        public Func<long, long, long> Operation { get; set; }
        public string OperationString { get; set; }
        private Operation OperationType { get; set; }
        public int OperationValue { get; set; }
        public int TrueTarget { get; set; }
        public int FalseTarget { get; set; }
        
        

        public Monkey(int id, Queue<long> startingItems, string operation, int operationValue, int trueTarget, int falseTarget)
        {
            Id = id;
            StartingItems = startingItems;
            OperationValue = operationValue;
            OperationString = operation.Split(" ")[4].Trim();
            OperationType = operation.Contains('+') ? Days.Operation.Add : Days.Operation.Multiply;
            Operation = OperationType == Days.Operation.Add ? (Func<long, long, long>)((x, y) => x + y) : (x, y) => x * y;
            TrueTarget = trueTarget;
            FalseTarget = falseTarget;
            InspectedItemCount = 0;
        }

        public long GetNextItem()
        {
            return StartingItems.Dequeue();
        }
        
        public void AddItem(long item)
        {
            StartingItems.Enqueue(item);
        }
        
        public void IncreaseItemInspectedCount()
        {
            InspectedItemCount++;
        }
    }
}