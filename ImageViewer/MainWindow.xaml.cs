using Microsoft.Win32;
using System.IO;
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

namespace ImageViewer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    string folder = "";
	int current_file = 0;
    public MainWindow()
    {
        folder = "C:\\Users\\Ajeszny\\Pictures";
		var folderDialog = new OpenFolderDialog();

		if (folderDialog.ShowDialog() == true)
		{
			folder = folderDialog.FolderName;
		}
		InitializeComponent();
    }

	private void Left_Click(object sender, RoutedEventArgs e)
	{

		var files = Directory.EnumerateFiles(folder).ToList<string>();
		current_file = current_file - 1;
		if (current_file == -1)
		{
			current_file = files.Count - 1;
		}
		try
		{
			NotSupported.Visibility = Visibility.Hidden;
			Shower.Source = new BitmapImage(new Uri(files[current_file]));
		}
		catch (NotSupportedException ex)
		{
			NotSupported.Visibility = Visibility.Visible;
			Shower.Source = null;
		}
	}

	private void Right_Click(object sender, RoutedEventArgs e)
	{
		var files = Directory.EnumerateFiles(folder).ToList<string>();
		current_file = current_file + 1;
		if (current_file == files.Count)
		{
			current_file = 0;
		}
		try
		{
			NotSupported.Visibility = Visibility.Hidden;
			Shower.Source = new BitmapImage(new Uri(files[current_file]));
		} catch (NotSupportedException ex)
		{
			NotSupported.Visibility = Visibility.Visible;
			Shower.Source = null;
		}
	}

	private void FolderChoice_Click(object sender, RoutedEventArgs e)
	{
		var folderDialog = new OpenFolderDialog();

		if (folderDialog.ShowDialog() == true)
		{
			folder = folderDialog.FolderName;
		}
	}
}