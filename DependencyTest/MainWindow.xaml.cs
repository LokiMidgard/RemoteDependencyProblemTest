using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace DependencyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NativeMethods.Test(3, out var result);


                button.Content = result;

            }
            catch (Exception ex)
            {
                button.Content = ex.ToString();

            }
        }
    }

    public static class NativeMethods
    {
        private const string NATIVE_DLL = @"TheDependency.dll";



        [DllImport(NATIVE_DLL, CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void Test(int path, out int result);

    }
}
