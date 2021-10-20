using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Schema;
using InstructionsConsole;

namespace Application.View
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>
    public partial class Application : Window
    {
        public Application()
        {
            InitializeComponent();
        }

        private void SComboBoxPeg_DropDownClosed(object sender, EventArgs e)
        {
            if (SComboBoxPeg.Text == Peg1.Text)
            {
                for (int x = 0; x != Convert.ToInt32(Slidertruevalue.Text); x++)
                {
                    LeftPeg.Children[x].Visibility = Visibility.Visible;
                }
                for (int y = 0; y != 12; y++)
                {
                    MidPeg.Children[y].Visibility = Visibility.Collapsed;
                    RightPeg.Children[y].Visibility = Visibility.Collapsed;
                }
            }
            else if (SComboBoxPeg.Text == Peg2.Text)
            {
                for (int x = 0; x != Convert.ToInt32(Slidertruevalue.Text); x++)
                {
                    MidPeg.Children[x].Visibility = Visibility.Visible;
                }
                for (int y = 0; y != 12; y++)
                {
                    LeftPeg.Children[y].Visibility = Visibility.Collapsed;
                    RightPeg.Children[y].Visibility = Visibility.Collapsed;
                }
            }
            else if (SComboBoxPeg.Text == Peg3.Text)
            {
                for (int x = 0; x != Convert.ToInt32(Slidertruevalue.Text); x++)
                {
                    RightPeg.Children[x].Visibility = Visibility.Visible;
                }
                for (int y = 0; y != 12; y++)
                {
                    MidPeg.Children[y].Visibility = Visibility.Collapsed;
                    LeftPeg.Children[y].Visibility = Visibility.Collapsed;
                }
            }
        }

        private List<HanoiInstruction> instructionsList;//list of hanoi instruction
        private List<Peg[]> history;//gives specific instruction
        private Peg[] HanoiSet = new Peg[3];//this is the 3 pegs
        public int discvalue
        {
            get { return Convert.ToInt32(Slidertruevalue.Text); }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = new TowerSolver();
            var p1 = new Peg(Peg1.Text, discvalue);
            var p2 = new Peg(Peg2.Text, discvalue);
            var p3 = new Peg(Peg3.Text, discvalue);

            Peg startingPeg = p1;
            Peg endingPeg = p2;
            Peg auxPeg = p3;
            var n1 = Peg1.Text;
            var n2 = Peg2.Text;
            var n3 = Peg3.Text;
            //If to get start Peg
            if (SComboBoxPeg.Text == n1)
            {
                for (int count = 0; count != discvalue; count++)
                {
                    p1.array[count] = true;
                }

                startingPeg = p1;
            }
            else if (SComboBoxPeg.Text == n2)
            {
                for (int count = 0; count != discvalue; count++)
                {
                    p2.array[count] = true;
                }

                startingPeg = p2;
            }
            else if (SComboBoxPeg.Text == n3)
            {
                for (int count = 0; count != discvalue; count++)
                {
                    p3.array[count] = true;
                }
                startingPeg = p3;
            }
            //if to get Endpeg
            if (EComboBoxPeg.Text == n1)
            {
                endingPeg = p1;
            }
            else if (EComboBoxPeg.Text == n2)
            {
                endingPeg = p2;
            }
            else if (EComboBoxPeg.Text == n3)
            {
                endingPeg = p3;
            }
            //if to get aux Peg
            if (n1 != SComboBoxPeg.Text && n1 != EComboBoxPeg.Text)
            {
                auxPeg = p1;
            }
            else if (SComboBoxPeg.Text != n2 && EComboBoxPeg.Text != n2)
            {
                auxPeg = p2;
            }
            else if (SComboBoxPeg.Text != n3 && EComboBoxPeg.Text != n3)
            {
                auxPeg = p3;
            }
            x.GenerateInstruction(discvalue, startingPeg, auxPeg, endingPeg);
            instructionsList = x.instructions;
            InstructionsBox.ItemsSource = instructionsList;
        }

        private int instructindex = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (instructindex == instructionsList.Count) return;
            
            if (instructionsList[instructindex].FromPeg.Name == Peg1.Text)
            {
                LeftPeg.Children[instructionsList[instructindex].Index-1].Visibility = Visibility.Collapsed;
            }
            if (instructionsList[instructindex].FromPeg.Name == Peg2.Text)
            {
                MidPeg.Children[instructionsList[instructindex].Index-1].Visibility = Visibility.Collapsed;
            }
            if (instructionsList[instructindex].FromPeg.Name == Peg3.Text)
            {
                RightPeg.Children[instructionsList[instructindex].Index-1].Visibility = Visibility.Collapsed;
            }
            if (instructionsList[instructindex].ToPeg.Name == Peg1.Text)
            {
                LeftPeg.Children[instructionsList[instructindex].Index-1].Visibility = Visibility.Visible;
            }
            if (instructionsList[instructindex].ToPeg.Name == Peg2.Text)
            {
                MidPeg.Children[instructionsList[instructindex].Index-1].Visibility = Visibility.Visible;
            }
            if (instructionsList[instructindex].ToPeg.Name == Peg3.Text)
            {
                RightPeg.Children[instructionsList[instructindex].Index-1].Visibility = Visibility.Visible;
            }
            instructindex++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (instructindex == 0) return;
            instructindex--;
            if (instructionsList[instructindex].FromPeg.Name == Peg1.Text)
            {
                LeftPeg.Children[instructionsList[instructindex].Index - 1].Visibility = Visibility.Collapsed;
            }
            if (instructionsList[instructindex].FromPeg.Name == Peg2.Text)
            {
                MidPeg.Children[instructionsList[instructindex].Index - 1].Visibility = Visibility.Collapsed;
            }
            if (instructionsList[instructindex].FromPeg.Name == Peg3.Text)
            {
                RightPeg.Children[instructionsList[instructindex].Index - 1].Visibility = Visibility.Collapsed;
            }
            if (instructionsList[instructindex].ToPeg.Name == Peg1.Text)
            {
                LeftPeg.Children[instructionsList[instructindex].Index - 1].Visibility = Visibility.Visible;
            }
            if (instructionsList[instructindex].ToPeg.Name == Peg2.Text)
            {
                MidPeg.Children[instructionsList[instructindex].Index - 1].Visibility = Visibility.Visible;
            }
            if (instructionsList[instructindex].ToPeg.Name == Peg3.Text)
            {
                RightPeg.Children[instructionsList[instructindex].Index - 1].Visibility = Visibility.Visible;
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            for (int y = 0; y != 12; y++)
            {
                LeftPeg.Children[y].Visibility = Visibility.Collapsed;
                MidPeg.Children[y].Visibility = Visibility.Collapsed;
                RightPeg.Children[y].Visibility = Visibility.Collapsed;
            }

            instructionsList = new List<HanoiInstruction>();
            InstructionsBox.ItemsSource = instructionsList;
            instructindex = 0;
        }
    }
}
