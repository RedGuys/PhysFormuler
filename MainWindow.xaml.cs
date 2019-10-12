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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string s)
        {
            Console.WriteLine(s);
            Logger.Items.Add(s);
            Thread.Sleep(100);
        }

        private bool IsReady(TextBox box,string type)
        {
            if(type != "T")
            {
                if(box.Text != "")
                {
                    if(Convert.ToDouble(box.Text) != 0)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
            } else
            {
                if(box.Text != "")
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        private void Update(string type)
        {
            try
            {
                switch (type)
                {
                    case "U":
                        if (IsReady(U,type))
                        {
                            if (IsReady(R, type))
                            {
                                I.Text = Math.Round(Convert.ToDouble(U.Text) / Convert.ToDouble(R.Text),4).ToString();
                                Log(U.Text + " В / " + R.Text + " Ом = " + I.Text + " А");
                            }
                            if (IsReady(I, type))
                            {
                                R.Text = Math.Round(Convert.ToDouble(U.Text) / Convert.ToDouble(I.Text),4).ToString();
                                Log(U.Text + " В / " + I.Text + " А = " + R.Text + " Ом");
                            }
                            if (IsReady(q, type))
                            {
                                A.Text = Math.Round(Convert.ToDouble(U.Text) * Convert.ToDouble(q.Text),4).ToString();
                                Log(U.Text + " В * " + q.Text + " Кл = " + A.Text + " А");
                            }
                            if (IsReady(A, type))
                            {
                                q.Text = Math.Round(Convert.ToDouble(A.Text) / Convert.ToDouble(U.Text),4).ToString();
                                Log(A.Text + " А / " + U.Text + " В = " + q.Text + " Кл");
                            }
                        }
                        break;
                    case "R":
                        if(IsReady(R, type))
                        {
                            if(IsReady(U, type))
                            {
                                I.Text = Math.Round(Convert.ToDouble(U.Text) / Convert.ToDouble(R.Text),4).ToString();
                                Log(U.Text + " В / " + R.Text + " Ом = " + I.Text + " А");
                            }
                            if(IsReady(I, type))
                            {
                                U.Text = Math.Round(Convert.ToDouble(I.Text) * Convert.ToDouble(R.Text),4).ToString();
                                Log(I.Text + " А * " + R.Text + " Ом = " + U.Text + " В");
                            }
                            if(IsReady(S,type))
                            {
                                if(IsReady(p,type))
                                {
                                    l.Text = Math.Round(Convert.ToDouble(R.Text) * Convert.ToDouble(S.Text) / Convert.ToDouble(p.Text),4).ToString();
                                    Log(R.Text + " Ом * " + S.Text +" мм^2 / " + p.Text + " Ом*м = " + l.Text + " м");
                                }
                                if(IsReady(l,type))
                                {
                                    p.Text = Math.Round(Convert.ToDouble(R.Text) * Convert.ToDouble(S.Text) / Convert.ToDouble(l.Text),4).ToString();
                                    Log(R.Text + " Ом * " + S.Text + " мм^2 / " + l.Text + " м = " + p.Text + " Ом*м");
                                }
                            }
                            if(IsReady(p,type))
                            {
                                if(IsReady(l,type))
                                {
                                    S.Text = Math.Round(Convert.ToDouble(p.Text) * Convert.ToDouble(l.Text) / Convert.ToDouble(R.Text),4).ToString();
                                    Log(p.Text + " Ом*м * " + l.Text + " м / " + R.Text + " Ом = " + S.Text + " мм^2");
                                }
                            }
                        }
                        break;
                    case "I":
                        if(IsReady(I, type))
                        {
                            if (IsReady(R, type))
                            {
                                U.Text = Math.Round(Convert.ToDouble(I.Text) * Convert.ToDouble(R.Text),4).ToString();
                                Log(I.Text + " А * " + R.Text + " Ом = " + U.Text + " В");
                            }
                            if (IsReady(U, type))
                            {
                                R.Text = Math.Round(Convert.ToDouble(U.Text) / Convert.ToDouble(I.Text),4).ToString();
                                Log(U.Text + " В / " + I.Text + " А = " + R.Text + " Ом");
                            }
                            if(IsReady(q, type))
                            {
                                t.Text = Math.Round(Convert.ToDouble(q.Text) / Convert.ToDouble(I.Text),4).ToString();
                                Log(q.Text + " Кл / " + I.Text + " А = " + t.Text + " Сек");
                            }
                            if(IsReady(t, type))
                            {
                                q.Text = Math.Round(Convert.ToDouble(I.Text) * Convert.ToDouble(t.Text),4).ToString();
                                Log(I.Text + " А * " + t.Text + " Сек = " + q.Text + " Кл");
                            }
                        }
                        break;
                    case "q":
                        if(IsReady(q, type))
                        {
                            if(IsReady(U, type))
                            {
                                A.Text = Math.Round(Convert.ToDouble(U.Text) * Convert.ToDouble(q.Text),4).ToString();
                                Log(U.Text + " В * " + q.Text + " Кл = " + A.Text + " Дж");
                            }
                            if(IsReady(I, type))
                            {
                                t.Text = Math.Round(Convert.ToDouble(q.Text) / Convert.ToDouble(I.Text),4).ToString();
                                Log(q.Text + " Кл / " + I.Text + " А = " + t.Text + " Сек");
                            }
                            if(IsReady(t, type))
                            {
                                I.Text = Math.Round(Convert.ToDouble(q.Text) / Convert.ToDouble(t.Text),4).ToString();
                                Log(q.Text + " Кл / " + t.Text + " Сек = " + I.Text + " А");
                            }
                            if(IsReady(A, type))
                            {
                                U.Text = Math.Round(Convert.ToDouble(A.Text) * Convert.ToDouble(q.Text),4).ToString();
                                Log(A.Text + " Дж * " + q.Text + " Кл = " + U.Text + " В");
                            }
                        }
                        break;
                    case "A":
                        if(IsReady(A, type))
                        {
                            if(IsReady(U, type))
                            {
                                q.Text = Math.Round(Convert.ToDouble(A.Text) / Convert.ToDouble(U.Text),4).ToString();
                                Log(A.Text + " Дж / " + U.Text + " В = " + q.Text + " Кл");
                            }
                            if(IsReady(q, type))
                            {
                                U.Text = Math.Round(Convert.ToDouble(A.Text) * Convert.ToDouble(q.Text),4).ToString();
                                Log(A.Text + " Дж * " + q.Text + " Кл = " + U.Text + " В");
                            }
                        }
                        break;
                    case "t":
                        if(IsReady(t, type))
                        {
                            if(IsReady(I, type))
                            {
                                q.Text = Math.Round(Convert.ToDouble(I.Text) * Convert.ToDouble(t.Text),4).ToString();
                                Log(I.Text + " А * " + t.Text + " Сек = " + q.Text + " Кл");
                            }
                            if(IsReady(q, type))
                            {
                                I.Text = Math.Round(Convert.ToDouble(q.Text) / Convert.ToDouble(t.Text),4).ToString();
                                Log(q.Text + " Кл / " + t.Text + " Сек = " + I.Text + " А");
                            }
                        }
                        break;
                    case "p":
                        if(IsReady(p,type))
                        {
                            if(IsReady(l,type))
                            {
                                if(IsReady(S,type))
                                {
                                    R.Text = Math.Round(Convert.ToDouble(p.Text) * Convert.ToDouble(l.Text) / Convert.ToDouble(S.Text),4).ToString();
                                    Log(p.Text + " Кл * " + l.Text + " м / " + S.Text + " мм^2 = " + R.Text + " Ом");
                                }
                                if(IsReady(R,type))
                                {
                                    S.Text = Math.Round(Convert.ToDouble(p.Text) * Convert.ToDouble(l.Text) / Convert.ToDouble(R.Text),4).ToString();
                                    Log(p.Text + " Кл * " + l.Text + " м / " + R.Text + " Ом = " + S.Text + " мм^2");
                                }
                            }
                            if(IsReady(R,type))
                            {
                                if(IsReady(S,type))
                                {
                                    l.Text = Math.Round(Convert.ToDouble(R.Text) * Convert.ToDouble(S.Text) / Convert.ToDouble(p.Text),4).ToString();
                                    Log(R.Text + " Ом * " + S.Text + " мм^2 / " + p.Text + " Кл = " + l.Text + " м");
                                }
                            }
                        }
                        break;
                    case "l":
                        if(IsReady(l,type))
                        {
                            if(IsReady(p,type))
                            {
                                if(IsReady(S,type))
                                {
                                    R.Text = Math.Round(Convert.ToDouble(p.Text) * Convert.ToDouble(l.Text) / Convert.ToDouble(S.Text),4).ToString();
                                    Log(p.Text + " Кл * " + l.Text + " м / " + S.Text + " мм^2 = " + R.Text + " Ом");
                                }
                                if(IsReady(R,type))
                                {
                                    S.Text = Math.Round(Convert.ToDouble(p.Text) * Convert.ToDouble(l.Text) / Convert.ToDouble(R.Text),4).ToString();
                                    Log(p.Text + " Кл * " + l.Text + " м / " + R.Text + " Ом = " + S.Text + " мм^2");
                                }
                            }
                            if(IsReady(R,type))
                            {
                                if(IsReady(S,type))
                                {
                                    p.Text = Math.Round(Convert.ToDouble(R.Text) * Convert.ToDouble(S.Text) / Convert.ToDouble(l.Text),4).ToString();
                                    Log(R.Text + " Ом * " + S.Text + " мм^2 / " + l.Text + " м = " + p.Text + " Кл");
                                }
                            }
                        }
                        break;
                    case "S":
                        if(IsReady(S,type))
                        {
                            if(IsReady(p,type))
                            {
                                if(IsReady(l,type))
                                {
                                    R.Text = Math.Round(Convert.ToDouble(p.Text) * Convert.ToDouble(l.Text) / Convert.ToDouble(S.Text),4).ToString();
                                    Log(p.Text + " Кл * " + l.Text + " м / " + S.Text + " мм^2 = " + R.Text + " Ом");
                                }
                                if(IsReady(R,type))
                                {
                                    l.Text = Math.Round(Convert.ToDouble(R.Text) * Convert.ToDouble(S.Text) / Convert.ToDouble(p.Text),4).ToString();
                                    Log(R.Text + " Ом * " + S.Text + " мм^2 / " + p.Text + " Кл = " + l.Text + " м");
                                }
                            }
                            if(IsReady(R,type))
                            {
                                if(IsReady(l,type))
                                {
                                    p.Text = Math.Round(Convert.ToDouble(R.Text) * Convert.ToDouble(S.Text) / Convert.ToDouble(l.Text),4).ToString();
                                    Log(R.Text + " Ом * " + S.Text + " мм^2 / " + l.Text + " м = " + p.Text + " Кл");
                                }
                            }
                        }
                        break;
                }
            } catch
            {

            }
        }

        private void TC(object sender, TextChangedEventArgs e)
        {
            TextBox s = (TextBox)sender;
            Update(s.Name);
        }
    }
}
