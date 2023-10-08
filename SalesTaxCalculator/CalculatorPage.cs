using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace SalesTaxCalculator
{
    public class CalculatorPage : ContentPage
    {
        Label lblPrice;
        Label lblSale;
        Label lblTax;
        Label lblTip;
        Label lblSplit;
        Label lblSplitValue;
        Label lblCost;
        Entry txtPrice;
        Entry txtSale;
        Entry txtTax;
        Entry txtTip;
        Stepper stpSplit;
        Button btnCalculate;
        Button btnClear;

        double price;
        double sale;
        double tax;
        double tip;
        double split;
        double cost;

        public CalculatorPage()
        {
            lblPrice = new Label
            {
                Text = "Price:",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            txtPrice = new Entry
            {
                Placeholder = "Enter Price",
                FontSize = 20,
                BackgroundColor = Colors.Transparent,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Numeric,

            };

            Grid.SetRow(txtPrice, 0);
            Grid.SetColumn(txtPrice, 1);
            Grid.SetColumnSpan(txtPrice, 2);

            lblSale = new Label
            {
                Text = "Sale:",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            txtSale = new Entry
            {
                Placeholder = "Enter Sale Percentage",
                FontSize = 20,
                Margin = new Thickness(10),
                BackgroundColor = Colors.Transparent,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Numeric,
            };

            Grid.SetRow(txtSale, 1);
            Grid.SetColumn(txtSale, 1);
            Grid.SetColumnSpan(txtSale, 3);

            lblTax = new Label
            {
                Text = "Tax:",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            txtTax = new Entry
            {
                Placeholder = "Enter Tax Rate",
                FontSize = 20,
                Margin = new Thickness(10),
                BackgroundColor = Colors.Transparent,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Numeric,
            };

            Grid.SetRow(txtTax, 2);
            Grid.SetColumn(txtTax, 1);
            Grid.SetColumnSpan(txtTax, 3);

            lblTip = new Label
            {
                Text = "Tip:",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            txtTip = new Entry
            {
                Placeholder = "Enter Tip Percentage",
                FontSize = 20,
                BackgroundColor = Colors.Transparent,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Numeric,
            };

            Grid.SetRow(txtTip, 3);
            Grid.SetColumn(txtTip, 1);
            Grid.SetColumnSpan(txtTip, 3);

            lblSplit = new Label
            {
                Text = "Split:",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            stpSplit = new Stepper
            {
                Minimum = 1,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            Grid.SetRow(stpSplit, 4);
            Grid.SetColumn(stpSplit, 1);
            Grid.SetColumnSpan(stpSplit, 2);

            stpSplit.ValueChanged += (sender, e) =>
            {
                lblSplitValue.Text = string.Format("{0}", e.NewValue);
            };

            lblSplitValue = new Label
            {
                Text = "1",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            btnCalculate = new Button
            {
                Text = "Calculate",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Green
            };

            Grid.SetRow(btnCalculate, 5);
            Grid.SetColumn(btnCalculate, 0);
            Grid.SetColumnSpan(btnCalculate, 2);

            btnCalculate.Clicked += btnCalculate_Clicked;

            btnClear = new Button
            {
                Text = "Clear",
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.DarkRed
            };

            Grid.SetRow(btnClear, 5);
            Grid.SetColumn(btnClear, 2);
            Grid.SetColumnSpan(btnClear, 2);

            btnClear.Clicked += BtnClear_Clicked;

            lblCost = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Grid.SetRow(lblCost, 6);
            Grid.SetColumn(lblCost, 0);
            Grid.SetColumnSpan(lblCost, 4);

            var grid = new Grid
            {
                ColumnDefinitions =
            {
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star), },
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star), },
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star), },
                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star), }
            },
                RowDefinitions =
            {
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), },
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star), }
            }
            };

            grid.Add(lblPrice, 0, 0);
            grid.Add(txtPrice);
            grid.Add(lblSale, 0, 1);
            grid.Add(txtSale);
            grid.Add(lblTax, 0, 2);
            grid.Add(txtTax);
            grid.Add(lblTip, 0, 3);
            grid.Add(txtTip);
            grid.Add(lblSplit, 0, 4);
            grid.Add(stpSplit);
            grid.Add(lblSplitValue, 3, 4);
            grid.Add(btnCalculate);
            grid.Add(btnClear);
            grid.Add(lblCost);

            Content = grid;
        }

        //calculates the cost
        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text == null)
                    lblCost.Text = "Enter the price";
                else
                {
                    price = Convert.ToDouble(txtPrice.Text);
                    sale = Convert.ToDouble(txtSale.Text);
                    tax = Convert.ToDouble(txtTax.Text);
                    tip = Convert.ToDouble(txtTip.Text);
                    split = Convert.ToDouble(lblSplitValue.Text);

                    txtPrice.Text = string.Format("{0:0.00}", price);

                    cost = price - ((price * sale) / 100);
                    cost = cost + ((cost * tax) / 100);
                    cost = cost + ((cost * tip) / 100);
                    cost = cost / split;

                    lblCost.Text = "Cost per person: " + cost.ToString("c");
                }
            }
            catch
            {
                lblCost.Text = "Enter the price";
            }
        }

        //clears the entry values and lblCost
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            txtPrice.Text = "";
            txtSale.Text = "";
            txtTax.Text = "";
            txtTip.Text = "";
            lblCost.Text = "";
            lblSplitValue.Text = "1";
        }
    }
}