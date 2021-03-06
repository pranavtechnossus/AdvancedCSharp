﻿using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            #region Generic List
            //using Collection Initializers
            var colorOptions = new List<string>()
                                   { "red","Espresso","White","navy"};
            //colorOptions.Add("Red");
            //colorOptions.Add("Espresso");
            //colorOptions.Add("White");
            //colorOptions.Add("Navy");
            //colorOptions.Insert(2, "Purple");
            //colorOptions.Remove("White");
            WriteLine(colorOptions);




            //var colorOptions = new string[4];
            //colorOptions[0] = "Red";
            //colorOptions[1] = "Espresso";
            //colorOptions[2] = "White";
            //colorOptions[3] = "Navy";

            //using Collection Initializers
            //  var colorOptions = new string[4] { "Red", "Espresso", "White", "Navy" };
            //Or We can write it another way by reducing new Clause (Best Practices for getting Array)
            // string[] colorOptions = { "Red", "Espresso", "White", "Navy" };

            // give the index of the current element(Example of static Array method)
            //var brownIndex=  Array.IndexOf(colorOptions, "Espresso");
            //Example of instance method array
            //colorOptions.SetValue("Blue", 3);
            //for (int i = 0; i < colorOptions.Length; i++)
            //{
            //    colorOptions[i] = colorOptions[i].ToLower();
            //}
            //foreach (var color in colorOptions)
            //{
            //    WriteLine($"The color is {color}");
            //}
            //WriteLine(colorOptions[1]);
            #endregion



            var states = new Dictionary<string, string>()
            {
                { "CA", "California"},
                {"WA", "Washington" },
                { "CO", "Colorado Springs"},
                {"CO", "Colorado Springs" }
            };
            WriteLine(states);

            //states.Add("CA", "California");
            //states.Add("WA", "Washington");
            //states.Add("NY", "New York");
            //states.Add("CO", "Colorado Springs");
           


        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";
            if (markupPercent <= 0m)
            {
                message = "Invalid markup percentage";
            }
            else if(markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }
            var value = this.Cost + (this.Cost * markupPercent / 100);
            var operationalResult = new OperationResult<decimal>(value, message);
            return operationalResult;
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
