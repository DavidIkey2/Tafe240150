using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		const float US_TO_EURO = 0.85189982f;
		const float US_TO_BRITISH = 0.72872436f;
		const float US_TO_INDIAN = 74.257327f;
		const float EURO_TO_US = 1.1739732f;
		const float EURO_TO_BRITISH = 0.8556672f;
		const float EURO_TO_INDIAN = 87.00755f;
		const float BRITISH_TO_US = 1.371907f;
		const float BRITISH_TO_EURO = 1.1686692f;
		const float BRITISH_TO_INDIAN = 101.68635f;
		const float INDIAN_TO_US = 0.011492628f;
		const float INDIAN_TO_EURO = 0.013492774f;
		const float INDIAN_TO_BRITISH = 0.0098339397f;
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}

		private async void currencyConversionButton_Click(object sender, RoutedEventArgs e)
		{
			float amount = 1;
			float convertedAmount = 1;
			float rate = 1;
			string from = "";
			string to = "";
			try
			{
				amount = float.Parse(amountTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a valid amount.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			if (convertFromComboBox.SelectedIndex == 0 && convertToComboBox.SelectedIndex == 0)
			{
				rate = 1;
				convertedAmount = amount * rate;
				from = "US Dollars";
				to = "US Dollars";
			}
			else if (convertFromComboBox.SelectedIndex == 0 && convertToComboBox.SelectedIndex == 1)
			{
				rate = US_TO_EURO;
				convertedAmount = amount * rate;
				from = "US Dollars";
				to = "Euro";
			}
			else if (convertFromComboBox.SelectedIndex == 0 && convertToComboBox.SelectedIndex == 2)
			{
				rate = US_TO_BRITISH;
				convertedAmount = amount * rate;
				from = "US Dollars";
				to = "British Pounds";
			}
			else if (convertFromComboBox.SelectedIndex == 0 && convertToComboBox.SelectedIndex == 3)
			{
				rate = US_TO_INDIAN;
				convertedAmount = amount * rate;
				from = "US Dollars";
				to = "Indian Rupee";
			}
			else if (convertFromComboBox.SelectedIndex == 1 && convertToComboBox.SelectedIndex == 0)
			{
				rate = EURO_TO_US;
				convertedAmount = amount * rate;
				from = "Euro";
				to = "US Dollars";
			}
			else if (convertFromComboBox.SelectedIndex == 1 && convertToComboBox.SelectedIndex == 1)
			{
				rate = 1;
				convertedAmount = amount * rate;
				from = "Euro";
				to = "Euro";
			}
			else if (convertFromComboBox.SelectedIndex == 1 && convertToComboBox.SelectedIndex == 2)
			{
				rate = EURO_TO_BRITISH;
				convertedAmount = amount * rate;
				from = "Euro";
				to = "British Pounds";
			}
			else if (convertFromComboBox.SelectedIndex == 1 && convertToComboBox.SelectedIndex == 3)
			{
				rate = EURO_TO_INDIAN;
				convertedAmount = amount * rate;
				from = "Euro";
				to = "Indian Rupee";
			}
			else if (convertFromComboBox.SelectedIndex == 2 && convertToComboBox.SelectedIndex == 0)
			{
				rate = BRITISH_TO_US;
				convertedAmount = amount * rate;
				from = "British Pounds";
				to = "US Dollars";
			}
			else if (convertFromComboBox.SelectedIndex == 2 && convertToComboBox.SelectedIndex == 1)
			{
				rate = BRITISH_TO_EURO;
				convertedAmount = amount * rate;
				from = "British Pounds";
				to = "Euro";
			}
			else if (convertFromComboBox.SelectedIndex == 2 && convertToComboBox.SelectedIndex == 2)
			{
				rate = 1;
				convertedAmount = amount * rate;
				from = "British Pounds";
				to = "British Pounds";
			}
			else if (convertFromComboBox.SelectedIndex == 2 && convertToComboBox.SelectedIndex == 3)
			{
				rate = BRITISH_TO_INDIAN;
				convertedAmount = amount * rate;
				from = "British Pounds";
				to = "Indian Rupee";
			}
			else if (convertFromComboBox.SelectedIndex == 3 && convertToComboBox.SelectedIndex == 0)
			{
				rate = INDIAN_TO_US;
				convertedAmount = amount * rate;
				from = "Indian Rupee";
				to = "US Dollars";
			}
			else if (convertFromComboBox.SelectedIndex == 3 && convertToComboBox.SelectedIndex == 1)
			{
				rate = INDIAN_TO_EURO;
				convertedAmount = amount * rate;
				from = "Indian Rupee";
				to = "Euro";
			}
			else if (convertFromComboBox.SelectedIndex == 3 && convertToComboBox.SelectedIndex == 2)
			{
				rate = INDIAN_TO_BRITISH;
				convertedAmount = amount * rate;
				from = "Indian Rupee";
				to = "British Pounds";
			}
			else if (convertFromComboBox.SelectedIndex == 3 && convertToComboBox.SelectedIndex == 3)
			{
				rate = 1;
				convertedAmount = amount * rate;
				from = "Indian Rupee";
				to = "Indian Rupee";
			}			
			amountTextBlock.Text = $"{amount} {from} =";
			convertedAmountTextBlock.Text = $"{convertedAmount} {to}";
			fromRateTextBlock.Text = $"1 {from} = {rate} {to}"; 
			toRateTextBlock.Text = $"1 {to} = {1/rate} {from}";
		}
	}
}
