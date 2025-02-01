using System.Windows;
using System.Windows.Input;

namespace TextEncryptor
{
    public partial class ShiftInputDialog : Window
    {
        public int? ShiftValue { get; private set; }

        public ShiftInputDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ShiftValueBox.Text, out int shift))
            {
                ShiftValue = shift;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid integer value.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ShiftValueBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0) && !char.IsControl(e.Text, 0);
        }
    }
}

