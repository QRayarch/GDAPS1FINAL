using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RougeMap.MapStuff
{
    class DisplayChar
    {
        private char charToDisplay='.';
        public char CharToDisplay 
        {
            get
            {
                return charToDisplay;
            }
        }

        private Brush brushColor;
        public Brush BrushColor
        {
            get
            {
                return brushColor;
            }
        }

        public DisplayChar(char charToDisplay)
        {
            this.charToDisplay = charToDisplay;
        }

        /// <summary>
        /// Pass in Brushes.COLOR_NAME 
        /// </summary>
        /// <param name="charToDisplay"></param>
        /// <param name="brushColor"></param>
        public DisplayChar(char charToDisplay, Brush brushColor)
            : this(charToDisplay)
        {
            this.brushColor = brushColor;
        }
    }
}
