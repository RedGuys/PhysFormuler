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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace PhysFormuler
{
    public static class Numbers
    {
        public static float I, U, R, q, A, S, p, l, temp;
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private bool IsReady(TextBox box, string type)
        {
            if (box.Text != "")
            {
                double number;
                if (Double.TryParse(box.Text, out number))
                {
                    return !double.IsNaN(number);
                }
                else return false;
            }
            else return false;
        }

        private void Update(string type)
        {
            switch (type)
            {
                case "U":
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (!Math.Round(Numbers.A, 4).Equals(A.Text) && IsReady(A, type)) Numbers.A = (float)Convert.ToDouble(A.Text);
                    if (IsReady(U, type))
                    {
                        if (IsReady(R, type))
                        {
                            Numbers.I = Numbers.U / Numbers.R;
                            I.Text = Math.Round(Numbers.I, 4).ToString();
                            Logger.Items.Add(Numbers.U + "В / " + Numbers.R + "ом = " + I.Text + "А");
                        }
                        if (IsReady(I, type))
                        {
                            Numbers.R = Numbers.U / Numbers.I;
                            R.Text = Math.Round(Numbers.R, 4).ToString();
                            Logger.Items.Add(Numbers.U + "В / " + Numbers.I + "А = " + R.Text + "ом");
                        }
                        if (IsReady(q, type))
                        {
                            Numbers.A = Numbers.U * Numbers.q;
                            A.Text = Math.Round(Numbers.A, 4).ToString();
                            Logger.Items.Add(Numbers.U + "В * " + Numbers.q + "Кл = " + Numbers.A + "Дж");
                        }
                        if (IsReady(A, type))
                        {
                            Numbers.q = Numbers.A / Numbers.U;
                            q.Text = Math.Round(Numbers.q, 4).ToString();
                            Logger.Items.Add(Numbers.A + "Дж / " + Numbers.U + "В = " + Numbers.q + "Кл");
                        }
                    }
                    break;
                case "R":
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.S, 4).Equals(S.Text) && IsReady(S, type)) Numbers.S = (float)Convert.ToDouble(S.Text);
                    if (!Math.Round(Numbers.p, 4).Equals(p.Text) && IsReady(p, type)) Numbers.p = (float)Convert.ToDouble(p.Text);
                    if (!Math.Round(Numbers.l, 4).Equals(l.Text) && IsReady(l, type)) Numbers.l = (float)Convert.ToDouble(l.Text);
                    if (IsReady(R, type))
                    {
                        if (IsReady(U, type))
                        {
                            Numbers.I = Numbers.U / Numbers.R;
                            I.Text = Math.Round(Numbers.I, 4).ToString();
                            Logger.Items.Add(Numbers.U + "В / " + Numbers.R + "Ом = " + Numbers.I + "А");
                        }
                        if (IsReady(I, type))
                        {
                            Numbers.U = Numbers.I * Numbers.R;
                            U.Text = Math.Round(Numbers.U, 4).ToString();
                            Logger.Items.Add(Numbers.I + "А * " + Numbers.R + "ом = " + Numbers.U + "В");
                        }
                        if (IsReady(S, type))
                        {
                            if (IsReady(p, type))
                            {
                                Numbers.l = Numbers.R * Numbers.S / Numbers.p;
                                l.Text = Math.Round(Numbers.l, 4).ToString();
                                Logger.Items.Add(Numbers.R + "ом * " + Numbers.S + "мм^2 / " + Numbers.p + "ом*м = " + Numbers.l+ "м");
                            }
                            if (IsReady(l, type))
                            {
                                Numbers.p = Numbers.R * Numbers.S / Numbers.l;
                                p.Text = Math.Round(Numbers.p, 4).ToString();
                                Logger.Items.Add(Numbers.R + "ом * " + Numbers.S + "мм^2 / " + Numbers.l + "м = " + Numbers.p + "ом*м");
                            }
                        }
                        if (IsReady(p, type))
                        {
                            if (IsReady(l, type))
                            {
                                Numbers.S = Numbers.p * Numbers.l / Numbers.R;
                                S.Text = Math.Round(Numbers.S, 4).ToString();
                                Logger.Items.Add(Numbers.p + "ом*м * " + Numbers.l + "м / " + Numbers.R + "ом = " + Numbers.S+ "мм^2");
                            }
                        }
                    }
                    break;
                case "I":
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (!Math.Round(Numbers.temp, 4).Equals(temp.Text) && IsReady(temp, type)) Numbers.temp = (float)Convert.ToDouble(temp.Text);
                    if (IsReady(I, type))
                    {
                        if (IsReady(R, type))
                        {
                            Numbers.U = Numbers.I * Numbers.R;
                            U.Text = Math.Round(Numbers.U, 4).ToString();
                            Logger.Items.Add(Numbers.I + "А * " + Numbers.R + "ом = " + Numbers.U + "В");
                        }
                        if (IsReady(U, type))
                        {
                            Numbers.R = Numbers.U / Numbers.I;
                            R.Text = Math.Round(Numbers.R, 4).ToString();
                            Logger.Items.Add(Numbers.U + "В / " + Numbers.I + "А = " + Numbers.R + "ом");
                        }
                        if (IsReady(q, type))
                        {
                            Numbers.temp = Numbers.q / Numbers.I;
                            temp.Text = Math.Round(Numbers.temp, 4).ToString();
                            Logger.Items.Add(Numbers.q + "Кл / " + Numbers.I + "А = " + Numbers.temp + "C");
                        }
                        if (IsReady(temp, type))
                        {
                            Numbers.q = Numbers.I * Numbers.temp;
                            q.Text = Math.Round(Numbers.q, 4).ToString();
                            Logger.Items.Add(Numbers.I + "А * " + Numbers.temp + "С = " + Numbers.q + "Кл");
                        }
                    }
                    break;
                case "q":
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.temp, 4).Equals(temp.Text) && IsReady(temp, type)) Numbers.temp = (float)Convert.ToDouble(temp.Text);
                    if (!Math.Round(Numbers.A, 4).Equals(A.Text) && IsReady(A, type)) Numbers.A = (float)Convert.ToDouble(A.Text);
                    if (IsReady(q, type))
                    {
                        if (IsReady(U, type))
                        {
                            Numbers.A = Numbers.U * Numbers.q;
                            A.Text = Math.Round(Numbers.A, 4).ToString();
                            Logger.Items.Add(Numbers.U + "В * " + Numbers.q + "Кл = " + Numbers.A + "Дж");
                        }
                        if (IsReady(I, type))
                        {
                            Numbers.temp = Numbers.q / Numbers.I;
                            temp.Text = Math.Round(Numbers.temp, 4).ToString();
                            Logger.Items.Add(Numbers.q + "Кл / " + Numbers.I + "А = " + Numbers.temp + "C");
                        }
                        if (IsReady(temp, type))
                        {
                            Numbers.I = Numbers.q / Numbers.temp;
                            I.Text = Math.Round(Numbers.I, 4).ToString();
                            Logger.Items.Add(Numbers.q + "Кл / " + Numbers.temp + "C = " + Numbers.I + "А");
                        }
                        if (IsReady(A, type))
                        {
                            Numbers.U = Numbers.A * Numbers.q;
                            U.Text = Math.Round(Numbers.U, 4).ToString();
                            Logger.Items.Add(Numbers.A + "Дж * " + Numbers.q + "КЛ = " + Numbers.U + "В");
                        }
                    }
                    break;
                case "A":
                    if (!Math.Round(Numbers.A, 4).Equals(A.Text) && IsReady(A, type)) Numbers.A = (float)Convert.ToDouble(A.Text);
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (IsReady(A, type))
                    {
                        if (IsReady(U, type))
                        {
                            Numbers.q = Numbers.A / Numbers.U;
                            q.Text = Math.Round(Numbers.q, 4).ToString();
                        }
                        if (IsReady(q, type))
                        {
                            Numbers.U = Numbers.A * Numbers.q;
                            U.Text = Math.Round(Numbers.U, 4).ToString();
                        }
                    }
                    break;
                case "temp":
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.temp, 4).Equals(temp.Text) && IsReady(temp, type)) Numbers.temp = (float)Convert.ToDouble(temp.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (IsReady(temp, type))
                    {
                        if (IsReady(I, type))
                        {
                            Numbers.q = Numbers.I * Numbers.temp;
                            q.Text = Math.Round(Numbers.q, 4).ToString();
                        }
                        if (IsReady(q, type))
                        {
                            Numbers.I = Numbers.q / Numbers.temp;
                            I.Text = Math.Round(Numbers.I, 4).ToString();
                        }
                    }
                    break;
                case "p":
                    if (!Math.Round(Numbers.p, 4).Equals(p.Text) && IsReady(p, type)) Numbers.p = (float)Convert.ToDouble(p.Text);
                    if (!Math.Round(Numbers.l, 4).Equals(l.Text) && IsReady(l, type)) Numbers.l = (float)Convert.ToDouble(l.Text);
                    if (!Math.Round(Numbers.S, 4).Equals(S.Text) && IsReady(S, type)) Numbers.S = (float)Convert.ToDouble(S.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (IsReady(p, type))
                    {
                        if (IsReady(l, type))
                        {
                            if (IsReady(S, type))
                            {
                                Numbers.R = Numbers.p * Numbers.l / Numbers.S;
                                R.Text = Math.Round(Numbers.R, 4).ToString();
                            }
                            if (IsReady(R, type))
                            {
                                Numbers.S = Numbers.p * Numbers.l / Numbers.R;
                                S.Text = Math.Round(Numbers.S, 4).ToString();
                            }
                        }
                        if (IsReady(R, type))
                        {
                            if (IsReady(S, type))
                            {
                                Numbers.l = Numbers.R * Numbers.S / Numbers.p;
                                l.Text = Math.Round(Numbers.l, 4).ToString();
                            }
                        }
                    }
                    break;
                case "l":
                    if (!Math.Round(Numbers.p, 4).Equals(p.Text) && IsReady(p, type)) Numbers.p = (float)Convert.ToDouble(p.Text);
                    if (!Math.Round(Numbers.l, 4).Equals(l.Text) && IsReady(l, type)) Numbers.l = (float)Convert.ToDouble(l.Text);
                    if (!Math.Round(Numbers.S, 4).Equals(S.Text) && IsReady(S, type)) Numbers.S = (float)Convert.ToDouble(S.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (IsReady(l, type))
                    {
                        if (IsReady(p, type))
                        {
                            if (IsReady(S, type))
                            {
                                Numbers.R = Numbers.p * Numbers.l / Numbers.S;
                                R.Text = Math.Round(Numbers.R, 4).ToString();
                            }
                            if (IsReady(R, type))
                            {
                                Numbers.S = Numbers.p * Numbers.l / Numbers.R;
                                S.Text = Math.Round(Numbers.S, 4).ToString();
                            }
                        }
                        if (IsReady(R, type))
                        {
                            if (IsReady(S, type))
                            {
                                Numbers.p = Numbers.R * Numbers.S / Numbers.l;
                                p.Text = Math.Round(Numbers.p, 4).ToString();
                            }
                        }
                    }
                    break;
                case "S":
                    if (!Math.Round(Numbers.p, 4).Equals(p.Text) && IsReady(p, type)) Numbers.p = (float)Convert.ToDouble(p.Text);
                    if (!Math.Round(Numbers.l, 4).Equals(l.Text) && IsReady(l, type)) Numbers.l = (float)Convert.ToDouble(l.Text);
                    if (!Math.Round(Numbers.S, 4).Equals(S.Text) && IsReady(S, type)) Numbers.S = (float)Convert.ToDouble(S.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (IsReady(S, type))
                    {
                        if (IsReady(p, type))
                        {
                            if (IsReady(l, type))
                            {
                                Numbers.R = Numbers.p * Numbers.l / Numbers.S;
                                R.Text = Math.Round(Numbers.R, 4).ToString();
                            }
                            if (IsReady(R, type))
                            {
                                Numbers.l = Numbers.R * Numbers.S / Numbers.p;
                                l.Text = Math.Round(Numbers.l, 4).ToString();
                            }
                        }
                        if (IsReady(R, type))
                        {
                            if (IsReady(l, type))
                            {
                                Numbers.p = Numbers.R * Numbers.S / Numbers.l;
                                p.Text = Math.Round(Numbers.p, 4).ToString();
                            }
                        }
                    }
                    break;
            }
        }

        private void TC(object sender, TextChangedEventArgs e)
        {
            TextBox s = (TextBox)sender;
            Update(s.Name);
        }
    }
}
