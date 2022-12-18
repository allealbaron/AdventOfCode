using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022
{
    public class Monkey
    {

        public IList<Monkey> MonkeyGroup { get; set; }

        public int Id { get; set; }

        public long Inspections { get; set; } = 0;

        public Queue<long> Items { get; set; }

        public Operation Operation { get; set; }

        public long TestDivisible { get; set; }

        public int TrueTestMonkeyId { get; set; }

        public int FalseTestMonkeyId { get; set; }

        public virtual Monkey TrueTestMonkey
        {
            get
            {
                return MonkeyGroup.SingleOrDefault(t => t.Id == TrueTestMonkeyId);
            }
        }

        public virtual Monkey FalseTestMonkey
        {
            get
            {
                return MonkeyGroup.SingleOrDefault(t => t.Id == FalseTestMonkeyId);
            }
        }

        public long ReliefGroup()
        {
            long result = 1;

            foreach (var m in MonkeyGroup.Select(t => t.TestDivisible))
            {
                result *= m;
            }

            return result;

        }



        public Monkey(IList<Monkey> monkeyGroup, int id, Queue<long> items,
            Operation operation,
            long testDivisible,
            int trueTestMonkeyId,
            int falseTestMonkeyId)
        {

            Id = id;
            MonkeyGroup = monkeyGroup;
            Items = items;
            Operation = operation;
            TestDivisible = testDivisible;
            TrueTestMonkeyId = trueTestMonkeyId;
            FalseTestMonkeyId = falseTestMonkeyId;

        }

        public override string ToString()
        {
            return $"{Id}: {Inspections} - {String.Join(",", Items)} ";
        }

        public void CompleteEvaluation(long reliefFactor)
        {

            while (Items.Count > 0)
            {
                
                Inspections++;
                InspectElement(Items.Dequeue(), reliefFactor);
                
            }

        }

        public void InspectElement(long element, long reliefFactor)
        {

            long evaluation;

            if (reliefFactor == 1)
            {

                evaluation = Operation.CalculateValue(element) % ReliefGroup();

            }
            else
            {
                evaluation = (long)Math.Floor((decimal)Operation.CalculateValue(element) / reliefFactor);

            }

            
            if (evaluation % TestDivisible == 0)
            {
                TrueTestMonkey.Items.Enqueue(evaluation);
            }
            else
            {
                FalseTestMonkey.Items.Enqueue(evaluation);
            }

        }
    }
}
