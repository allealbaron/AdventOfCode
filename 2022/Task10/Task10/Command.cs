namespace AdventOfCode.Year2022
{

    internal class Command
    {
        public enum CommandType
        {
            Add = 0,
            Noop = 1
        }

        public CommandType Type { get; set; }

        public int Value { get; set; }

        public Command(int value)
        {
            Value = value;
            Type = value == 0 ? CommandType.Noop : CommandType.Add;
        }

        public override string ToString()
        {
            return $"{Type.ToString()}: {Value}";
        }
    }

    public enum Step
    {
        Step0 = 0,
        Step1 = 1
    }

}
