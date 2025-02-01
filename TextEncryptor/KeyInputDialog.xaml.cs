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
using System.Windows.Shapes;

namespace TextEncryptor;

/// <summary>
/// Interaktionslogik für KeyInputDialog.xaml
/// </summary>
public partial class KeyInputDialog : Window
{

    public string? Key { get; private set; }

    public KeyInputDialog()
    {
        InitializeComponent();
    }

    private void OKButton_Click(object sender, RoutedEventArgs e)
    {
        Key = ShiftValueBox.Text;
        DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}
