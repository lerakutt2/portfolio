using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pasianse
{
    /// <summary>
    /// Масти
    /// </summary>
    public enum CardType
    {
        BOOBIE, CROSS, PIKE, HEART
    }

    /// <summary>
    /// Номинал
    /// </summary>
    public enum CardNominal
    {
        R2, R3, R4, R5, R6, R7, R8, R9, R10, J, Q, K, T
    }

    /// <summary>
    /// Карта
    /// </summary>
    public class Card
    {
        // Высота и ширина PictureBox-а
        private static int Height = 159;
        private static int Width = 114;

        private string frontImageName;
        private static string backImageName = "cardBackSide.jpg";
        public PictureBox PictureBox { get; set; }
        public CardType Type { get; set; }
        public CardNominal Nominal { get; set; }
        /// <summary>
        /// Закрывает или открывает карту
        /// </summary>
        public bool CardOpened
        {
            set
            {
                if (value)
                {
                    IsFrontSide = value;
                    SetImage(PictureBox, frontImageName);
                }
                else
                {
                    IsFrontSide = value;
                    SetImage(PictureBox, backImageName);
                }
            }
        }

        /// <summary>
        /// Проверка какой стороной лежит карта
        /// </summary>
        public bool IsFrontSide { get; set; }

        /// <summary>
        /// Задаёт параметры PictureBox-а, соответствующего карте
        /// </summary>
        /// <returns></returns>
        private PictureBox InitCardPictureBox()
        {
            PictureBox = new PictureBox
            {
                Width = Width,
                Height = Height
            };
            PictureBox.BringToFront();
            return PictureBox;
        }
        /// <summary>
        /// Задаёт изображение
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="imageName"></param>
        private void SetImage(PictureBox pictureBox, string imageName)
        {
            pictureBox.Load("images/cards/" + imageName);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Конструктор карты со всеми необходимыми параметрами
        /// </summary>
        /// <param name="frontSide">путь к файлу с фронтальной стороной карты</param>
        /// <param name="type">тип карты из перечисления</param>
        /// <param name="nominal">номинал карты из перечисления</param>
        public Card(string frontSide, CardType type, CardNominal nominal)
        {
            Type = type;
            Nominal = nominal;
            frontImageName = "1 (" + frontSide + ").jpg";
            PictureBox = InitCardPictureBox();
            IsFrontSide = true;
            CardOpened = true;
        }
        /// <summary>
        /// Возвращает карту, которой соответствует PictureBox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Card ConvertToCard(PictureBox pictureBox)
        {
            for (int i = 0; i < AllCards.cards.Count; i++)
            {
                if (pictureBox == AllCards.cards[i].PictureBox)
                {
                    Card card = AllCards.cards[i];
                    return card;
                }
            }
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверить что карту можно положить на другую карту в игровых стеках
        /// </summary>
        /// <param name="card">Карта для сравнения</param>
        /// <returns>True, если карту можно положить на другую</returns>
        /// <exception cref="Exception"></exception>
        public bool IsNextTo(Card card)
        {
            bool b = false;
            if ((card.Type == CardType.BOOBIE || card.Type == CardType.HEART) && (Type == CardType.PIKE || Type == CardType.CROSS)
                || (Type == CardType.BOOBIE || Type == CardType.HEART) && (card.Type == CardType.PIKE || card.Type == CardType.CROSS)) 
            {
                b = true;
            }
            // карту можно положить на другую, если она следующая по номиналу после нее и другого цвета
            if (b)
            {
                switch (Nominal)
                {
                    case CardNominal.K: return false;
                    case CardNominal.Q: return card.Nominal.Equals(CardNominal.K);
                    case CardNominal.J: return card.Nominal.Equals(CardNominal.Q);
                    case CardNominal.R10: return card.Nominal.Equals(CardNominal.J);
                    case CardNominal.R9: return card.Nominal.Equals(CardNominal.R10);
                    case CardNominal.R8: return card.Nominal.Equals(CardNominal.R9);
                    case CardNominal.R7: return card.Nominal.Equals(CardNominal.R8);
                    case CardNominal.R6: return card.Nominal.Equals(CardNominal.R7);
                    case CardNominal.R5: return card.Nominal.Equals(CardNominal.R6);
                    case CardNominal.R4: return card.Nominal.Equals(CardNominal.R5);
                    case CardNominal.R3: return card.Nominal.Equals(CardNominal.R4);
                    case CardNominal.R2: return card.Nominal.Equals(CardNominal.R3);
                    case CardNominal.T: return card.Nominal.Equals(CardNominal.R2);
                    default: throw new Exception();
                }
            }
            return false;
        }

        /// <summary>
        /// Проверить что карту можно положить на другую карту в стеках сброса
        /// </summary>
        /// <param name="card">Карта для сравнения</param>
        /// <returns>True, если карту можно положить на другую</returns>
        /// <exception cref="Exception"></exception>
        public bool IsStrongNextTo(Card card)
        {
            switch (Nominal)
            {
                case (CardNominal.K): return false;
                case (CardNominal.Q): return card.Nominal.Equals(CardNominal.K) && card.Type.Equals(Type);
                case (CardNominal.J): return card.Nominal.Equals(CardNominal.Q) && card.Type.Equals(Type);
                case (CardNominal.R10): return card.Nominal.Equals(CardNominal.J) && card.Type.Equals(Type);
                case (CardNominal.R9): return card.Nominal.Equals(CardNominal.R10) && card.Type.Equals(Type);
                case (CardNominal.R8): return card.Nominal.Equals(CardNominal.R9) && card.Type.Equals(Type);
                case (CardNominal.R7): return card.Nominal.Equals(CardNominal.R8) && card.Type.Equals(Type);
                case (CardNominal.R6): return card.Nominal.Equals(CardNominal.R7) && card.Type.Equals(Type);
                case (CardNominal.R5): return card.Nominal.Equals(CardNominal.R6) && card.Type.Equals(Type);
                case (CardNominal.R4): return card.Nominal.Equals(CardNominal.R5) && card.Type.Equals(Type);
                case (CardNominal.R3): return card.Nominal.Equals(CardNominal.R4) && card.Type.Equals(Type);
                case (CardNominal.R2): return card.Nominal.Equals(CardNominal.R3) && card.Type.Equals(Type);
                case (CardNominal.T): return card.Nominal.Equals(CardNominal.R2) && card.Type.Equals(Type);
                default: throw new Exception();
            }
        }
    }
}
