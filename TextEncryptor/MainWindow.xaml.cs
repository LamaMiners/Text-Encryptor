using CaesarCipher;
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

namespace TextEncryptor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private Mode mode;

    private enum Mode
    {
        Caesar,
        Vigenere,
        Blank2
    }


    public MainWindow()
    {
        InitializeComponent();

        mINew.Click += ResetButton_Click;
        mIExit.Click += ExitButton_Click;

        // Bind Input Events
        InputField.TextChanged += InputField_TextChanged;
        InputField.GotFocus += InputField_GotFocus;
        InputField.LostFocus += InputField_LostFocus;

        // Bind Output Events
        OutputField.TextChanged += OutputField_TextChanged;

        // Bind Encryption Button
        EncryptButton.Click += EncryptButton_Click;

        // Bind Decryption Button
        DecryptButton.Click += DecryptButton_Click;

        // Bind Reset Button
        ResetButton.Click += ResetButton_Click;

        // Bind Copy Button
        CopyButton.Click += CopyButton_Click;

        // Bind Exit Button
        ExitButton.Click += ExitButton_Click;
    }

    // Enables the Encryption Button
    private void InputField_TextChanged(object sender, TextChangedEventArgs e)
    {
        EncryptButton.IsEnabled = !string.IsNullOrEmpty(InputField.Text) && !InputField.Text.Equals("Type here ...");
        DecryptButton.IsEnabled = !string.IsNullOrEmpty(InputField.Text) && !InputField.Text.Equals("Type here ...");
    }

    // Removes the watermark text
    private void InputField_GotFocus(object sender, RoutedEventArgs e)
    {
        if (InputField.Text.Equals("Type here ..."))
        {
            InputField.Text = string.Empty;
        }
    }

    // Reenables the watermark text
    private void InputField_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(InputField.Text))
        {
            InputField.Text = "Type here ...";
        }
    }

    private void OutputField_TextChanged(object sender, TextChangedEventArgs e)
    {
        CopyButton.IsEnabled = !string.IsNullOrEmpty(OutputField.Text) && !OutputField.Text.Equals("Output will appear here ...");
        mIExport.IsEnabled = !string.IsNullOrEmpty(OutputField.Text) && !OutputField.Text.Equals("Output will appear here ...");
    }

    private void EncryptButton_Click(object sender, RoutedEventArgs e)
    {
        Cipher cc = new Cipher();

        int value = 0;
        string key = string.Empty;

        string encryptedText = string.Empty;

        if (CaesarRadioButton.IsChecked == true)
        {
            mode = Mode.Caesar;
            value = OpenShiftDialog();
        }
        else if (VigenereRadioButton.IsChecked == true)
        {
            mode = Mode.Vigenere;
            key = OpenKeyDialog();
        }

        // Use the shift value (e.g., for encryption)
        switch (mode)
        {
            case Mode.Caesar:
                encryptedText = cc.EncryptCaesar(InputField.Text.ToCharArray(), value);
                break;
            case Mode.Vigenere:
                encryptedText = cc.EncryptVigenere(InputField.Text.ToCharArray(), key);
                break;
        }
        OutputField.Text = encryptedText;
    }

    private void DecryptButton_Click(Object sender, RoutedEventArgs e)
    {
        int value = OpenShiftDialog();

        string decrytedText = string.Empty;

        if (CaesarRadioButton.IsChecked == true)
        {
            mode = Mode.Caesar;
        }

        switch (mode)
        {
            case Mode.Caesar:
                Cipher cc = new Cipher();
                decrytedText = cc.DecryptCaesar(InputField.Text.ToCharArray(), value);
                break;
        }
        OutputField.Text = decrytedText;
    }

    private int OpenShiftDialog()
    {
        // Create and display the dialog
        var shiftDialog = new ShiftInputDialog
        {
            Owner = this
        };

        int shiftValue = 0;

        // Show the dialog
        if (shiftDialog.ShowDialog() == true)
        {
            shiftValue = shiftDialog.ShiftValue ?? 0;
           
        }
        return shiftValue;
    }

    private string OpenKeyDialog()
    {

        var keyDialog = new KeyInputDialog
        {
            Owner = this
        };

        string key = string.Empty;

        if (keyDialog.ShowDialog() == true)
        {
            key = keyDialog.Key;
        }

        return key;
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e)
    {
        InputField.Text = "Type here ...";
        OutputField.Text = "Output will appear here ...";

        CaesarRadioButton.IsChecked = true;
    }

    private void CopyButton_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Clipboard.SetText(OutputField.Text);
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
    }

}