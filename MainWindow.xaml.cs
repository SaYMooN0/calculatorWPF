


using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Xps;

namespace calculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button b1, b2, b3, b4, b5, b6, b7, b8, b9, b0, bCE, bC, bDot, bDiv, bPl, bMult, bMin, bEq, bBack;
        TextBlock tx1, tx2;
        public MainWindow()
        {
            InitializeComponent();
            sizeChange(this,new EventArgs());
            this.SizeChanged += sizeChange;
            this.MinHeight = Height;
            this.MinWidth = Width;

        }
        private void sizeChange(object sender, System.EventArgs e)
        {
            if(calc.Children.Count>0)
                calc.Children.Clear();
            int h = (int)(this.Height /7-10);
            int w = (int)this.Width / 4-10;
            tx1 = new TextBlock { Margin = new Thickness(5, h + 5, 0, 0), Height = h, Width = w * 4+15, Background = Brushes.Aquamarine, FontSize= 32, TextAlignment = TextAlignment.Right };
            tx2 = new TextBlock { Margin = new Thickness(5, h /2+5, 0, 0), Height = h/1.8, Width = w * 4+15, FontSize = 18,TextAlignment=TextAlignment.Right, Foreground=Brushes.Gray };
            bCE = new Button { Content = "CE", Height = h, Width = w, Margin = new Thickness(5, (h + 5) * 2, 0, 0) };
            bDot = new Button { Content = ".", Height = h, Width = w, Margin = new Thickness(5, (h + 5) * 6, 0, 0) };
            bEq = new Button { Content = "=", Height = h, Width = w*2+5, Margin = new Thickness(2*w+15, (h + 5) * 6, 0, 0) };
            bC = new Button { Content = "C", Height = h, Width = w, Margin = new Thickness(w+10, (h + 5) * 2, 0, 0) };
            bBack = new Button { Content = "<-", Height = h, Width = w, Margin = new Thickness(2*w+15, (h + 5) * 2, 0, 0) };
            bDiv = new Button { Content = "/", Height = h, Width = w, Margin = new Thickness(3*w+20, (h + 5) * 2, 0, 0) };
            bMult = new Button { Content = "*", Height = h, Width = w, Margin = new Thickness(3*w+20, (h + 5) * 3, 0, 0) };
            bMin = new Button { Content = "-", Height = h, Width = w, Margin = new Thickness(3*w+20, (h + 5) * 4, 0, 0) };
            bPl = new Button { Content = "+", Height = h, Width = w, Margin = new Thickness(3*w+20, (h + 5) * 5, 0, 0) };
            b1 = new Button { Content = "1", Height = h, Width = w, Margin = new Thickness(5, (h + 5) * 5, 0, 0) };
            b2 = new Button { Content = "2", Height = h, Width = w, Margin = new Thickness(w+10, (h + 5) * 5, 0, 0) };
            b3 = new Button { Content = "3", Height = h, Width = w, Margin = new Thickness((w + 5)*2+5, (h + 5) * 5, 0, 0) };
            b4 = new Button { Content = "4", Height = h, Width = w, Margin = new Thickness(5, (h + 5) * 4, 0, 0) };
            b5 = new Button { Content = "5", Height = h, Width = w, Margin = new Thickness(w+10, (h + 5) * 4, 0, 0) };
            b6 = new Button { Content = "6", Height = h, Width = w, Margin = new Thickness((w + 5)*2+5, (h + 5) * 4, 0, 0) };
            b7 = new Button { Content = "7", Height = h, Width = w, Margin = new Thickness(5, (h + 5) * 3, 0, 0) };
            b8 = new Button { Content = "8", Height = h, Width = w, Margin = new Thickness(w+10, (h + 5) * 3, 0, 0) };
            b9 = new Button { Content = "9", Height = h, Width = w, Margin = new Thickness((w + 5)*2+5, (h + 5) * 3, 0, 0) };
            b0 = new Button { Content = "0", Height = h, Width = w, Margin = new Thickness(w + 10, (h + 5) * 6, 0, 0) };
            bCE.Click += bCE_Click;
            bC.Click += bC_Click;
            bBack.Click += bBack_Click;
            b1.Click += bNum_Click;
            b2.Click += bNum_Click;
            b3.Click += bNum_Click;
            b4.Click += bNum_Click;
            b5.Click += bNum_Click;
            b6.Click += bNum_Click;
            b7.Click += bNum_Click;
            b8.Click += bNum_Click;
            b9.Click += bNum_Click;
            b0.Click += bNum_Click;
            bMult.Click += bSign_Click;
            bMin.Click += bSign_Click;
            bDiv.Click += bSign_Click;
            bPl.Click += bSign_Click;
            bDot.Click+=bDot_Click; 
            calc.Children.Add(tx1);
            calc.Children.Add(tx2);
            calc.Children.Add(bCE);
            calc.Children.Add(bMult);
            calc.Children.Add(bMin);
            calc.Children.Add(bPl);
            calc.Children.Add(bDot);
            calc.Children.Add(bEq);
            calc.Children.Add(bC);
            calc.Children.Add(bBack);
            calc.Children.Add(bDiv);
            calc.Children.Add(b0);
            calc.Children.Add(b1);
            calc.Children.Add(b2);
            calc.Children.Add(b3);
            calc.Children.Add(b4);
            calc.Children.Add(b5);
            calc.Children.Add(b6);
            calc.Children.Add(b7);
            calc.Children.Add(b8);
            calc.Children.Add(b9);
            bEq.Click+=bEq_Click;

        }
        private void bCE_Click(object sender, RoutedEventArgs e)
        {
            Check4Clear();
            tx1.Text = "";
        }
        private void bC_Click(object sender, RoutedEventArgs e)
        {
            tx1.Text = "";
            tx2.Text = "";
        }
        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            Check4Clear();
            if (!String.IsNullOrEmpty(tx1.Text))
                tx1.Text=tx1.Text.Remove(tx1.Text.Length - 1);
        }
        private void bDot_Click(object sender, RoutedEventArgs e)
        {
            Check4Clear();
            if (!String.IsNullOrEmpty(tx1.Text)&&!tx1.Text.Contains('.'))
                tx1.Text += ".";
        }
        private void bNum_Click(object sender, RoutedEventArgs e)
        {
            Check4Clear();
            Button b = (Button)sender;
            tx1.Text += b.Content.ToString();
        }
        private void bSign_Click(object sender, RoutedEventArgs e)
        {
            Check4Clear();
            Button b = (Button)sender;
            if (!String.IsNullOrEmpty(tx1.Text))
            {
                tx2.Text += tx1.Text + b.Content.ToString();
                tx1.Text = "";
            }
        }
        private void bEq_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (!String.IsNullOrEmpty(tx1.Text) && !String.IsNullOrEmpty(tx2.Text))
            {
                tx2.Text += tx1.Text + b.Content.ToString();
                try
                { tx1.Text = Calculate(tx2.Text).ToString(); }
                catch { tx1.Text = "Error"; }
            }
        }
        private double Calculate(string s)
        {
            s = s.Remove(s.Length-1);
            s=s.Replace(',','.');
            double result = Convert.ToDouble(new DataTable().Compute(s, null));//нашел на stackoverflow https://stackoverflow.com/questions/355062/is-there-a-string-math-evaluator-in-net вроде работает :)
            return result;
        }
        private void Check4Clear()
        {
            if (tx2.Text.Contains('='))
                tx2.Text = "";
            if (tx1.Text.Contains('r'))//Проврека на Error
                tx1.Text = "";
        }
    }
}
