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
        /// <summary>
        /// Gets the chracter to display when rendering.
        /// </summary>
        public char CharToDisplay 
        {
            get
            {
                return charToDisplay;
            }
        }

        private Brush brushColor;
        /// <summary>
        /// Gets the brush for rendering.
        /// </summary>
        public Brush BrushColor
        {
            get
            {
                return brushColor;
            }
        }

        /// <summary>
        /// Creates a renderable character with the given and a color of white.
        /// </summary>
        /// <param name="charToDisplay">The chracter to display when rendering.</param>
        public DisplayChar(char charToDisplay)
        {
            this.charToDisplay = charToDisplay;
            brushColor = Brushes.White;
        }

        /// <summary>
        /// Creates a renderable character with the given chracter and color.
        /// Pass in Brushes.COLOR_NAME. 
        /// </summary>
        /// <param name="charToDisplay">The chracter to display when rendering.</param>
        /// <param name="brushColor">The color to display the character in when rendering.</param>
        public DisplayChar(char charToDisplay, Brush brushColor)
            : this(charToDisplay)
        {
            this.brushColor = brushColor;
        }
    }
}
