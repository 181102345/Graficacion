using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficación_Linea
{
    public partial class Grafica : Form
    {
        public static int k, x = 900, y = 600;
        public Grafica()
        {
            InitializeComponent();
        }

        private void txt_Xa_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Ya_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Xb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Yb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox3.Refresh();
            //Declaracion de las variables
            int[] guardarX = new int[950]; //Guardaremos por los puntos que pasa la recta
            int[] guardarY = new int[950];
            double DelasX, DelasY, pendiente, c, d;
            int Xa, Xb, Ya, Yb, i, rango, resta;
            string decision, CoordenadaA, CoordenadaB;

            //Con esto especificamos el tipo de letra, tamaño y color de las plantillas que mostraran las coordenadas que unen la linea
            SolidBrush s = new SolidBrush(Color.Black);
            FontFamily ff = new FontFamily("Courier New");
            System.Drawing.Font font = new System.Drawing.Font(ff, 7, FontStyle.Bold);

            Graphics papel;
            papel = pictureBox3.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);
            //preguntamos si todos los campos estan llenos, de lo contrario mostrara un error.
            if (txt_Xa.Text != "" && txt_Xb.Text != "" && txt_Ya.Text != "" && txt_Yb.Text != "")
            {
                Xa = Convert.ToInt32(txt_Xa.Text);
                Xb = Convert.ToInt32(txt_Xb.Text);
                Ya = Convert.ToInt32(txt_Ya.Text);
                Yb = Convert.ToInt32(txt_Yb.Text);
                CoordenadaA = "A(" + Xa + "," + Ya + ")";
                CoordenadaB = "B(" + Xb + "," + Yb + ")";
                DelasX = Xb - Xa;
                DelasY = Yb - Ya;
                pendiente = DelasY / DelasX;
                if (DelasY == 0 && DelasX == 0)
                {
                    MessageBox.Show("No se puede graficar, no es una linea", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Xa.Text = "";
                    txt_Ya.Text = "";
                    txt_Xb.Text = "";
                    txt_Yb.Text = "";
                }
                else if (DelasY == 0)
                {
                    if (Xa > Xb)
                    {
                        decision = "de derecha a izquierda";
                        rango = Xa - Xb;
                        c = Xa;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Convert.ToInt32(c);
                            guardarY[i] = Ya;
                            c = c - 1;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa - 60, 600 - Ya + 3));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb, 600 - Yb - 15));
                    }
                    else
                    {
                        decision = "de izquierda a derecha";
                        rango = Xb - Xa;
                        c = Xa;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Convert.ToInt32(c);
                            guardarY[i] = Ya;
                            c = c + 1;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa, 600 - Ya + 3));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 15));
                    }
                    txt_respuestas.Text = "Pendiente = 0 y va de " + decision;
                }

                else if (DelasX == 0)
                {
                    if (Ya > Yb)
                    {
                        decision = " arriba hacia abajo";
                        rango = Ya - Yb;
                        c = Ya;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Xa;
                            guardarY[i] = Convert.ToInt32(c);
                            c = c - 1;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa + 5, 600 - Ya - 3));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 10));
                    }
                    else
                    {
                        decision = "abajo hacia arriba";
                        rango = Yb - Ya;
                        c = Ya;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Xa;
                            guardarY[i] = Convert.ToInt32(c);
                            c = c + 1;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa, 600 - Ya - 10));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb));
                    }
                    txt_respuestas.Text = "Pendiente es (infinita) y va de " + decision;
                }

                else if (pendiente == 1)
                {
                    txt_respuestas.Text = "Tiene una pendiente de " + pendiente + " y esta inclinada a 45º Grados";
                    if (Xa > Xb)
                    {
                        c = Xa;
                        d = Ya;
                        rango = Xa - Xb;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Convert.ToInt32(c);
                            guardarY[i] = Convert.ToInt32(d);
                            c = c - 1;
                            d = d - 1;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa, 600 - Ya));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 10));
                    }
                    else
                    {
                        c = Xa;
                        d = Ya;
                        rango = Xb - Xa;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Convert.ToInt32(c);
                            guardarY[i] = Convert.ToInt32(d);
                            c = c + 1;
                            d = d + 1;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa + 10, 600 - Ya - 10));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb));
                    }
                }

                else if (pendiente == -1)
                {
                    txt_respuestas.Text = "Tiene una pendiente de " + pendiente + " y una inclinaciòn de 45º Grados en el sentido de las manecillas del reloj";
                    if (Xa > Xb)
                    {
                        resta = -1;
                        c = Xa;
                        d = Ya;
                        rango = Xa - Xb;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Convert.ToInt32(c);
                            guardarY[i] = Convert.ToInt32(d);
                            c = c - 1;
                            d = d - resta;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa, 600 - Ya - 10));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 5));
                    }
                    else
                    {
                        resta = -1;
                        c = Xa;
                        d = Ya;
                        rango = Xb - Xa;
                        for (i = 0; i <= rango; i++)
                        {
                            guardarX[i] = Convert.ToInt32(c);
                            guardarY[i] = Convert.ToInt32(d);
                            c = c + 1;
                            d = d + resta;
                        }
                        for (i = 0; i < rango; i++)
                        {
                            listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                            papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                        }
                        listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        papel.DrawString(CoordenadaA, font, s, new Point(Xa + 10, 600 - Ya));
                        papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 15));
                    }
                }

                else if (pendiente > 0 && pendiente < 1)
                {
                    c = Xa;
                    d = Ya;
                    if (Xa > Xb)
                    {
                        decision = "derecha a izquierda";
                        rango = Xa - Xb;
                        if (Ya > Yb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c - 1;
                                d = d - pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c - 1;
                                d = d + pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                    }
                    else
                    {
                        decision = "izquierda a derecha";
                        rango = Xb - Xa;
                        if (Ya > Yb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c + 1;
                                d = d - pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c + 1;
                                d = d + pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                    }
                    txt_respuestas.Text = "Tiene una pendiente de " + pendiente + " ( +m < 1) y va de " + decision;
                    papel.DrawString(CoordenadaA, font, s, new Point(Xa + 10, 600 - Ya - 10));
                    papel.DrawString(CoordenadaB, font, s, new Point(Xb, 600 - Yb - 15));
                }
                else if (pendiente > 1)
                {
                    c = Xa;
                    d = Ya;
                    if (Ya > Yb)
                    {
                        decision = "arriba para abajo";
                        rango = Ya - Yb;
                        if (Xa > Xb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(Math.Round(c, 0));
                                guardarY[i] = Convert.ToInt32(d);
                                c = c - (1 / pendiente);
                                d = d - 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(Math.Round(c, 0));
                                guardarY[i] = Convert.ToInt32(d);
                                c = c + (1 / pendiente);
                                d = d - 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                    }
                    else
                    {
                        decision = "abajo para arriba";
                        rango = Yb - Ya;
                        if (Xa > Xb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c - (1 / pendiente);
                                d = d + 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c + (1 / pendiente);
                                d = d + 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                        }
                    }
                    txt_respuestas.Text = "Pendiente igual a " + pendiente + " y va de " + decision;
                    papel.DrawString(CoordenadaA, font, s, new Point(Xa + 10, 600 - Ya));
                    papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb));
                }
                else if (pendiente < 0 && pendiente > -1)
                {
                    c = Xa;
                    d = Ya;
                    if (Xa > Xb)
                    {
                        decision = "derecha a izquierda";
                        rango = Xa - Xb;
                        if (Ya > Yb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(Math.Round(d, 0));
                                c = c - 1;
                                d = d + pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa - 60, 600 - Ya - 15));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb + 60, 600 - Yb));
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(Math.Round(d, 0));
                                c = c - 1;
                                d = d - pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa - 60, 600 - Ya - 15));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb, 600 - Yb - 15));
                        }
                    }
                    else
                    {
                        decision = "izquierda a derecha";
                        rango = Xb - Xa;
                        if (Ya > Yb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(Math.Round(d, 0));
                                c = c + 1;
                                d = d + pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa, 600 - Ya - 15));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb));
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(Math.Round(d, 0));
                                c = c + 1;
                                d = d - pendiente;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa, 600 - Ya - 15));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb));
                        }
                    }
                    txt_respuestas.Text = "Pendiente igua a " + pendiente + "y va de " + decision;
                }
                else if (pendiente < -1)
                {
                    c = Xa;
                    d = Ya;
                    if (Ya > Yb)
                    {
                        decision = "arriba hacia abajo";
                        rango = Ya - Yb;
                        if (Xa > Xb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(Math.Round(c, 0));
                                guardarY[i] = Convert.ToInt32(d);
                                c = c + (1 / pendiente);
                                d = d - 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa + 10, 600 - Ya));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 10));
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(Math.Round(c, 0));
                                guardarY[i] = Convert.ToInt32(d);
                                c = c - (1 / pendiente);
                                d = d - 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa + 10, 600 - Ya));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb - 60, 600 - Yb - 10));
                        }
                    }
                    else
                    {
                        decision = "abajo hacia arriba";
                        rango = Yb - Ya;
                        if (Xa > Xb)
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(Math.Round(c, 0));
                                guardarY[i] = Convert.ToInt32(d);
                                c = c + (1 / pendiente);
                                d = d + 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa - 60, 600 - Ya - 10));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb + 10, 600 - Yb));
                        }
                        else
                        {
                            for (i = 0; i <= rango; i++)
                            {
                                guardarX[i] = Convert.ToInt32(c);
                                guardarY[i] = Convert.ToInt32(d);
                                c = c - (1 / pendiente);
                                d = d + 1;
                            }
                            for (i = 0; i < rango; i++)
                            {
                                listBox1.Items.Add(i + 1 + ".-      " + "X = " + guardarX[i] + "     Y = " + guardarY[i]);
                                papel.DrawLine(lapiz, guardarX[i], 600 - guardarY[i], guardarX[i + 1], 600 - guardarY[i + 1]);
                            }
                            listBox1.Items.Add(rango + 1 + ".-      " + "X = " + Xb + "     Y = " + Yb);
                            papel.DrawString(CoordenadaA, font, s, new Point(Xa - 60, 600 - Ya - 15));
                            papel.DrawString(CoordenadaB, font, s, new Point(Xb + 10, 600 - Yb));
                        }
                    }
                    txt_respuestas.Text = "Pendiente igual a " + pendiente + " y va de " + decision;
                }
            }
            else
            {
                MessageBox.Show("Algunos de los campos estan vacios, verificar que todos\nesten completamente llenos\n\n\n!Solo acepta numeros¡", "!!Warning¡¡", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            restaurar.Visible = false;
            maximizar.Visible = true;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maximizar.Visible = false;
            restaurar.Visible = true;
        }

        private void Btn_limpiar_Click(object sender, EventArgs e)
        {
            if (txt_Xa.Text != "" && txt_Xb.Text != "" && txt_Ya.Text != "" && txt_Yb.Text != "")
            {
                txt_Xa.Text = "";
                txt_Ya.Text = "";
                txt_Xb.Text = "";
                txt_Yb.Text = "";
                pictureBox3.Refresh();
                txt_respuestas.Text = "";
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Nada que borrar, los campos estan vacios", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics coordenada;
            coordenada = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);
            coordenada.DrawLine(lapiz, 9, 0, 9, y + 10);
            coordenada.DrawLine(lapiz, 0, y, x + 10, y);

            //se imprimiran secciones que van de 50 en 50 para las coordenadas
            for (k = 0; k <= y; k = k + 50)
            {
                coordenada.DrawLine(lapiz, 0, k, 9, k);
            }

            for (k = 0; k <= x; k = k + 50)
            {
                coordenada.DrawLine(lapiz, k + 9, y + 1, k + 9, y + 10);
            }
        }


























    }
    
    
}
