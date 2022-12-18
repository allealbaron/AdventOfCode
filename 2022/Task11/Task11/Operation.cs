using System;
using System.ComponentModel;

namespace AdventOfCode.Year2022
{
    public class Operation
    {

        public enum SelfOperationType
        {
            None = 0,
            SelfOperation = 1
        }

        public enum OperationTypeEnum
        {
            Addition = 0,
            Subtraction = 1,
            Product = 2,
            Division = 3
        }

        public OperationTypeEnum OperationType { get; set; }

        public SelfOperationType SelfOperation { get; set; }

        private long _factor;

        public Operation(string operation, long? factor)
        {
            
            OperationType = operation switch
            {
                "+" => OperationTypeEnum.Addition,
                "-" => OperationTypeEnum.Subtraction,
                "*" => OperationTypeEnum.Product,
                "/" => OperationTypeEnum.Division,
                _ => throw new InvalidEnumArgumentException("Wrong operation")
            };

            SelfOperation = factor.HasValue
                                ? SelfOperationType.None
                                : SelfOperationType.SelfOperation;

            _factor = factor.HasValue ? factor.Value : 0;
            
        }

        public long GetFactor(long input)
        {
            return SelfOperation == SelfOperationType.None
                ? _factor
                : input;
        }


        public long CalculateValue(long input)
        {

            switch (OperationType)
            {
                case OperationTypeEnum.Addition:
                    return input + GetFactor(input);
                case OperationTypeEnum.Subtraction:
                    return input - GetFactor(input);
                case OperationTypeEnum.Product:
                    return input * GetFactor(input);
                case OperationTypeEnum.Division:
                    return (long)Math.Round((decimal)(input / GetFactor(input)));
                default:
                    throw new ArithmeticException("Operation not supported");
            }

        }

        public override string ToString()
        {
            return $"Operation: {SelfOperation} {OperationType} {_factor}";
        }

    }
}
