using System;

namespace AdventOfCode.Year2015.Operations
{
    public class AssignOperation : Operation
    {

        public override OperationEnum OperationType => OperationEnum.AssignOperation;

        public override UInt16 GetValue()
        {
            return Values[0].Value;
        }

    }

}
