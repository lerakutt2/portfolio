using System.Windows.Forms;

namespace Pasianse
{
    public partial class Form1 : Form
    {
        bool newgame = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NewGameButtonClick(object sender, EventArgs e)
        {
            
            if (!newgame) 
            { 
                AceOut1.Visible = true;
                AceOut2.Visible = true;
                AceOut3.Visible = true;
                AceOut4.Visible = true;
                Restart.Visible = true;
                
                AllCards.MixCards();
                AddControls(sender);
                AllCards.PutCards();
                newgame = true;
                tip.Visible = true;
            }
            else
            {
                AllCards.MixCards();
                AddControls(sender);
                AllCards.PutCards();
                AceOut1.Controls.Clear();
                AceOut2.Controls.Clear();
                AceOut3.Controls.Clear();
                AceOut4.Controls.Clear();
            }
            
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            AddControls(sender);
            AllCards.PutCards();
            AceOut1.Controls.Clear();
            AceOut2.Controls.Clear();
            AceOut3.Controls.Clear();
            AceOut4.Controls.Clear();
        }

        private void AddControls(object sender)
        {
            Panel[] panels = new Panel[] { stack1Pane, stack2Pane, stack3Pane, stack4Pane, stack5Pane, stack6Pane, stack7Pane };

            int c = 0;
            for (int j = 0; j < 7; j++)
            {
                if (newgame)
                {
                    panels[j].Controls.Clear();
                }
                for (int i = 0; i < UserView.NumberOfCardsInStacks[j]; i++)
                {
                    panels[j].Visible = true;

                    panels[j].Controls.Add(AllCards.cards[c].PictureBox);
                    if (sender is ToolStripMenuItem tool)
                    {
                        if (newgame) AllCards.cards[c].PictureBox.Click -= PictureBox_Click;
                        if (AllowPutOnClick.Checked)
                        {
                            AllCards.cards[c].PictureBox.Click += PictureBox_Click;
                        }
                        //else
                        //{
                        //    AllCards.cards[c].PictureBox.MouseDown += PictureBox_MouseDown;
                        //    AllCards.cards[c].PictureBox.MouseMove += PictureBox_MouseMove;
                        //    AllCards.cards[c].PictureBox.MouseUp += PictureBox_MouseUp;
                        //}
                    }
                    //Print(Convert.ToString(AllCards.cards[c].PictureBox.Parent.Name));
                    c++; // си ++ хихи
                }
            }
        }

        //private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        //{
        //    if (sender is PictureBox pictureBox)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            pictureBox.BringToFront();
        //            pictureBox.Left = e.X + pictureBox.Left - MouseDownLocation.X;
        //            pictureBox.Top = e.Y + pictureBox.Top - MouseDownLocation.Y;
        //        }
        //    }
        //}

        //private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        //{
        //    if (sender is PictureBox pictureBox)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            Panel[] acesOut = new Panel[] { AceOut1, AceOut2, AceOut3, AceOut4 };
        //            Card card = Card.ConvertToCard(pictureBox); char c = WhereToPut(pictureBox);
        //            Panel[] panels = new Panel[] { stack1Pane, stack2Pane, stack3Pane, stack4Pane, stack5Pane, stack6Pane, stack7Pane };

        //            int i = -1;
        //            if (c == 'k')
        //            {
        //                i = Game.KingMovingCondition(card, panels);
        //            }
        //            else if (c == 'a')
        //            {
        //                PictureBox[] thisStack = card.PictureBox.Parent.Controls.OfType<PictureBox>().ToArray();
        //                i = Game.AceMovingCondition(card, acesOut, thisStack);
        //            }
        //            else if (c == 'c')
        //            {
        //                i = Game.CardMovingCondition(card, panels);
        //            }

        //            if (i > -1)
        //            {
        //                PbClick(pictureBox);
        //            }
        //        }
        //    }
        //}

        //private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        //{
        //    if (sender is PictureBox pictureBox)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            MouseDownLocation = e.Location;
        //            pictureBox.Parent = stack1Pane.Parent;
        //        }
        //    }
        //}

