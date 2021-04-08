namespace AdventOfCode
{
    /// <summary>
    /// Lightbulb for the second part
    /// </summary>
    public class LightBulbSecondPart: ILightBulb
    {
        /// <summary>
        /// Brightness 
        /// </summary>
        private int Brightness { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        public LightBulbSecondPart()
        {
            this.Brightness = 0;
        }

        /// <summary>
        /// Turns the light on (increases <see cref="Brightness"/>)
        /// </summary>
        public void TurnOn()
        {
            this.Brightness++;
        }

        /// <summary>
        /// Turns the light off (decreases <see cref="Brightness"/>)
        /// </summary>
        public void TurnOff()
        {

            if (this.Brightness > 0)
            {
                this.Brightness--;
            }

        }

        /// <summary>
        /// Toggles the light (Turns the light on twice)
        /// </summary>
        public void Toggle()
        {
            this.TurnOn();
            this.TurnOn();
        }

        /// <summary>
        /// Returns status
        /// </summary>
        /// <returns>Status</returns>
        public int GetBrightness()
        {
            return this.Brightness;
        }

    }
}
