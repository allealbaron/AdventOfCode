using System;
using System.Text;

namespace AdventOfCode.Year2015.Operations
{
    internal class OrOperation : Operation
    {

        public override OperationEnum OperationType => OperationEnum.OrOperation;

        public override UInt16 GetValue()
        {

            var item1Array = Convert.ToString(Values[0].Value, 2);
            var item2Array = Convert.ToString(Values[1].Value, 2);

            item1Array = FillLeadingZeros(item1Array);
            item2Array = FillLeadingZeros(item2Array);

            var result = new StringBuilder();

            for (var i = 0; i < item1Array.Length; i++)
            {
                result.Append((item1Array[i] == '1' || item2Array[i] == '1') ? '1' : '0');
            }

            return Convert.ToUInt16(result.ToString(), 2);

        }

    }
}
