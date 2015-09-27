using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokusolver
{

    public struct SaveState 
    { 
        public List<Tuple<TextBox, string>> Boxes;
    }

    public partial class Form1 : Form
    {
        bool foundAnswer = false;
        bool resetAfter = false;
        bool won = false;
        List<Tuple<TextBox, int>> guesses = new List<Tuple<TextBox,int>>();
        List<List<TextBox>> verticals = new List<List<TextBox>>();
        List<List<TextBox>> horizontals = new List<List<TextBox>>();
        List<List<TextBox>> squares = new List<List<TextBox>>();
        List<List<Tuple<TextBox, int>>> poss = new List<List<Tuple<TextBox, int>>>();
        SaveState save = new SaveState();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<TextBox> square1 = new List<TextBox>();
            List<TextBox> square2 = new List<TextBox>();
            List<TextBox> square3 = new List<TextBox>();
            List<TextBox> square4 = new List<TextBox>();
            List<TextBox> square5 = new List<TextBox>();
            List<TextBox> square6 = new List<TextBox>();
            List<TextBox> square7 = new List<TextBox>();
            List<TextBox> square8 = new List<TextBox>();
            List<TextBox> square9 = new List<TextBox>();
            for(int i = 1; i <= 9; i++)
            {
                verticals.Add(new List<TextBox>());
                horizontals.Add(new List<TextBox>());
            }

            for (int i = 1; i <= 9; i++)
            {
                foreach (Control c in this.Controls)
                {
                    
                    if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox Tcontrol = c as TextBox;
                        if (Tcontrol.Name.Contains("y" + i.ToString()))
                        {
                            verticals[i - 1].Add(Tcontrol);
                        }

                    }
                }
            }
            for (int i = 1; i <= 9; i++)
            {
                foreach (Control c in this.Controls)
                {
                    
                    if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox Tcontrol = c as TextBox;
                        if (Tcontrol.Name.Contains("x" + i.ToString()))
                        {
                            horizontals[i - 1].Add(Tcontrol);
                        }

                    }
                }
            }
            square1.Add(x1y1z1);
            square1.Add(x1y2z1);
            square1.Add(x1y3z1);
            square2.Add(x1y4z2);
            square2.Add(x1y5z2);
            square2.Add(x1y6z2);
            square3.Add(x1y7z3);
            square3.Add(x1y8z3);
            square3.Add(x1y9z3);

            square1.Add(x2y1z1);
            square1.Add(x2y2z1);
            square1.Add(x2y3z1);
            square2.Add(x2y4z2);
            square2.Add(x2y5z2);
            square2.Add(x2y6z2);
            square3.Add(x2y7z3);
            square3.Add(x2y8z3);
            square3.Add(x2y9z3);

            square1.Add(x3y1z1);
            square1.Add(x3y2z1);
            square1.Add(x3y3z1);
            square2.Add(x3y4z2);
            square2.Add(x3y5z2);
            square2.Add(x3y6z2);
            square3.Add(x3y7z3);
            square3.Add(x3y8z3);
            square3.Add(x3y9z3);

            square4.Add(x4y1z4);
            square4.Add(x4y2z4);
            square4.Add(x4y3z4);
            square5.Add(x4y4z5);
            square5.Add(x4y5z5);
            square5.Add(x4y6z5);
            square6.Add(x4y7z6);
            square6.Add(x4y8z6);
            square6.Add(x4y9z6);

            square4.Add(x5y1z4);
            square4.Add(x5y2z4);
            square4.Add(x5y3z4);
            square5.Add(x5y4z5);
            square5.Add(x5y5z5);
            square5.Add(x5y6z5);
            square6.Add(x5y7z6);
            square6.Add(x5y8z6);
            square6.Add(x5y9z6);

            square4.Add(x6y1z4);
            square4.Add(x6y2z4);
            square4.Add(x6y3z4);
            square5.Add(x6y4z5);
            square5.Add(x6y5z5);
            square5.Add(x6y6z5);
            square6.Add(x6y7z6);
            square6.Add(x6y8z6);
            square6.Add(x6y9z6);

            square7.Add(x7y1z7);
            square7.Add(x7y2z7);
            square7.Add(x7y3z7);
            square8.Add(x7y4z8);
            square8.Add(x7y5z8);
            square8.Add(x7y6z8);
            square9.Add(x7y7z9);
            square9.Add(x7y8z9);
            square9.Add(x7y9z9);

            square7.Add(x8y1z7);
            square7.Add(x8y2z7);
            square7.Add(x8y3z7);
            square8.Add(x8y4z8);
            square8.Add(x8y5z8);
            square8.Add(x8y6z8);
            square9.Add(x8y7z9);
            square9.Add(x8y8z9);
            square9.Add(x8y9z9);

            square7.Add(x9y1z7);
            square7.Add(x9y2z7);
            square7.Add(x9y3z7);
            square8.Add(x9y4z8);
            square8.Add(x9y5z8);
            square8.Add(x9y6z8);
            square9.Add(x9y7z9);
            square9.Add(x9y8z9);
            square9.Add(x9y9z9);

            squares.Add(square1);
            squares.Add(square2);
            squares.Add(square3);
            squares.Add(square4);
            squares.Add(square5);
            squares.Add(square6);
            squares.Add(square7);
            squares.Add(square8);
            squares.Add(square9);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            won = checkForWin();
            if (won == false)
            {
                
                won = checkForWin();
                Task.Factory.StartNew(() => calculate(), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                won = checkForWin();    
            }
            if (won)
                label1.Text = "Solved!";
        }

        private Tuple<int, int, int> getTextBoxXY(TextBox box)
        {
            int x;
            int y;
            int z;
            x = Convert.ToInt32(box.Name[1].ToString());
            y = Convert.ToInt32(box.Name[3].ToString());
            z = Convert.ToInt32(box.Name[5].ToString());
            return new Tuple<int, int, int>(x,y,z);
        }

        private SaveState CreateSaveState()
        {
            SaveState savestate = new SaveState();
            savestate.Boxes = new List<Tuple<TextBox, string>>();
            foreach(List<TextBox> list1 in verticals)
            {
                foreach (TextBox box in list1)
                {

                    savestate.Boxes.Add(new Tuple<TextBox, string>(box, box.Text));
                }
            }
            return savestate;
        }

        private void calculate()
        {
            
            bool foundAnswer = false;
            //verticals
            foreach (List<TextBox> row in verticals)
            {
                List<int> prefilleds = new List<int>();
                List<int> leftovers = new List<int>();
                foreach (TextBox box in row)
                {
                    if (box.Text != "")
                    {
                        prefilleds.Add(Convert.ToInt32(box.Text));
                    }
                }
                for (int i = 1; i <= 9; i++)
                {
                    bool canFill = true;
                    foreach (int prefilled in prefilleds)
                    {
                        if (i == prefilled)
                            canFill = false;
                    }
                    if (canFill)
                        leftovers.Add(i);
                }
                List<Tuple<TextBox, int>> boxOver = new List<Tuple<TextBox, int>>();
                foreach (TextBox box in row)
                {
                    List<int> Leftovers = leftovers;
                    if (box.Text == "")
                    {
                        for (int i = 0; i <= Leftovers.Count - 1; i++)
                        {
                            int leftover = Leftovers[i];
                            bool canPlace = true;
                            bool _CanPlace = true;
                            bool _canPlace = true;
                            int xValue = getTextBoxXY(box).Item1;
                            int zValue = getTextBoxXY(box).Item3;
                            foreach (TextBox checkBox in horizontals[xValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _canPlace = false;
                            }
                            foreach (TextBox checkBox in squares[zValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _CanPlace = false;
                            }
                            if (_CanPlace == false || _canPlace == false)
                                canPlace = false;
                            if (canPlace)
                            {
                                boxOver.Add(new Tuple<TextBox, int>(box, leftover));
                            }
                        }
                    }
                }

                List<Tuple<TextBox, int>> s1 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s2 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s3 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s4 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s5 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s6 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s7 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s8 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s9 = new List<Tuple<TextBox, int>>();
                foreach (Tuple<TextBox, int> tuple in boxOver)
                {
                    if (tuple.Item2 == 1)
                    {
                        s1.Add(tuple);
                    }
                    if (tuple.Item2 == 2)
                        s2.Add(tuple);
                    if (tuple.Item2 == 3)
                        s3.Add(tuple);
                    if (tuple.Item2 == 4)
                        s4.Add(tuple);
                    if (tuple.Item2 == 5)
                        s5.Add(tuple);
                    if (tuple.Item2 == 6)
                        s6.Add(tuple);
                    if (tuple.Item2 == 7)
                        s7.Add(tuple);
                    if (tuple.Item2 == 8)
                        s8.Add(tuple);
                    if (tuple.Item2 == 9)
                        s9.Add(tuple);
                }
                List<List<Tuple<TextBox, int>>> tupList = new List<List<Tuple<TextBox, int>>>();
                tupList.Add(s1);
                tupList.Add(s2);
                tupList.Add(s3);
                tupList.Add(s4);
                tupList.Add(s5);
                tupList.Add(s6);
                tupList.Add(s7);
                tupList.Add(s8);
                tupList.Add(s9);
                foreach (List<Tuple<TextBox, int>> tups in tupList)
                {
                    if (tups.Count == 1)
                    {
                        tups[0].Item1.Text = tups[0].Item2.ToString();
                        foundAnswer = true;
                    }
                }
            }

            //horizontals
            foreach (List<TextBox> row in horizontals)
            {
                List<int> prefilleds = new List<int>();
                List<int> leftovers = new List<int>();
                foreach (TextBox box in row)
                {
                    if (box.Text != "")
                    {
                        prefilleds.Add(Convert.ToInt32(box.Text));
                    }
                }
                for (int i = 1; i <= 9; i++)
                {
                    bool canFill = true;
                    foreach (int prefilled in prefilleds)
                    {
                        if (i == prefilled)
                            canFill = false;
                    }
                    if (canFill)
                        leftovers.Add(i);
                }
                List<Tuple<TextBox, int>> boxOver = new List<Tuple<TextBox, int>>();
                foreach (TextBox box in row)
                {
                    List<int> Leftovers = leftovers;
                    if (box.Text == "")
                    {
                        for (int i = 0; i <= Leftovers.Count - 1; i++)
                        {
                            int leftover = Leftovers[i];
                            bool canPlace = true;
                            bool _canPlace = true;
                            bool _CanPlace = true;
                            int xValue = getTextBoxXY(box).Item2;
                            int zValue = getTextBoxXY(box).Item3;
                            foreach (TextBox checkBox in verticals[xValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _canPlace = false;
                            }

                            foreach (TextBox checkBox in squares[zValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _CanPlace = false;
                            }
                            if (_CanPlace == false || _canPlace == false)
                                canPlace = false;
                            if (canPlace)
                            {
                                boxOver.Add(new Tuple<TextBox, int>(box, leftover));
                            }
                        }
                    }
                }

                List<Tuple<TextBox, int>> s1 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s2 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s3 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s4 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s5 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s6 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s7 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s8 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s9 = new List<Tuple<TextBox, int>>();
                foreach (Tuple<TextBox, int> tuple in boxOver)
                {
                    if (tuple.Item2 == 1)
                    {
                        s1.Add(tuple);
                    }
                    if (tuple.Item2 == 2)
                        s2.Add(tuple);
                    if (tuple.Item2 == 3)
                        s3.Add(tuple);
                    if (tuple.Item2 == 4)
                        s4.Add(tuple);
                    if (tuple.Item2 == 5)
                        s5.Add(tuple);
                    if (tuple.Item2 == 6)
                        s6.Add(tuple);
                    if (tuple.Item2 == 7)
                        s7.Add(tuple);
                    if (tuple.Item2 == 8)
                        s8.Add(tuple);
                    if (tuple.Item2 == 9)
                        s9.Add(tuple);
                }
                List<List<Tuple<TextBox, int>>> tupList = new List<List<Tuple<TextBox, int>>>();
                tupList.Add(s1);
                tupList.Add(s2);
                tupList.Add(s3);
                tupList.Add(s4);
                tupList.Add(s5);
                tupList.Add(s6);
                tupList.Add(s7);
                tupList.Add(s8);
                tupList.Add(s9);
                foreach (List<Tuple<TextBox, int>> tups in tupList)
                {
                    if (tups.Count == 1)
                    {
                        tups[0].Item1.Text = tups[0].Item2.ToString();
                        foundAnswer = true;
                    }
                }
            }

            //boxes
            foreach (List<TextBox> square in squares)
            {
                List<int> prefilleds = new List<int>();
                List<int> leftovers = new List<int>();
                foreach (TextBox box in square)
                {
                    if (box.Text != "")
                    {
                        prefilleds.Add(Convert.ToInt32(box.Text));
                    }
                }
                for (int i = 1; i <= 9; i++)
                {
                    bool canFill = true;
                    foreach (int prefilled in prefilleds)
                    {
                        if (i == prefilled)
                            canFill = false;
                    }
                    if (canFill)
                        leftovers.Add(i);
                }
                List<Tuple<TextBox, int>> boxOver = new List<Tuple<TextBox, int>>();
                foreach (TextBox box in square)
                {
                    List<int> Leftovers = leftovers;
                    if (box.Text == "")
                    {
                        for (int i = 0; i <= Leftovers.Count - 1; i++)
                        {
                            int leftover = Leftovers[i];
                            bool _canPlace = true;
                            bool _CanPlace = true;
                            bool _Canplace = true;
                            bool canPlace = true;
                            int xValue = getTextBoxXY(box).Item1;
                            int yValue = getTextBoxXY(box).Item2;
                            foreach (TextBox checkBox in horizontals[xValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _canPlace = false;
                            }
                            foreach (TextBox checkBox in verticals[yValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _CanPlace = false;
                            }
                            foreach (TextBox checkBox in square)
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        _Canplace = false;
                            }
                            if (_CanPlace == false || _canPlace == false || _Canplace == false)
                                canPlace = false;
                            if (canPlace)
                            {
                                boxOver.Add(new Tuple<TextBox, int>(box, leftover));
                            }
                        }
                    }
                }

                List<Tuple<TextBox, int>> s1 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s2 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s3 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s4 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s5 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s6 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s7 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s8 = new List<Tuple<TextBox, int>>();
                List<Tuple<TextBox, int>> s9 = new List<Tuple<TextBox, int>>();
                foreach (Tuple<TextBox, int> tuple in boxOver)
                {
                    if (tuple.Item2 == 1)
                    {
                        s1.Add(tuple);
                    }
                    if (tuple.Item2 == 2)
                        s2.Add(tuple);
                    if (tuple.Item2 == 3)
                        s3.Add(tuple);
                    if (tuple.Item2 == 4)
                        s4.Add(tuple);
                    if (tuple.Item2 == 5)
                        s5.Add(tuple);
                    if (tuple.Item2 == 6)
                        s6.Add(tuple);
                    if (tuple.Item2 == 7)
                        s7.Add(tuple);
                    if (tuple.Item2 == 8)
                        s8.Add(tuple);
                    if (tuple.Item2 == 9)
                        s9.Add(tuple);
                }
                List<List<Tuple<TextBox, int>>> tupList = new List<List<Tuple<TextBox, int>>>();
                tupList.Add(s1);
                tupList.Add(s2);
                tupList.Add(s3);
                tupList.Add(s4);
                tupList.Add(s5);
                tupList.Add(s6);
                tupList.Add(s7);
                tupList.Add(s8);
                tupList.Add(s9);
                
                foreach (List<Tuple<TextBox, int>> tups in tupList)
                {
                    poss.Add(tups);
                    if (tups.Count == 1)
                    {
                        tups[0].Item1.Text = tups[0].Item2.ToString();
                        foundAnswer = true;
                    }
                }
            }

            if (foundAnswer == false)
            {
                if(resetAfter)
                {
                    foreach(Tuple<TextBox, string> tup in save.Boxes)
                    {
                        tup.Item1.Text = tup.Item2;
                    }
                }
                save = CreateSaveState();
                bool found = false;
                foreach (List<TextBox> lbox in verticals)
                {
                    
                    foreach (TextBox box in lbox)
                    {
                        
                        if (box.Text == "" && found == false)
                        {
                            
                            bool canAnswer = true;
                            for (int i = 1; i <= 9 && found == false; i++)
                            {
                                canAnswer = true;
                                bool keepChecking = true;
                                foreach (Tuple<TextBox, int> tup in guesses)
                                {
                                    if (tup.Item1.Name == box.Name)
                                    {
                                        if (i == tup.Item2)
                                        {
                                            canAnswer = false;
                                        }
                                    }
                                }
                                if (canAnswer)
                                {
                                    foreach (List<Tuple<TextBox, int>> tups in poss)
                                    {
                                        if (keepChecking)
                                        {
                                            foreach (Tuple<TextBox, int> tup in tups)
                                            {

                                                if (tup.Item1.Name == box.Name)
                                                {
                                                    if (i != tup.Item2)
                                                    {
                                                        canAnswer = false;
                                                    }
                                                    else
                                                    {
                                                        canAnswer = true;
                                                        keepChecking = false;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                                
                                if (canAnswer)
                                {
                                    
                                    box.Text = i.ToString();
                                    resetAfter = true;
                                    guesses.Add(new Tuple<TextBox, int>(box, i));
                                    found = true;
                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool checkForWin()
        {
            bool win = true;
            foreach (List<TextBox> boxes in verticals)
            {
                foreach (TextBox box in boxes)
                {
                    if (box.Text == "")
                    {
                        win = false;
                    }
                }
            }
            return win;
        }
    }
}
