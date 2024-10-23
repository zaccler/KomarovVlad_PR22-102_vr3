using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SizeTextBox.Text = "12";
            MinTextBox.Text = "1";
            MaxTextBox.Text = "70";
        }

        private void GenerateAndSortArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int N = int.Parse(SizeTextBox.Text);
                int min = int.Parse(MinTextBox.Text);
                int max = int.Parse(MaxTextBox.Text);

                if (min > max)
                {
                    MessageBox.Show("Минимальное значение не может быть больше максимального.");
                    return;
                }

                int[] array = GenerateArray(N, min, max);

                string originalArray = string.Join(", ", array);

                // Сортировка массива: чётные, нечётные
                int[] sortedArray = array.OrderBy(x => x % 2 != 0).ToArray();

                string sortedArrayString = string.Join(", ", sortedArray);

                ResultTextBox.Text = $"Сгенерированный массив:\n{originalArray}\n\nОтсортированный массив:\n{sortedArrayString}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа.");
            }
        }

        // Генирация чисел
        private int[] GenerateArray(int size, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = rand.Next(minValue, maxValue + 1);
            }
            return result;
        }
    }
}
     
       