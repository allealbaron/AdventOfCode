using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2015.Operations
{
    public abstract class Operation
    {

        protected const int ITEM_LENGTH = 16;

        public enum OperationEnum
        {
            AssignOperation = 0,
            NotOperation = 1,
            AndOperation = 2,
            OrOperation = 3,
            LShiftOperation = 4,
            RShiftOperation = 5
        }

        protected static string FillLeadingZeros(string input)
        {

            while (input.Length < ITEM_LENGTH)
            {
                input = "0" + input;
            }

            return input;

        }

        protected static string FillAfterZeros(string input)
        {

            while (input.Length < ITEM_LENGTH)
            {
                input += "0";
            }

            return input;

        }

        public abstract OperationEnum OperationType { get; }

        public string Target;

        public bool Processed { get; set; } = false;

        public IList<string> Inputs = new List<string>();

        public IList<UInt16?> Values = new List<UInt16?>();

        public abstract UInt16 GetValue();

    }
}
