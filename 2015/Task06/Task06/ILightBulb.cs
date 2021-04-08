namespace AdventOfCode
{
    /// <summary>
    /// Interface for LightBulbs
    /// </summary>
    public interface ILightBulb
    {
        /// <summary>
        /// Turns a lightbulb on
        /// </summary>
        public void TurnOn();

        /// <summary>
        /// Turns a lightbulb off
        /// </summary>
        public void TurnOff();

        /// <summary>
        /// Toggles a lightbulb
        /// </summary>
        public void Toggle();

    }
}
