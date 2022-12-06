using System;
using System.Text;

namespace AdventOfCode.Year2015.Operations
{
    internal class LShiftOperation : Operation
    {

        public override OperationEnum OperationType => OperationEnum.LShiftOperation;

        public override UInt16 GetValue()
        {

            var itemArray = Convert.ToString(Values[0].Value, 2);

            itemArray = FillLeadingZeros(itemArray);

            var result = new StringBuilder();

            for (var i = Values[1].Value; i < itemArray.Length; i++)
            {
                result.Append(itemArray[i]);
            }

            return Convert.ToUInt16(FillAfterZeros(result.ToString()), 2);

        }

    }
}
