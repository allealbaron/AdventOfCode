using System;
using System.Text;

namespace AdventOfCode.Year2015.Operations
{
    internal class RShiftOperation : Operation
    {

        public override OperationEnum OperationType => OperationEnum.RShiftOperation;

        public override UInt16 GetValue()
        {

            var itemArray = Convert.ToString(Values[0].Value, 2);

            itemArray = FillLeadingZeros(itemArray);

            var result = new StringBuilder();

            for (var i = 0; i < Values[1]; i++)
            {
                result.Append("0");
            }

            for (var i = Values[1].Value; i < itemArray.Length; i++)
            {
                result.Append(itemArray[i - Values[1].Value]);
            }

            return Convert.ToUInt16(FillLeadingZeros(result.ToString()), 2);

        }

    }
}
