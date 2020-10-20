/*
 *Name: Yash Gadhiya
 *Last modified: Oct 12, 2020
 *Title: IncInc Payroll (Piecework)
 *Course: NETD 3201
 *Description: This file contains calculate and clear button handles,
 *             which will be used to create a neww object when calculate 
 *             button is used and clear all the fields when clear button 
 *             is used.
 */

using Payroll;
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

namespace Payroll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtWorkerName.Focus();
        }
        /// <summary>
        /// This handle will calculate the total pay of the worker if both inputs are correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newWorker = new PieceworkWorker(txtWorkerName.Text, txtMessageCount.Text); //creating a new object

                txtPay.Text = newWorker.Pay.ToString("c"); //Assigning TotalPay method to pay textbox

                btnClear.Focus();  // focus on clear button
                txtWorkerName.IsEnabled = false; //disabling workername, messagecount textboxes and calculate button
                txtMessageCount.IsEnabled = false;
                btnCalculate.IsEnabled = false;
                    
                //empty the labels after validation
                lblMessageError.Content = String.Empty;
                lblNameError.Content = String.Empty;

                //change color to white after validation
                txtWorkerName.Background = Brushes.White;
                txtMessageCount.Background = Brushes.White;
            }
            catch (ArgumentOutOfRangeException ex) // catching out of range argument exception
            {
                if (ex.ParamName == "Message Error")
                {
                    lblMessageError.Content = ex.Message; //To show the error message in label
                    HighlightTextbox(txtMessageCount); //using HighlightTextbox method to highlight it as required
                }
            }
            catch (ArgumentException ex) //catching ar
            {

                if (ex.ParamName == "Name Error")
                {
                    lblNameError.Content = ex.Message;
                    HighlightTextbox(txtWorkerName);
                }   
                else if (ex.ParamName == "Message Error")
                {
                    lblMessageError.Content = ex.Message;
                    HighlightTextbox(txtMessageCount);
                }
            }
        }
        /// <summary>
        /// This is handle will clear all the textbox and set all properties to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            setDefaults(); //setDefaults method to set all properties to default
        }

        /// <summary>
        /// Shows the summary to display all the Pieceworkworkers static info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSummary_Clicked(object sender, RoutedEventArgs e)
        {
            //create a new object summaryWindow
            var summaryWindow = new Summary();
            summaryWindow.ShowDialog();
        }

        /// <summary>
        /// This method will set all the properties to default. It will also clear the meassage from the error labels and convert color to white.
        /// </summary>
        private void setDefaults()
        {
            txtWorkerName.Text = string.Empty;          //clear worker name textbox
            txtMessageCount.Text = string.Empty;        //clear message count textbox
            txtPay.Text = string.Empty;                 //clear pay textbox
            txtWorkerName.Focus();                      //focus on workername textbox
            txtWorkerName.IsEnabled = true;
            txtMessageCount.IsEnabled = true;
            btnCalculate.IsEnabled = true;

            //clear the content from the error labels
            lblMessageError.Content = String.Empty;
            lblNameError.Content = String.Empty;

            //convert color from red to white
            txtWorkerName.Background = Brushes.White;
            txtMessageCount.Background = Brushes.White;

            //focus on worker name
            txtWorkerName.Focus();
        }

        /// <summary>
        /// Highlights the given textbox
        /// </summary>
        /// <param name="textboxToHighlight"></param>
        private void HighlightTextbox(TextBox textboxToHighlight)
        {
            textboxToHighlight.Focus();  //to focus on given textbox
            textboxToHighlight.SelectAll(); //to select the content
            textboxToHighlight.Background = Brushes.Red; //change background color to red
        }
    }
}
