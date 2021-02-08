using System;
using System.Collections.Generic;
using System.Text;

namespace Task02
{
    /// <summary>
    /// Christmas Package
    /// </summary>
    public class ChristmasPackage
    {
        
        /// <summary>
        /// Length
        /// </summary>
        public int Length  { get;set; }
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Returns necessary wrapping
        /// </summary>
        /// <returns>Necessary wrapping</returns>
        public int GetWrapping() 
        {
            int areaBase = GetAreaBase();
            int areaFront = GetAreaFront();
            int areaSide = GetAreaSide();

            int minSide = areaBase;

            if (areaBase > areaFront)
            {
                minSide = areaFront;
            }

            if (minSide > areaSide)
            {
                minSide = areaSide;
            }

            return (2 * areaBase + 2 * areaFront + 2 * areaSide + minSide);

        }

        /// <summary>
        /// Gets Area Base
        /// </summary>
        /// <returns>Area Base</returns>
        public int GetAreaBase()
        {
            return Length * Width;
        }

        /// <summary>
        /// Gets Area Front
        /// </summary>
        /// <returns>Area Front</returns>
        public int GetAreaFront()
        {
            return Length * Height;
        }

        /// <summary>
        /// Gets Area Side
        /// </summary>
        /// <returns>Area Side</returns>
        public int GetAreaSide()
        {
            return Width * Height;
        }

        /// <summary>
        /// Gets ribbons' length
        /// </summary>
        /// <returns>Ribbons' length</returns>
        public int GetRibbonLength()
        {
            int minSide1 = Math.Min(Length, Math.Min(Width, Height));
            int minSide2;

            if (Length == minSide1)
            {
                minSide2 = Math.Min(Width, Height);
            }
            else
            {
                if (Width == minSide1)
                {
                    minSide2 = Math.Min(Length, Height);
                }
                else
                {
                    minSide2 = Math.Min(Length, Width);
                }
            }

            return 2*minSide1 + 2*minSide2 +  GetVolume();

        }

        /// <summary>
        /// Gets Volume
        /// </summary>
        /// <returns>Volume</returns>
        public int GetVolume()
        {
            return Width * Height * Length;
        }

    }
}
