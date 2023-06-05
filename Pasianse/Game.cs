using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pasianse
{

    /// <summary>
    /// Это класс описания логики игры,
    /// методы из которого вызываются классом Form1
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Передвигает все карты, которые выше той карты, на которую кликнули
        /// </summary>
        /// <param name="stackToDrag">Вся стопка с выбранной картой</param>
        /// <param name="location">Положение первой(выбранной) карты</param>
        /// <param name="card">Выбранная карта</param>
        /// <param name="panels">Панели со всеми стопками</param>
        /// <param name="i">Номер перекладываемой стопки в массиве панелей</param>
        public static void MoveStack(PictureBox[] stackToDrag, Point location, Card card, Panel[] panels, int i)
        {
            int c = 0;
            int b = 0;
            
            for (int j = 0; j < stackToDrag.Length; j++) // определяем индекс нажатой карты в её панели
            {
                if (stackToDrag[j].Equals(card.PictureBox))
                {
                    b = j;
                    c = j;
                    break;
                }
            }
            int d = stackToDrag.Length - 1;
            int distanceMultiplier = 1;
            if (card.Nominal == CardNominal.K) { distanceMultiplier = 0; }

            foreach (PictureBox pictureBox in stackToDrag) // перемещаем PictureBox-ы выше выбранной карты по одному
            {
                if (d <= c)
                {
                    panels[i].Controls.Add(stackToDrag[c]);
                    stackToDrag[c].Location = new Point { X = location.X, Y = location.Y + distanceMultiplier * UserView.openedCardsDistance };
                    stackToDrag[c].BringToFront();
                    c--;
                    distanceMultiplier++;
                }
                d--;
            }

            if (stackToDrag.Length - 1 != b) 
            {
                if (!Card.ConvertToCard(stackToDrag[b + 1]).IsFrontSide) // открываем катру при необходимости
                {
                    Card.ConvertToCard(stackToDrag[b + 1]).CardOpened = true;
                }
            }

        }
        
        /// <summary>
        /// Передвигает обычные карты (карты кроме короля и тех, которые можно положить в стеки сброса)
        /// </summary>
        /// <param name="card"></param>
        /// <param name="panels"></param>
        public static void MoveCards(Card card, Panel[] panels) 
        {
            PictureBox[] stackToDrag = card.PictureBox.Parent.Controls.OfType<PictureBox>().ToArray();
            int i = CardMovingCondition(card, panels);
            if (i > -1)
            {
                PictureBox[] stackToPut = panels[i].Controls.OfType<PictureBox>().ToArray();
                if (card.IsNextTo(Card.ConvertToCard(stackToPut[0])) && card.IsFrontSide && !stackToPut.SequenceEqual(stackToDrag))
                {
                    MoveStack(stackToDrag, stackToPut[0].Location, card, panels, i);
                }
            }
        }
        /// <summary>
        /// Проверяет, можно ли положить обычную карту куда-либо
        /// </summary>
        /// <param name="card"></param>
        /// <param name="panels"></param>
        /// <returns>Номер стопки, в которую положится карта или -1, если нельзя положить никуда</returns>
        public static int CardMovingCondition(Card card, Panel[] panels)
        {
            for (int i = 0; i < 7; i++)
            {
                PictureBox[] stackToDrag = card.PictureBox.Parent.Controls.OfType<PictureBox>().ToArray();

                if (panels[i].Controls.OfType<PictureBox>().ToArray().Length > 0)
                {
                    PictureBox[] stackToPut = panels[i].Controls.OfType<PictureBox>().ToArray();
                    if (card.IsNextTo(Card.ConvertToCard(stackToPut[0])) && card.IsFrontSide && !stackToPut.SequenceEqual(stackToDrag))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

       /// <summary>
       /// Перемещает короля
       /// </summary>
       /// <param name="card"></param>
       /// <param name="panels"></param>
        public static void MoveKing(Card card, Panel[] panels)
        {
            PictureBox[] stackToDrag = card.PictureBox.Parent.Controls.OfType<PictureBox>().ToArray();
            int i = KingMovingCondition(card, panels);
            if (i > -1)
            {
                MoveStack(stackToDrag, new Point(0, 0), card, panels, i);
            }
        }
        /// <summary>
        /// Проверяет, можно ли переложить короля куда-либо
        /// </summary>
        /// <param name="card"></param>
        /// <param name="panels"></param>
        /// <returns>Номер стопки, в которую положится карта или -1, если нельзя положить никуда</returns>
        public static int KingMovingCondition(Card card, Panel[] panels)
        {
            for (int i = 0; i < 7; i++)
            {
                if (panels[i].Controls.Count == 0 && card.IsFrontSide)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Перемещает карту в стеки сброса
        /// </summary>
        /// <param name="card"></param>
        /// <param name="acesOut"></param>
        public static void MoveToAces(Card card, Panel[] acesOut) 
        {
            PictureBox[] thisStack = card.PictureBox.Parent.Controls.OfType<PictureBox>().ToArray();
            int i = AceMovingCondition(card, acesOut, thisStack);
            if (i > -1)
            {
                if (card.Nominal == CardNominal.T)
                {
                    acesOut[i].Controls.Add(card.PictureBox);
                    card.PictureBox.Location = new Point { X = 0, Y = 0 };
                    card.PictureBox.BringToFront();
                    if (thisStack.Length > 1)
                    {
                        if (!Card.ConvertToCard(thisStack[1]).IsFrontSide) Card.ConvertToCard(thisStack[1]).CardOpened = true; ;
                    }
                }
                else
                {
                    acesOut[i].Controls.Add(card.PictureBox);
                    card.PictureBox.Location = new Point { X = 0, Y = 0 };
                    card.PictureBox.BringToFront();
                    if (thisStack.Length > 1)
                    {
                        if (!Card.ConvertToCard(thisStack[1]).IsFrontSide) Card.ConvertToCard(thisStack[1]).CardOpened = true;
                    }
                }
            }
        }
        /// <summary>
        /// Проверяет, можно ли переложить карту в стеки сброса
        /// </summary>
        /// <param name="card"></param>
        /// <param name="acesOut"></param>
        /// <param name="thisStack"></param>
        /// <returns>Номер стопки, в которую положится карта или -1, если нельзя положить никуда</returns>
        public static int AceMovingCondition(Card card, Panel[] acesOut, PictureBox[] thisStack)
        {
            if (card.Nominal == CardNominal.T)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (!acesOut[i].Controls.OfType<PictureBox>().Any())
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (acesOut[i].Controls.OfType<PictureBox>().Any())
                    {
                        if (Card.ConvertToCard(acesOut[i].Controls.OfType<PictureBox>().First()).IsStrongNextTo(card))
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Нужен для проверки наличия ходов
        /// </summary>
        /// <param name="card"></param>
        /// <param name="panels"></param>
        /// <returns>true, если можно переложить какую-либо из открытых карт</returns>
        public static bool CardMovingConditionForTip(Card card, Panel[] panels)
        {
            for (int i = 0; i < 7; i++)
            {
                PictureBox[] stackToDrag = card.PictureBox.Parent.Controls.OfType<PictureBox>().ToArray();

                if (panels[i].Controls.OfType<PictureBox>().ToArray().Length > 0)
                {
                    PictureBox[] stackToPut = panels[i].Controls.OfType<PictureBox>().ToArray();
                    if (card.IsNextTo(Card.ConvertToCard(stackToPut[0])) && card.IsFrontSide && !stackToPut.SequenceEqual(stackToDrag)
                        && stackToDrag.Length > 0)
                    {
                        if (Card.ConvertToCard(stackToDrag[1]).Nominal != Card.ConvertToCard(stackToPut[0]).Nominal 
                            && Card.ConvertToCard(stackToDrag[1]).Type != Card.ConvertToCard(stackToPut[0]).Type)
                        return true;
                    }
                }
            }
            return false;
        }
        
        /// <summary>
        /// Проверяет, собран ли пасьянс
        /// </summary>
        /// <param name="panels"></param>
        /// <returns></returns>
        public static bool IsGameEnded(Panel[] panels)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                PictureBox[] stack = panels[i].Controls.OfType<PictureBox>().ToArray();
                if (stack.Length > 0)
                {
                    if (!Card.ConvertToCard(stack[stack.Length - 1]).IsFrontSide)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
