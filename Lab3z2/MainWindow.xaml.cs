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

namespace Lab3z2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Cr = 7190, Mg = 1740, S = 2000, W = 19200, Au = 19300;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbSave_Checked(object sender, RoutedEventArgs e)
        {
            tbDensity.IsReadOnly = false;
            tbDensity.Clear();
        }

        private void cbSave_Unchecked(object sender, RoutedEventArgs e)
        {
            tbDensity.IsReadOnly = true;
            tbDensity.Clear();
        }

        private void btnExec_Click(object sender, RoutedEventArgs e)
        {
            double result = -1;
            if (cbSave.IsChecked == false)
            {
                try
                {
                    switch (lbSubstance.SelectedIndex)
                    {
                        case 0: 
                            result = Cr;
                            break;
                        case 1:
                            result = Mg;
                            break;
                        case 2:
                            result = S;
                            break;
                        case 3:
                            result = W;
                            break;
                        case 4:
                            result = Au;
                            break;
                        default:
                            tbDensity.Text = "Zaznacz substancję!";
                            break;
                    }
                    if (rdKg.IsChecked == true && result > 0)
                    {
                        tbDensity.Text = result.ToString() + " kg/m^3";
                    }
                    else if (result > 0)
                    {
                        tbDensity.Text = (result/1000).ToString() + " g/cm^3";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Nieoczekiwany błąd.", "Błąd", MessageBoxButton.OK);
                }
            }
            else
            {
                try
                {
                    result = Convert.ToDouble(tbDensity.Text);
                    if (rdG.IsChecked == true)
                    {
                        result *= 1000;
                    }
                    if (result > 0)
                    {
                        switch (lbSubstance.SelectedIndex)
                        {
                            case 0:
                                Cr = result;
                                break;
                            case 1:
                                Mg = result;
                                break;
                            case 2:
                                S = result;
                                break;
                            case 3:
                                W = result;
                                break;
                            case 4:
                                Au = result;
                                break;
                            default:
                                tbDensity.Text = "Zaznacz substancję!";
                                break;
                        }
                    }
                    else
                    {
                        tbDensity.Text = "Niedodatnia wartość!";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano błędne dane.", "Błąd", MessageBoxButton.OK);
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
