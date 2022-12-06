using System;
using System.Text;

namespace AdventOfCode.Year2015.Operations
{
    public class NotOperation : Operation
    {

        public override OperationEnum OperationType => OperationEnum.NotOperation;

        public override UInt16 GetValue()
        {
            var itemArray = Convert.ToString(Values[0].Value, 2);

            itemArray = FillLeadingZeros(itemArray);

            var result = new StringBuilder();

            foreach (var t in itemArray)
            {
                result.Append((t == '1') ? '0' : '1');
            }

            return Convert.ToUInt16(result.ToString(), 2);
        }

    }
}
