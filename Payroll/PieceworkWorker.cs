// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: oct 12, 2020
//    Written By: Yash Gadhiya
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.

// This is currently incomplete; note the four comment blocks
// below that begin with "TO DO"

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Payroll // Ensure this namespace matches your own
{
    class PieceworkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private int employeeMessages;
        private decimal employeePay = 0M;

        // Shared class variables
        private static int totalEmployees = 0;
        private static int totalMessages = 0;
        private static decimal totalPay = 0M;

        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string nameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Calculcate the worker's pay and update all summary values
            findPay();
        }

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
        {

        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        private void findPay()
        {
            // Declare a large bank of constants describing the pay structure.
            const int LowestMessageThreshold = 1000;
            const int LowMessageThreshold = 2000;
            const int MediumMessageThreshold = 3000;
            const int HighMessageThreshold = 4000;
            const int UpperBound = 10000;

            // Declare a large bank of constants for the various pay rates.
            const decimal LowestPayRate = 0.021M;
            const decimal LowPayRate = 0.028M;
            const decimal MediumPayRate = 0.035M;
            const decimal HighPayRate = 0.040M;
            const decimal HighestPayRate = 0.045M;

            //Folowing lab requirements given in handout
                if (employeeMessages < LowestMessageThreshold)
                {
                    employeePay = employeeMessages * LowestPayRate;
                }
                else if (employeeMessages < LowMessageThreshold)
                {
                    employeePay = employeeMessages * LowPayRate;
                }
                else if (employeeMessages < MediumMessageThreshold)
                {
                    employeePay = employeeMessages * MediumPayRate;
                }
                else if (employeeMessages < HighMessageThreshold)
                {
                    employeePay = employeeMessages * HighPayRate;
                }
                else if (employeeMessages <= UpperBound)
                {
                    employeePay = employeeMessages * HighestPayRate;
                }

                //counters for totalPay, totalMessages, totalEmployees
                totalPay += employeePay;        
                totalMessages += employeeMessages;
                totalEmployees++;
            
        }
        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                return employeeName;
            }
            set
            {

                employeeName = value;
                //condition if workername's field is empty
                if (employeeName == "")
                {
                    throw new ArgumentException("Please enter worker's Name", "Name Error");
                }

            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {

                //condition to validate total messages field
                if (!int.TryParse(value, out employeeMessages)) // if user inputs non integer number
                {
                    throw new ArgumentException("Numbers of messages must be a whole number", "Message Error");
                }
                else if (employeeMessages <= 0 || employeeMessages > 10000)  //if user inputs out of range value
                {
                    throw new ArgumentOutOfRangeException("Message Error", "Number of messages must be 0 and 10000.");
                }

            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return employeePay;
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {   
                return totalPay;
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {
                return totalEmployees;
            }
        }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages()
        {
            return totalMessages;
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {   
            get
            {
                //To avoid the error if users clicks summary without inputing any workers
                if (TotalWorkers == 0)
                {
                    return 0;
                }
                else
                {
                    return TotalPay / TotalWorkers; //return average pay 
                }
            }
        }

        #endregion

    }
}
