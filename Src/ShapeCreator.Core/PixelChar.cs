namespace ShapeCreator.Core
{
    public class PixelChar
    {
        public char CharVal { get; set; }

        public PixelChar(char charVal = DrawingChars.DefaultFillChar)
        {
            CharVal = charVal;
        }
        
    }
}