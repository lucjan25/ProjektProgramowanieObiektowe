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
using System.Windows.Interop;

namespace Pasjans
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool startMove = false;
        private bool wasteSelected = false;
        private bool graWToku = false;
        private int selectedIndex;
        private List<Karta> selectedList;
        public List<Karta> Stack1 { get; set; }
        public List<Karta> Stack2 { get; set; }
        public List<Karta> Stack3 { get; set; }
        public List<Karta> Stack4 { get; set; }
        public List<Karta> Stack5 { get; set; }
        public List<Karta> Stack6 { get; set; }
        public List<Karta> Stack7 { get; set; }
        public List<Karta> StackClubs { get; set; }
        public List<Karta> StackSpades { get; set; }
        public List<Karta> StackHearts { get; set; }
        public List<Karta> StackDiamonds { get; set; }
        public List<Karta> Stock { get; set; }
        public List<Karta> Waste { get; set; }
        public MainWindow()
        {
            Stack1 = new List<Karta>();
            Stack2 = new List<Karta>();
            Stack3 = new List<Karta>();
            Stack4 = new List<Karta>();
            Stack5 = new List<Karta>();
            Stack6 = new List<Karta>();
            Stack7 = new List<Karta>();
            StackClubs = new List<Karta>();
            StackSpades = new List<Karta>();
            StackHearts = new List<Karta>();
            StackDiamonds = new List<Karta>();
            Stock = new List<Karta>();
            Waste = new List<Karta>();
            InitializeComponent();

        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (graWToku == false)
            {
                Rozdaj();
                graWToku = true;
                btnStart.Content = "Od nowa";
                btnStock.IsEnabled = true;
                btnWaste.IsEnabled = true;
                btnStack1.IsEnabled = true;
                btnStack2.IsEnabled = true;
                btnStack3.IsEnabled = true;
                btnStack4.IsEnabled = true;
                btnStack5.IsEnabled = true;
                btnStack6.IsEnabled = true;
                btnStack7.IsEnabled = true;
                btnClubs.IsEnabled = true;
                btnSpades.IsEnabled = true;
                btnHearts.IsEnabled = true;
                btnDiamonds.IsEnabled = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz rozpocząć nową grę?", "Uwaga", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Rozdaj();
                        Refresh();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            if (Stock.Count != 0)
            {
                for (int i = 0; i < 1; ++i)
                {
                    if (Stock.Count != 0)
                    {
                        Waste.Add(Stock.Last());
                        Stock.Remove(Stock.Last());
                    }
                    else break;
                }
            }
            else
            {
                while (Waste.Count != 0)
                {
                    Stock.Add(Waste.Last());
                    Waste.Remove(Waste.Last());
                }
            }
            if (wasteSelected == false)
            {
                startMove = false;
                wasteSelected = false;
            }
            Refresh();
        }
        private void btnWaste_Click(object sender, RoutedEventArgs e)
        {
            if (Waste.Count != 0 && startMove == false)
            {
                List<Karta> ls = Waste;
                wasteSelected = true;
                StartRuch(ls);
            }
        }
        private void btnClubs_Click(object sender, RoutedEventArgs e)
        {
            if (startMove == true && selectedList[selectedIndex] == selectedList.Last() && (int)selectedList.Last().Kolor == 1)
            {
                Odloz(selectedList, StackClubs, selectedIndex);
            }
            else startMove = false;
        }
        private void btnSpades_Click(object sender, RoutedEventArgs e)
        {
            if (startMove == true && selectedList[selectedIndex] == selectedList.Last() && (int)selectedList.Last().Kolor == 2)
            {
                Odloz(selectedList, StackSpades, selectedIndex);
            }
            else startMove = false;
        }
        private void btnHearts_Click(object sender, RoutedEventArgs e)
        {
            if (startMove == true && selectedList[selectedIndex] == selectedList.Last() && (int)selectedList.Last().Kolor == 3)
            {
                Odloz(selectedList, StackHearts, selectedIndex);
            }
            else startMove = false;
        }
        private void btnDiamonds_Click(object sender, RoutedEventArgs e)
        {
            if (startMove == true && selectedList[selectedIndex] == selectedList.Last() && (int)selectedList.Last().Kolor == 4)
            {
                Odloz(selectedList, StackDiamonds, selectedIndex);
            }
            else startMove = false;
        }
        private void btnStack1_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack1;
            ListBox lb = lbStack1;
            StartRuch(ls, lb);
        }

        private void btnStack2_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack2;
            ListBox lb = lbStack2;
            StartRuch(ls, lb);
        }
        private void btnStack3_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack3;
            ListBox lb = lbStack3;
            StartRuch(ls, lb);
        }
        private void btnStack4_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack4;
            ListBox lb = lbStack4;
            StartRuch(ls, lb);
        }
        private void btnStack5_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack5;
            ListBox lb = lbStack5;
            StartRuch(ls, lb);
        }
        private void btnStack6_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack6;
            ListBox lb = lbStack6;
            StartRuch(ls, lb);
        }
        private void btnStack7_Click(object sender, RoutedEventArgs e)
        {
            List<Karta> ls = Stack7;
            ListBox lb = lbStack7;
            StartRuch(ls, lb);
        }

        private void lbS1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack1;
            ListBox lb = lbStack1;
            StartRuch(ls, lb);
        }

        private void lbS2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack2;
            ListBox lb = lbStack2;
            StartRuch(ls, lb);
        }

        private void lbS3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack3;
            ListBox lb = lbStack3;
            StartRuch(ls, lb);
        }

        private void lbS4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack4;
            ListBox lb = lbStack4;
            StartRuch(ls, lb);
        }
        private void lbS5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack5;
            ListBox lb = lbStack5;
            StartRuch(ls, lb);
        }
        private void lbS6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack6;
            ListBox lb = lbStack6;
            StartRuch(ls, lb);
        }
        private void lbS7_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Karta> ls = Stack7;
            ListBox lb = lbStack7;
            StartRuch(ls, lb);
        }

        private void Refresh()
        {
            lbStack1.Items.Refresh();
            lbStack2.Items.Refresh();
            lbStack3.Items.Refresh();
            lbStack4.Items.Refresh();
            lbStack5.Items.Refresh();
            lbStack6.Items.Refresh();
            lbStack7.Items.Refresh();
            if (StackClubs != null && StackClubs.Count != 0)
            {
                btnClubs.Content = StackClubs.Last().ToString();
            }
            else btnClubs.Content = "♣#";
            if (StackSpades != null && StackSpades.Count != 0)
            {
                btnSpades.Content = StackSpades.Last().ToString();
            }
            else btnSpades.Content = "♠#";
            if (StackHearts != null && StackHearts.Count != 0)
            {
                btnHearts.Content = StackHearts.Last().ToString();
            }
            else btnHearts.Content = "♥#";
            if (StackDiamonds != null && StackDiamonds.Count != 0)
            {
                btnDiamonds.Content = StackDiamonds.Last().ToString();
            }
            else btnDiamonds.Content = "♦#";
            if (Stock != null && Stock.Count != 0)
            {
                btnStock.Content = Stock.Last().ToString();
                lblStock.Content = Stock.Count().ToString();
            }
            else
            {
                btnStock.Content = "R";
                lblStock.Content = '0';
            }
            if (Waste != null && Waste.Count != 0)
            {
                btnWaste.Content = Waste.Last().ToString();
                lblWaste.Content = Waste.Count().ToString();
            }
            else
            {
                btnWaste.Content = "-";
                lblWaste.Content = '0';
            }
        }

        private void Odloz(List<Karta> stosA, List<Karta> stosB, int indeks)
        {
            startMove = false;
            if (stosB.Count() != 0 && stosA.Count() != 0 && (int)stosB.Last().Rank == (int)stosA.Last().Rank - 1)
            {
                stosB.AddRange(stosA.GetRange(indeks, stosA.Count - indeks));
                stosA.RemoveRange(indeks, stosA.Count - indeks);
                if (stosA.Count != 0) stosA.Last().Odkryj();
                Refresh();
                CheckVictory();
            }
            else if (stosB.Count() == 0 && stosA.Count() != 0 && stosA[indeks].Rank == (Rank)1)
            {
                stosB.AddRange(stosA.GetRange(indeks, stosA.Count - indeks));
                stosA.RemoveRange(indeks, stosA.Count - indeks);
                if (stosA.Count != 0) stosA.Last().Odkryj();
                Refresh();
            }
        }
        private void Ruch(List<Karta> stosA, List<Karta> stosB, int indeks)
        {
            startMove = false;
            if (stosA.ElementAtOrDefault(indeks) != null && stosB.Count() != 0 && stosA.Count() != 0 && stosB.Last().Barwa() != stosA[indeks].Barwa() & (int)stosB.Last().Rank == (int)stosA[indeks].Rank + 1)
            {
                stosB.AddRange(stosA.GetRange(indeks, stosA.Count - indeks));
                stosA.RemoveRange(indeks, stosA.Count - indeks);
                if (stosA.Count != 0) stosA.Last().Odkryj();
                Refresh();
            }
            else if (stosB.Count() == 0 && stosA.Count() != 0 && stosA[indeks].Rank == (Rank)13)
            {
                stosB.AddRange(stosA.GetRange(indeks, stosA.Count - indeks));
                stosA.RemoveRange(indeks, stosA.Count - indeks);
                if (stosA.Count != 0) stosA.Last().Odkryj();
                Refresh();
            }
        }
        private void StartRuch(List<Karta> ls, ListBox lb)
        {
            if (startMove == false && lb.SelectedIndex != -1 && ls.Count != 0 && ls[lb.SelectedIndex].Odkryta == true)
            {
                startMove = true;
                selectedList = ls;
                selectedIndex = lb.SelectedIndex;
            }
            else if (startMove == true & selectedList != null & selectedList != ls)
            {
                Ruch(selectedList, ls, selectedIndex);
            }
            else startMove = false;
        }
        private void StartRuch(List<Karta> ls)
        {
            if (startMove == false && ls.Count != 0)
            {
                startMove = true;
                selectedList = ls;
                selectedIndex = ls.Count - 1;
            }
            else startMove = false;

        }
        public static Stack<Karta> Tasuj()
        {
            List<Karta> talia = new List<Karta>();
            var rnd = new Random();
            for (int i = 1; i < 5; ++i)
            {
                for (int j = 1; j < 14; ++j)
                {
                    talia.Add(new Karta((Kolor)i, (Rank)j));
                }
            }
            Stack<Karta> przetasowanaTalia = new Stack<Karta>(talia.OrderBy(item => rnd.Next()));
            return przetasowanaTalia;
        }
        public void Rozdaj()
        {
            Stack<Karta> talia = Tasuj();
            StackClubs.Clear();
            StackSpades.Clear();
            StackHearts.Clear();
            StackDiamonds.Clear();
            Stack1.Clear();
            Stack2.Clear();
            Stack3.Clear();
            Stack4.Clear();
            Stack5.Clear();
            Stack6.Clear();
            Stack7.Clear();
            Stock.Clear();
            Waste.Clear();
            Stack1.Add(talia.Pop());
            for (int i = 0; i < 2; ++i)
                Stack2.Add(talia.Pop());
            for (int i = 0; i < 3; ++i)
                Stack3.Add(talia.Pop());
            for (int i = 0; i < 4; ++i)
                Stack4.Add(talia.Pop());
            for (int i = 0; i < 5; ++i)
                Stack5.Add(talia.Pop());
            for (int i = 0; i < 6; ++i)
                Stack6.Add(talia.Pop());
            for (int i = 0; i < 7; ++i)
                Stack7.Add(talia.Pop());
            for (int i = 0; i < 24; ++i)
            {
                Stock.Add(talia.Pop());
                Stock.Last().Odkryj();
            }
            btnStock.Content = Stock.Last().ToString();
            lblStock.Content = Stock.Count().ToString();
            Stack1.Last().Odkryj();
            Stack2.Last().Odkryj();
            Stack3.Last().Odkryj();
            Stack4.Last().Odkryj();
            Stack5.Last().Odkryj();
            Stack6.Last().Odkryj();
            Stack7.Last().Odkryj();
            lbStack1.ItemsSource = Stack1;
            lbStack2.ItemsSource = Stack2;
            lbStack3.ItemsSource = Stack3;
            lbStack4.ItemsSource = Stack4;
            lbStack5.ItemsSource = Stack5;
            lbStack6.ItemsSource = Stack6;
            lbStack7.ItemsSource = Stack7;
        }
        void CheckVictory()
        {
            if (StackClubs.Count != 0 && StackSpades.Count != 0 && StackHearts.Count != 0 && StackDiamonds.Count != 0)
            {
                if (StackClubs.Last().Rank == (Rank)13 && StackSpades.Last().Rank == (Rank)13 && StackHearts.Last().Rank == (Rank)13 && StackDiamonds.Last().Rank == (Rank)13)
                {
                    MessageBox.Show("Wygrana!", "Gratulacje", MessageBoxButton.OK);
                    Rozdaj();
                    btnStart.Content = "Nowa gra";
                    btnStock.IsEnabled = false;
                    btnWaste.IsEnabled = false;
                    btnStack1.IsEnabled = false;
                    btnStack2.IsEnabled = false;
                    btnStack3.IsEnabled = false;
                    btnStack4.IsEnabled = false;
                    btnStack5.IsEnabled = false;
                    btnStack6.IsEnabled = false;
                    btnStack7.IsEnabled = false;
                    btnClubs.IsEnabled = false;
                    btnSpades.IsEnabled = false;
                    btnHearts.IsEnabled = false;
                    btnDiamonds.IsEnabled = false;
                }
            }
        }
    }
}