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

        // OK Button Click - Close the dialog and return the shift value
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            // Attempt to parse the shift value from the TextBox
            if (int.TryParse(ShiftValueBox.Text, out int shift))
            {
                // Set the shift value if it's valid
                ShiftValue = shift;
                DialogResult = true; // Close the dialog and indicate success
            }
            else
            {
                MessageBox.Show("Please enter a valid integer value.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Cancel Button Click - Close the dialog without saving the value
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Close the dialog and indicate cancellation
        }

        // Optional: Prevent non-numeric input in the ShiftValueBox
        private void ShiftValueBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only digits and control keys like backspace
            e.Handled = !char.IsDigit(e.Text, 0) && !char.IsControl(e.Text, 0);
        }
    }
}

