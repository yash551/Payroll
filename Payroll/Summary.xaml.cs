/*
 *Name: Yash Gadhiya
 *Last modified: Oct 12, 2020
 *Title: IncInc Payroll (Piecework)
 *Course: NETD 3201
 *Description: This file contains static info about all 
 *             the workers for piceworkworker class and
 *             it outputs total numbers of workers,
 *             messages, pay and avg pay.

 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Payroll
{
    /// <summary>
    /// Interaction logic for Summary.xaml
    /// </summary>
    public partial class Summary : Window
    {
        public Summary()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Populate all the labels to display values of totalWorker, totalMessages, totalPay and avgPay of all the workers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummaryLoaded(object sender, RoutedEventArgs e)
        {
            lblTotalWorker.Content = PieceworkWorker.TotalWorkers.ToString();
            lblTotalMessage.Content = PieceworkWorker.TotalMessages();
            lblTotalPay.Content = PieceworkWorker.TotalPay.ToString("c");
            lblAvgPay.Content = PieceworkWorker.AveragePay.ToString("c");
            btnExit.Focus();
        }
    }
}
