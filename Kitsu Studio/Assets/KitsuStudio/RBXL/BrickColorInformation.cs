namespace KitsuStudio.RBXL
{
    public class BrickColorInformation
    {
        public int brickColorId;
        public int colorR;
        public int colorG;
        public int colorB;

        /// <summary>
        /// Stores the information for BrickColors so they can be easily accessed
        /// </summary>
        /// <param name="brickColorId">The Color ID of the BrickColor</param>
        /// <param name="colorR">Red Color Channel</param>
        /// <param name="colorG">Green Color Channel</param>
        /// <param name="colorB">Blue Color Channel</param>
        public BrickColorInformation(int brickColorId, int colorR, int colorG, int colorB)
        {
            this.brickColorId = brickColorId;
            this.colorR = colorR;
            this.colorG = colorG;
            this.colorB = colorB;
        }
        
        
    }
}