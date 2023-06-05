using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasianse
{
    public class UserView
    {
        public const int stackDictance = 7;
        public const int closedCardsDistance = 15;
        public const int openedCardsDistance = 40;
        public static readonly int[] NumberOfCardsInStacks = { 1, 6, 7, 8, 9, 10, 11 };

        public class BackgroundTheme
        {
            public Image BackImage = Properties.Resources._1;
            public Color PanelFrontColor = Color.DarkGreen;
            public Color TextForeColor = Color.White;
            public Color TextBackColor = Color.Empty;

            public BackgroundTheme(string name)
            {
                if (name == "green1")
                {
                    BackImage = Properties.Resources._1;
                    PanelFrontColor = Color.DarkGreen;
                    TextForeColor = Color.White;
                    TextBackColor = Color.Empty;
                }
                else if (name == "green2")
                {
                    BackImage = Properties.Resources._4;
                    PanelFrontColor = Color.DarkGreen;
                    TextForeColor = Color.White;
                    TextBackColor = Color.Empty;
                }
                else if (name == "wood1")
                {
                    BackImage = Properties.Resources._3;
                    PanelFrontColor = Color.SaddleBrown;
                    TextForeColor = Color.Black;
                    TextBackColor = Color.White;
                }
                else if (name == "wood2")
                {
                    BackImage = Properties.Resources._2;
                    PanelFrontColor = Color.SaddleBrown;
                    TextForeColor = Color.White;
                    TextBackColor = Color.Empty;
                }
            }
        }
    }
}
