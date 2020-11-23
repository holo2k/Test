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

namespace Контрольная_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isEmpty=false;

        public MainWindow()
        {
            InitializeComponent();
        }

        void _isEmpty() // Проверка на пустые текстбоксы
        { 
            if ((tbOklad.Text.Length>0)&&
                (tbPrem.Text.Length > 0)&&
                (tbKoef.Text.Length > 0)&&
                (tbWorkDays.Text.Length > 0)&&
                (tbWorkedDays.Text.Length > 0))
            {
                isEmpty = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _isEmpty();
            if (isEmpty)
            {
                double oklad = Convert.ToDouble(tbOklad.Text);
                double premiya = Convert.ToDouble(tbPrem.Text);
                double koef = Convert.ToDouble(tbKoef.Text);
                double workDays = Convert.ToDouble(tbWorkDays.Text);
                double workedDays = Convert.ToDouble(tbWorkedDays.Text);

                double fullSalary = oklad * koef * workedDays / workDays + premiya;
                double NDFL = fullSalary * 0.13;
                double salaryOnHands = fullSalary - NDFL;

                lblAnswer.Content = "Ответ: \n" +
                                    $"Полная з/п, руб = {fullSalary} \n" +
                                    $"НДФЛ 13%, руб = {NDFL} \n" +
                                    $"Зарплата на руки, руб = {salaryOnHands}";
            }
            else
            {
                lblAnswer.Content = "Заполните все данные";
            }
            
         }

        public int DS_Count(string s) //Метод для ввода double чисел в текстбоксы
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }

        private void TbOklad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString()) && (DS_Count(((TextBox)sender).Text) < 1))));
        }
    }
}
