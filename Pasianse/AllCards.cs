using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasianse
{
    public static class AllCards
    {
        /// <summary>
        /// Все игровые карты
        /// </summary>
        public static List<Card> cards = new()
        {
            new Card("14", CardType.BOOBIE, CardNominal.R2),
            new Card("15", CardType.BOOBIE, CardNominal.R3),
            new Card("16", CardType.BOOBIE, CardNominal.R4),
            new Card("17", CardType.BOOBIE, CardNominal.R5),
            new Card("18", CardType.BOOBIE, CardNominal.R6),
            new Card("19", CardType.BOOBIE, CardNominal.R7),
            new Card("20", CardType.BOOBIE, CardNominal.R8),
            new Card("21", CardType.BOOBIE, CardNominal.R9),
            new Card("22", CardType.BOOBIE, CardNominal.R10),
            new Card("23", CardType.BOOBIE, CardNominal.J),
            new Card("24", CardType.BOOBIE, CardNominal.Q),
            new Card("25", CardType.BOOBIE, CardNominal.K),
            new Card("26", CardType.BOOBIE, CardNominal.T),

            new Card("42", CardType.PIKE, CardNominal.R2),
            new Card("43", CardType.PIKE, CardNominal.R3),
            new Card("44", CardType.PIKE, CardNominal.R4),
            new Card("45", CardType.PIKE, CardNominal.R5),
            new Card("46", CardType.PIKE, CardNominal.R6),
            new Card("47", CardType.PIKE, CardNominal.R7),
            new Card("48", CardType.PIKE, CardNominal.R8),
            new Card("49", CardType.PIKE, CardNominal.R9),
            new Card("50", CardType.PIKE, CardNominal.R10),
            new Card("51", CardType.PIKE, CardNominal.J),
            new Card("52", CardType.PIKE, CardNominal.Q),
            new Card("53", CardType.PIKE, CardNominal.K),
            new Card("54", CardType.PIKE, CardNominal.T),

            new Card("1", CardType.CROSS, CardNominal.R2),
            new Card("2", CardType.CROSS, CardNominal.R3),
            new Card("3", CardType.CROSS, CardNominal.R4),
            new Card("4", CardType.CROSS, CardNominal.R5),
            new Card("5", CardType.CROSS, CardNominal.R6),
            new Card("6", CardType.CROSS, CardNominal.R7),
            new Card("7", CardType.CROSS, CardNominal.R8),
            new Card("8", CardType.CROSS, CardNominal.R9),
            new Card("9", CardType.CROSS, CardNominal.R10),
            new Card("10", CardType.CROSS, CardNominal.J),
            new Card("11", CardType.CROSS, CardNominal.Q),
            new Card("12", CardType.CROSS, CardNominal.K),
            new Card("13", CardType.CROSS, CardNominal.T),

            new Card("27", CardType.HEART, CardNominal.R2),
            new Card("28", CardType.HEART, CardNominal.R3),
            new Card("29", CardType.HEART, CardNominal.R4),
            new Card("30", CardType.HEART, CardNominal.R5),
            new Card("31", CardType.HEART, CardNominal.R6),
            new Card("32", CardType.HEART, CardNominal.R7),
            new Card("33", CardType.HEART, CardNominal.R8),
            new Card("34", CardType.HEART, CardNominal.R9),
            new Card("35", CardType.HEART, CardNominal.R10),
            new Card("36", CardType.HEART, CardNominal.J),
            new Card("37", CardType.HEART, CardNominal.Q),
            new Card("38", CardType.HEART, CardNominal.K),
            new Card("39", CardType.HEART, CardNominal.T),
        };

        /// <summary>
        /// Перемешиваем игровые карты
        /// </summary>
        public static void MixCards()
        {
            Random random = new();
            for (int i = 0; i < cards.Count; i++)
            {
                int randomCardIndex = random.Next() % cards.Count;
                Card card = cards[i];
                cards[i] = cards[randomCardIndex];
                cards[randomCardIndex] = card;
            }
        }

        /// <summary>
        /// Раскладывает все карты на начальные позиции
        /// </summary>
        public static void PutCards()
        {
            int[] OpenedCardsStart = new int[7];
            for (int i = 0; i < 7; i++)
            {
                OpenedCardsStart[i] = i * UserView.closedCardsDistance;
            }
            int counter = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < UserView.NumberOfCardsInStacks[i]; j++)
                {
                    if (j >= i)
                    {
                        cards[counter].CardOpened = true;
                        cards[counter].PictureBox.Location = new Point(0, (j - i) * UserView.openedCardsDistance + OpenedCardsStart[i]);
                    }
                    else
                    {
                        cards[counter].CardOpened = false;
                        cards[counter].PictureBox.Location = new Point(0, j * UserView.closedCardsDistance);
                    }
                    cards[counter].PictureBox.BringToFront();
                    counter++;
                }
            }
        } 
    }
}