        /// <summary>
        /// Определяем куда можно положить карту
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns>'a' - в стеки сброса, 'k' - на пустое место (карта - король), 'c' - в другую стопку</returns>
        public char WhereToPut(Card card)
        {
            Panel[] acesOut = new Panel[] { AceOut1, AceOut2, AceOut3, AceOut4 };
            bool aceCondition = false;

            for (int i = 0; i < 4; i++) // определаем, может ли карта лечь в стеки сброса
            {
                if (acesOut[i].Controls.OfType<PictureBox>().Any())
                {
                    if (Card.ConvertToCard(acesOut[i].Controls.OfType<PictureBox>().First()).IsStrongNextTo(card))
                    {
                        aceCondition = true;
                        break;
                    }
                }
                if (card.Nominal == CardNominal.T)
                {
                    aceCondition = true;
                    break;
                }
            }

            if (card.Nominal == CardNominal.K) return 'k';
            else if (card.PictureBox.Parent.Controls.OfType<PictureBox>().First() == card.PictureBox && aceCondition) return 'a';
            else return 'c';
        }
        private void PictureBox_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                Panel[] panels = new Panel[] { stack1Pane, stack2Pane, stack3Pane, stack4Pane, stack5Pane, stack6Pane, stack7Pane };
                Panel[] acesOut = new Panel[] { AceOut1, AceOut2, AceOut3, AceOut4 };

                Card card = Card.ConvertToCard(pictureBox);

                char c = WhereToPut(card);
                if (c == 'k')
                {
                    Game.MoveToAces(card, panels);
                    Game.MoveKing(card, panels);
                }
                else if (c == 'a') Game.MoveToAces(card, acesOut);
                else if (c == 'c') Game.MoveCards(card, panels);

                if (Game.IsGameEnded(panels))
                {
                    MessageBox.Show("Игра завершена!");
                }
            }
        }

        private void ChangeBackImage(string name)
        {
            Panel[] panels = new Panel[] { stack1Pane, stack2Pane, stack3Pane, stack4Pane, stack5Pane, stack6Pane, stack7Pane };
            Panel[] acesOut = new Panel[] { AceOut1, AceOut2, AceOut3, AceOut4 };
            UserView.BackgroundTheme theme = new UserView.BackgroundTheme(name);

            ActiveForm.BackgroundImage = theme.BackImage;
            ActiveForm.BackgroundImageLayout = ImageLayout.Tile;
            menuStrip1.BackgroundImage = theme.BackImage;
            for (int i = 0; i < 7; i++)
            {
                panels[i].BackColor = theme.PanelFrontColor;
                if (i < 4)
                {
                    acesOut[i].BackColor = theme.PanelFrontColor;
                }
            }
            foreach (ToolStripMenuItem control in menuStrip1.Items)
            {
                control.ForeColor= theme.TextForeColor;
                control.BackColor = theme.TextBackColor;
            }
            foreach (ToolStripMenuItem control in Background.DropDownItems) 
            { 
                if (control.Name == name)
                {
                    control.Checked = true;
                }
                else
                {
                    control.Checked = false;
                }
            }
        }

        private void green1_Click(object sender, EventArgs e)
        {
            ChangeBackImage("green1");
        }

        private void green2_Click(object sender, EventArgs e)
        {
            ChangeBackImage("green2");
        }

        private void wood1_Click(object sender, EventArgs e)
        {
            ChangeBackImage("wood1");
        }

        private void wood2_Click(object sender, EventArgs e)
        {
            ChangeBackImage("wood2");
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            rule.Visible = true;
            CloseButton.Visible = true;
            rule.BringToFront();
            CloseButton.BringToFront();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            rule.Visible = false;
            CloseButton.Visible = false;
        }

        private void tip_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < AllCards.cards.Count; i++)
            {
                Panel[] panels = new Panel[] { stack1Pane, stack2Pane, stack3Pane, stack4Pane, stack5Pane, stack6Pane, stack7Pane };
                Card card = Card.ConvertToCard(AllCards.cards[i].PictureBox);
                char c = WhereToPut(card);
                if (c == 'c' && !Game.CardMovingConditionForTip(card, panels))
                {
                    count++;
                }
            }

            if (count < 52)
            { 
                tipanswer.Text = "Ходы есть";
            }
            else { tipanswer.Text = "Ходов нет"; }
        }
    }
}