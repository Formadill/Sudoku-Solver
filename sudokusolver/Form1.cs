using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokusolver
{
    public partial class Form1 : Form
    {
        List<List<TextBox>> verticals = new List<List<TextBox>>();
        List<List<TextBox>> horizontals = new List<List<TextBox>>();
        List<List<TextBox>> squares = new List<List<TextBox>>();
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
            square1.Add(x1y1);
            square1.Add(x1y2);
            square1.Add(x1y3);
            square2.Add(x1y4);
            square2.Add(x1y5);
            square2.Add(x1y6);
            square3.Add(x1y7);
            square3.Add(x1y8);
            square3.Add(x1y9);

            square1.Add(x2y1);
            square1.Add(x2y2);
            square1.Add(x2y3);
            square2.Add(x2y4);
            square2.Add(x2y5);
            square2.Add(x2y6);
            square3.Add(x2y7);
            square3.Add(x2y8);
            square3.Add(x2y9);

            square1.Add(x3y1);
            square1.Add(x3y2);
            square1.Add(x3y3);
            square2.Add(x3y4);
            square2.Add(x3y5);
            square2.Add(x3y6);
            square3.Add(x3y7);
            square3.Add(x3y8);
            square3.Add(x3y9);

            square4.Add(x4y1);
            square4.Add(x4y2);
            square4.Add(x4y3);
            square5.Add(x4y4);
            square5.Add(x4y5);
            square5.Add(x4y6);
            square6.Add(x4y7);
            square6.Add(x4y8);
            square6.Add(x4y9);

            square4.Add(x5y1);
            square4.Add(x5y2);
            square4.Add(x5y3);
            square5.Add(x5y4);
            square5.Add(x5y5);
            square5.Add(x5y6);
            square6.Add(x5y7);
            square6.Add(x5y8);
            square6.Add(x5y9);

            square4.Add(x6y1);
            square4.Add(x6y2);
            square4.Add(x6y3);
            square5.Add(x6y4);
            square5.Add(x6y5);
            square5.Add(x6y6);
            square6.Add(x6y7);
            square6.Add(x6y8);
            square6.Add(x6y9);

            square7.Add(x7y1);
            square7.Add(x7y2);
            square7.Add(x7y3);
            square8.Add(x7y4);
            square8.Add(x7y5);
            square8.Add(x7y6);
            square9.Add(x7y7);
            square9.Add(x7y8);
            square9.Add(x7y9);

            square7.Add(x8y1);
            square7.Add(x8y2);
            square7.Add(x8y3);
            square8.Add(x8y4);
            square8.Add(x8y5);
            square8.Add(x8y6);
            square9.Add(x8y7);
            square9.Add(x8y8);
            square9.Add(x8y9);

            square7.Add(x9y1);
            square7.Add(x9y2);
            square7.Add(x9y3);
            square8.Add(x9y4);
            square8.Add(x9y5);
            square8.Add(x9y6);
            square9.Add(x9y7);
            square9.Add(x9y8);
            square9.Add(x9y9);

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
                            int xValue = getTextBoxXY(box).Item1;
                            foreach (TextBox checkBox in horizontals[xValue - 1])
                            {
                                if (checkBox.Name != box.Name)
                                    if (checkBox.Text == leftover.ToString())
                                        canPlace = false;
                            }
                            
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
                //Console.WriteLine("smalldiv___________smalldiv");
                foreach (Tuple<TextBox, int> tup in s1)
                {
                    //Console.WriteLine(tup.Item2);

                }
                //Console.WriteLine("divider______________________________divider");
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
                    //Console.WriteLine(tups.Count);
                    if (tups.Count == 1)
                    {
                        tups[0].Item1.Text = tups[0].Item2.ToString();
                    }
                }
            }
        }

        private Tuple<int, int> getTextBoxXY(TextBox box)
        {
            int x;
            int y;
            x = Convert.ToInt32(box.Name[1].ToString());
            y = Convert.ToInt32(box.Name[3].ToString());
            return new Tuple<int, int>(x,y);
        }


    }
}
