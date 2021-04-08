namespace AdventOfCode
{
    /// <summary>
    /// Lightbulb for the first part
    /// </summary>
    public class LightBulbFirstPart : ILightBulb
    {
        /// <summary>
        /// Status
        /// </summary>
        public enum StatusEnum
        {
            On,
            Off
        }

        /// <summary>
        /// Status
        /// </summary>
        private StatusEnum Status { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        public LightBulbFirstPart()
        {
            this.Status = StatusEnum.Off;
        }

        /// <summary>
        /// Turns the light on
        /// </summary>
        public void TurnOn()
        {
            this.Status = StatusEnum.On;
        }

        /// <summary>
        /// Turns the light off
        /// </summary>
        public void TurnOff()
        {
            this.Status = StatusEnum.Off;
        }

        /// <summary>
        /// Toggles the light
        /// </summary>
        public void Toggle()
        {
            if (this.Status == StatusEnum.On)
            {
                this.Status = StatusEnum.Off;
            }
            else
            {
                this.Status = StatusEnum.On;
            }
        }

        /// <summary>
        /// Returns status
        /// </summary>
        /// <returns>Status</returns>
        public StatusEnum GetStatus()
        {
            return this.Status;
        }

    }
}
