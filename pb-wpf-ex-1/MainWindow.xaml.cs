using pb_wpf_ex_1.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace pb_wpf_ex_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CouponMachine couponMachine;

        public TextBox AddCouponTextBox { get; set; }
        public Label TakeCouponLabel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            couponMachine = new();
            machineStateLabel.Content = $"Current machine state: {string.Join(", ", couponMachine.PeekCoupons())}";
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            if (addCouponTextBox.Text == "") return;
            
            try
            {
                couponMachine.Add(addCouponTextBox.Text);
                messageLabel.Content = $"Coupon {addCouponTextBox.Text} was added to the machine";
            }
            catch (Exception)
            {
                messageLabel.Content = "Coupon could not be added to the machine";
            }
            machineStateLabel.Content = $"Current machine state: {string.Join(", ", couponMachine.PeekCoupons())}";
        }

        private void OnTakeButtonClick(object sender, RoutedEventArgs e)
        {
            if (couponMachine.IsEmpty())
            {
                messageLabel.Content = "Machine is empty";
                return;
            }

            try
            {
                string coupon = couponMachine.TakeRandom();
                messageLabel.Content = $"Following coupon was taken out of the machine randomly: {coupon}";
            }
            catch (Exception)
            {
                messageLabel.Content = "No coupon could be taken from the machine";
            }

            machineStateLabel.Content = $"Current machine state: {string.Join(", ", couponMachine.PeekCoupons())}";
        }
    }
}
