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
        public static float I, U, R, q, A, S, p, l, t;
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
                switch (type)
                {
                    case "U":
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (!Math.Round(Numbers.A, 4).Equals(A.Text) && IsReady(A, type)) Numbers.A = (float)Convert.ToDouble(A.Text);
                    if (IsReady(U,type))
                        {
                            if (IsReady(R, type))
                            {
                                Numbers.I = Numbers.U / Numbers.R;
                                I.Text = Math.Round(Numbers.I, 4).ToString();
                                Logger.Items.Add(Numbers.U + "В / " + Numbers.R + "Ом = " + I.Text + "А");
                            }
                            if (IsReady(I, type))
                            {
                                Numbers.R = Numbers.U / Numbers.I;
                                R.Text = Math.Round(Numbers.R, 4).ToString();
                                Logger.Items.Add(Numbers.U + "В / " + Numbers.I + "А = " + R.Text + "Ом");
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
                            if(IsReady(U, type))
                            {
                                Numbers.I = Numbers.U / Numbers.R;
                                I.Text = Math.Round(Numbers.I, 4).ToString();
                            }
                            if(IsReady(I, type))
                            {
                                Numbers.U = Numbers.I * Numbers.R;
                                U.Text = Math.Round(Numbers.U, 4).ToString();
                            }
                            if(IsReady(S,type))
                            {
                                if(IsReady(p,type))
                                {
                                    Numbers.l = Numbers.R * Numbers.S / Numbers.p;
                                    l.Text = Math.Round(Numbers.l, 4).ToString();
                                }
                                if(IsReady(l,type))
                                {
                                    Numbers.p = Numbers.R * Numbers.S / Numbers.l;
                                    p.Text = Math.Round(Numbers.p, 4).ToString();
                                }
                            }
                            if(IsReady(p,type))
                            {
                                if(IsReady(l,type))
                                {
                                    Numbers.S = Numbers.p * Numbers.l / Numbers.R;
                                    S.Text = Math.Round(Numbers.S, 4).ToString();
                                }
                            }
                        }
                        break;
                    case "I":
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (!Math.Round(Numbers.t, 4).Equals(t.Text) && IsReady(t, type)) Numbers.t = (float)Convert.ToDouble(t.Text);
                    if (IsReady(I, type))
                        {
                            if (IsReady(R, type))
                            {
                                Numbers.U = Numbers.I * Numbers.R;
                                U.Text = Math.Round(Numbers.U, 4).ToString();
                            }
                            if (IsReady(U, type))
                            {
                                Numbers.R = Numbers.U / Numbers.I;
                                R.Text = Math.Round(Numbers.R, 4).ToString();
                            }
                            if(IsReady(q, type))
                            {
                                Numbers.t = Numbers.q / Numbers.I;
                                t.Text = Math.Round(Numbers.t, 4).ToString();
                            }
                            if(IsReady(t, type))
                            {
                                Numbers.q = Numbers.I * Numbers.t;
                                q.Text = Math.Round(Numbers.q, 4).ToString();
                            }
                        }
                        break;
                    case "q":
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.t, 4).Equals(t.Text) && IsReady(t, type)) Numbers.t = (float)Convert.ToDouble(t.Text);
                    if (!Math.Round(Numbers.A, 4).Equals(A.Text) && IsReady(A, type)) Numbers.A = (float)Convert.ToDouble(A.Text);
                    if (IsReady(q, type))
                        {
                            if(IsReady(U, type))
                            {
                                Numbers.A = Numbers.U * Numbers.q;
                                A.Text = Math.Round(Numbers.A, 4).ToString();
                            }
                            if(IsReady(I, type))
                            {
                                Numbers.t = Numbers.q / Numbers.I;
                                t.Text = Math.Round(Numbers.t, 4).ToString();
                            }
                            if(IsReady(t, type))
                            {
                                Numbers.I = Numbers.q / Numbers.t;
                                I.Text = Math.Round(Numbers.I, 4).ToString();
                            }
                            if(IsReady(A, type))
                            {
                                Numbers.U = Numbers.A * Numbers.q;
                                U.Text = Math.Round(Numbers.U, 4).ToString();
                            }
                        }
                        break;
                    case "A":
                    if (!Math.Round(Numbers.A, 4).Equals(A.Text) && IsReady(A, type)) Numbers.A = (float)Convert.ToDouble(A.Text);
                    if (!Math.Round(Numbers.U, 4).Equals(U.Text) && IsReady(U, type)) Numbers.U = (float)Convert.ToDouble(U.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (IsReady(A, type))
                        {
                            if(IsReady(U, type))
                            {
                                Numbers.q = Numbers.A / Numbers.U;
                                q.Text = Math.Round(Numbers.q, 4).ToString();
                            }
                            if(IsReady(q, type))
                            {
                                Numbers.U = Numbers.A * Numbers.q;
                                U.Text = Math.Round(Numbers.U, 4).ToString();
                            }
                        }
                        break;
                    case "t":
                    if (!Math.Round(Numbers.I, 4).Equals(I.Text) && IsReady(I, type)) Numbers.I = (float)Convert.ToDouble(I.Text);
                    if (!Math.Round(Numbers.t, 4).Equals(t.Text) && IsReady(t, type)) Numbers.t = (float)Convert.ToDouble(t.Text);
                    if (!Math.Round(Numbers.q, 4).Equals(q.Text) && IsReady(q, type)) Numbers.q = (float)Convert.ToDouble(q.Text);
                    if (IsReady(t, type))
                        {
                            if(IsReady(I, type))
                            {
                                Numbers.q = Numbers.I * Numbers.t;
                                q.Text = Math.Round(Numbers.q, 4).ToString();
                            }
                            if(IsReady(q, type))
                            {
                                Numbers.I = Numbers.q / Numbers.t;
                                I.Text = Math.Round(Numbers.I, 4).ToString();
                            }
                        }
                        break;
                    case "p":
                    if (!Math.Round(Numbers.p, 4).Equals(p.Text) && IsReady(p, type)) Numbers.p = (float)Convert.ToDouble(p.Text);
                    if (!Math.Round(Numbers.l, 4).Equals(l.Text) && IsReady(l, type)) Numbers.l = (float)Convert.ToDouble(l.Text);
                    if (!Math.Round(Numbers.S, 4).Equals(S.Text) && IsReady(S, type)) Numbers.S = (float)Convert.ToDouble(S.Text);
                    if (!Math.Round(Numbers.R, 4).Equals(R.Text) && IsReady(R, type)) Numbers.R = (float)Convert.ToDouble(R.Text);
                    if (IsReady(p,type))
                        {
                            if(IsReady(l,type))
                            {
                                if(IsReady(S,type))
                                {
                                    Numbers.R = Numbers.p * Numbers.l / Numbers.S;
                                    R.Text = Math.Round(Numbers.R, 4).ToString();
                                }
                                if(IsReady(R,type))
                                {
                                    Numbers.S = Numbers.p * Numbers.l / Numbers.R;
                                    S.Text = Math.Round(Numbers.S, 4).ToString();
                                }
                            }
                            if(IsReady(R,type))
                            {
                                if(IsReady(S,type))
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
                    if (IsReady(l,type))
                        {
                            if(IsReady(p,type))
                            {
                                if(IsReady(S,type))
                                {
                                    Numbers.R = Numbers.p * Numbers.l / Numbers.S;
                                    R.Text = Math.Round(Numbers.R, 4).ToString();
                                }
                                if(IsReady(R,type))
                                {
                                    Numbers.S = Numbers.p * Numbers.l / Numbers.R;
                                    S.Text = Math.Round(Numbers.S, 4).ToString();
                                }
                            }
                            if(IsReady(R,type))
                            {
                                if(IsReady(S,type))
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
                    if (IsReady(S,type))
                        {
                            if(IsReady(p,type))
                            {
                                if(IsReady(l,type))
                                {
                                    Numbers.R = Numbers.p * Numbers.l / Numbers.S;
                                    R.Text = Math.Round(Numbers.R, 4).ToString();
                                }
                                if(IsReady(R,type))
                                {
                                    Numbers.l = Numbers.R * Numbers.S / Numbers.p;
                                    l.Text = Math.Round(Numbers.l, 4).ToString();
                                }
                            }
                            if(IsReady(R,type))
                            {
                                if(IsReady(l,type))
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
