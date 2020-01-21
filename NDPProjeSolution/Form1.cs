using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPProjeSolution
{
    public partial class Form1 : Form
    {

        bool draw, select = false;
        int tempX, tempY;
        int canvasX, canvasY;
        
        string shapeName, shapeColor;
        Color defColor;
        Sekiller shape;
        List<Sekiller> shapes = new List<Sekiller>();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            canvasX = cizimAlani.Width;
            canvasY = cizimAlani.Height;
            defColor = Color.Violet;
        }

        private void cizimAlani_MouseDown(object sender, MouseEventArgs e)
        {
            if (shapeName != "" && shapeColor !="")
            draw = true;
            tempX = e.X;
            tempY = e.Y;
            
            if (select == true)
            {
                canvasX = e.X;
                canvasY = e.Y;
                Graphics g = cizimAlani.CreateGraphics();
                Pen f = new Pen(Color.Violet, 6);
                g.Clear(Color.White);
                drawAgain();
                for (int i = 0; i < shapes.Count; i++)
                {
                    
                    shapes[i].select(g, f, e.X, e.Y);
                }
            }
        }

        private void cizimAlani_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = cizimAlani.CreateGraphics();
            SolidBrush f = new SolidBrush(defColor);
            if (draw && e.X <= 820 && e.Y <= 797 && e.X >= 0 && e.Y >=0)
            {
                if (shapeName == "rectangle")
                {
                    shape = new Rectangle();
                    g.Clear(Color.White);
                    drawAgain();
                    shape.shapeName = shapeName;
                    shape.startX = tempX;
                    shape.startY = tempY;
                    shape.Color = defColor;
                    shape.draw(g, f, e.X, e.Y);
                }

                else if (shapeName == "daire")
                {
                    shape = new Daire();
                    g.Clear(Color.White);
                    drawAgain();
                    shape.shapeName = shapeName;
                    shape.startX = tempX;
                    shape.startY = tempY;
                    shape.Color = defColor;
                    shape.draw(g, f, e.X, e.Y);
                }

                else if (shapeName == "triangle")
                {    
                    shape = new Triangle();
                    g.Clear(Color.White);
                    drawAgain();
                    shape.shapeName = shapeName;
                    shape.startX = tempX;
                    shape.startY = tempY;
                    shape.Color = defColor;
                    shape.draw(g, f, e.X, e.Y);
                }

                else if (shapeName == "hexagon")
                {
                    shape = new Hexagon();
                    g.Clear(Color.White);
                    drawAgain();
                    shape.shapeName = shapeName;
                    shape.startX = tempX;
                    shape.startY = tempY;
                    shape.Color = defColor;
                    shape.draw(g, f, e.X, e.Y);
                }

            }
        }

        private void cizimAlani_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            if (shapeName != "" && shapeColor != "")
                shapes.Add(shape);
        }

       

        private void closeTransparency()
        {
            btnDikdortgen.BackColor = gBoxCizim.BackColor;
            btnDaire.BackColor = gBoxCizim.BackColor;
            btnUcgen.BackColor = gBoxCizim.BackColor;
            btnAltigen.BackColor = gBoxCizim.BackColor;
            btnPointer.BackColor = gbSekilislem.BackColor;
            btnDelete.BackColor = gbSekilislem.BackColor;
            select = false;
            Graphics g = cizimAlani.CreateGraphics();
            g.Clear(Color.White);
            drawAgain();
        }

       

        private void _closeTransparency()
        {
            picKirmizi.BackColor = gbRenkSecimi.BackColor;
            picMavi.BackColor = gbRenkSecimi.BackColor;
            picYesil.BackColor = gbRenkSecimi.BackColor;
            picTuruncu.BackColor = gbRenkSecimi.BackColor;
            picSiyah.BackColor = gbRenkSecimi.BackColor;
            picSari.BackColor = gbRenkSecimi.BackColor;
            picMor.BackColor = gbRenkSecimi.BackColor;
            picKahve.BackColor = gbRenkSecimi.BackColor;
            picBeyaz.BackColor = gbRenkSecimi.BackColor;
        }

        

        private void drawAgain()
        {
            Graphics g = cizimAlani.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.White);

            for (int i = 0; i < shapes.Count; i++)
            {
                sb.Color = shapes[i].Color;
                shapes[i].draw(g, sb, shapes[i].endX, shapes[i].endY);
            }
        }

       

        private void changeColor(Color newColor)
        {
            Graphics g = cizimAlani.CreateGraphics();
            Pen f = new Pen(Color.Violet, 1);
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].select(g, f, canvasX, canvasY))
                    shapes[i].Color = newColor;
            }
            g.Clear(Color.White);
            drawAgain();
        }

       

        private void btnDikdortgen_Click(object sender, EventArgs e)
        {
            shapeName = "rectangle";
            closeTransparency();
            btnDikdortgen.BackColor = Color.Violet;
        }

        private void btnDaire_Click(object sender, EventArgs e)
        {
            shapeName = "daire";
            closeTransparency();
            btnDaire.BackColor = Color.Violet;
        }

        private void btnUcgen_Click(object sender, EventArgs e)
        {
            shapeName = "triangle";
            closeTransparency();
            btnUcgen.BackColor = Color.Violet;
        }

        private void btnAltigen_Click(object sender, EventArgs e)
        {
            shapeName = "hexagon";
            closeTransparency();
            btnAltigen.BackColor = Color.Violet;
        }

        private void btnKirmizi_Click(object sender, EventArgs e)
        {
            shapeColor = "red";
            defColor = Color.Red;
            _closeTransparency();
            picKirmizi.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnMavi_Click(object sender, EventArgs e)
        {
            shapeColor = "blue";
            defColor = Color.Blue;
            _closeTransparency();
            picMavi.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnYesil_Click(object sender, EventArgs e)
        {
            shapeColor = "green";
            defColor = Color.Green;
            _closeTransparency();
            picYesil.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

         private void btnTuruncu_Click(object sender, EventArgs e)
        {
            shapeColor = "orange";
            defColor = Color.Orange;
            _closeTransparency();
            picTuruncu.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnSiyah_Click(object sender, EventArgs e)
        {
            shapeColor = "black";
            defColor = Color.Black;
            _closeTransparency();
            picSiyah.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnPointer_Click(object sender, EventArgs e)
        {
            closeTransparency();
            _closeTransparency();
            select = true;
            btnPointer.BackColor = Color.Violet;
            shapeName = "";
            shapeColor = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            shapeName = "";
            shapeColor = "";
            if (select == true)
            {
                Graphics g = cizimAlani.CreateGraphics();
                Pen f = new Pen(Color.Violet, 6);
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].select(g, f, canvasX, canvasY))
                    {
                        shapes.RemoveAt(i);
                        i--;
                    }
                }

                canvasX = 820;
                canvasY = 797;
            }

            closeTransparency();
            _closeTransparency();
            btnDelete.BackColor = Color.Violet;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Metin Belgesi |*.txt";
            try
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string filePath = @file.FileName;
                    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        sw.WriteLine(shapes[i].shapeName + " " + shapes[i].startX + " " + shapes[i].startY + " " + shapes[i].endX + " " + shapes[i].endY + " " + shapes[i].Color.Name);
                    }
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            catch
            {
                MessageBox.Show("Dosya Kayıt Edilirken Bir Sorun Oluştu!");
            }
        }



        private void btnOpenFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Metin Belgesi |*.txt";
            file.Multiselect = false;
            try
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string filePath = @file.FileName;
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    StreamReader sw = new StreamReader(fs);
                    string line, _shape, clr;
                    string[] values;
                    int bX, bY, sX, sY;
                    Graphics g = cizimAlani.CreateGraphics();
                    g.Clear(Color.White);
                    shapes.Clear();
                    SolidBrush brush = new SolidBrush(Color.White);
                    while (!sw.EndOfStream)
                    {
                        line = sw.ReadLine();
                        values = line.Split(' ');
                        _shape = values[0];
                        bX = int.Parse(values[1]);
                        bY = int.Parse(values[2]);
                        sX = int.Parse(values[3]);
                        sY = int.Parse(values[4]);
                        clr = values[5];
                        if (clr == "Red")
                            brush.Color = Color.Red;
                        else if (clr == "Blue")
                            brush.Color = Color.Blue;
                        else if (clr == "Green")
                            brush.Color = Color.Green;
                        else if (clr == "Orange")
                            brush.Color = Color.Orange;
                        else if (clr == "Black")
                            brush.Color = Color.Black;
                        else if (clr == "Yellow")
                            brush.Color = Color.Yellow;
                        else if (clr == "Purple")
                            brush.Color = Color.Purple;
                        else if (clr == "Brown")
                            brush.Color = Color.Brown;
                        else if (clr == "Gray")
                            brush.Color = Color.Gray;
                        if (_shape == "rectangle")
                        {
                            shape = new Rectangle();
                            shape.shapeName = _shape;
                            shape.startX = bX;
                            shape.startY = bY;
                            shape.Color = brush.Color;
                            shape.draw(g, brush, sX, sY);
                        }
                        else if (_shape == "daire")
                        {
                            shape = new Daire();
                            shape.shapeName = _shape;
                            shape.startX = bX;
                            shape.startY = bY;
                            shape.Color = brush.Color;
                            shape.draw(g, brush, sX, sY);
                        }
                        else if (_shape == "triangle")
                        {
                            shape = new Triangle();
                            shape.shapeName = _shape;
                            shape.startX = bX;
                            shape.startY = bY;
                            shape.Color = brush.Color;
                            shape.draw(g, brush, sX, sY);
                        }
                        else if (_shape == "hexagon")
                        {
                            shape = new Hexagon();
                            shape.shapeName = _shape;
                            shape.startX = bX;
                            shape.startY = bY;
                            shape.Color = brush.Color;
                            shape.draw(g, brush, sX, sY);
                        }
                        shapes.Add(shape);
                    }
                    sw.Close();
                    fs.Close();
                }
            }
            catch
            {
                MessageBox.Show("Dosya Okunurken Bir Sorun Oluştu!");
            }
        }

       

        private void btnSari_Click(object sender, EventArgs e)
        {
            shapeColor = "yellow";
            defColor = Color.Yellow;
            _closeTransparency();
            picSari.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnMor_Click(object sender, EventArgs e)
        {
            shapeColor = "purple";
            defColor = Color.Purple;
            _closeTransparency();
            picMor.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnKahve_Click(object sender, EventArgs e)
        {
            shapeColor = "brown";
            defColor = Color.Brown;
            _closeTransparency();
            picKahve.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }

        private void btnBeyaz_Click(object sender, EventArgs e)
        {
            shapeColor = "gray";
            defColor = Color.Gray;
            _closeTransparency();
            picBeyaz.BackColor = Color.Violet;
            if (select == true)
            {
                changeColor(defColor);
                select = false;
                btnPointer.BackColor = gbSekilislem.BackColor;
            }
        }



    }
}
