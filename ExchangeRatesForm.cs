using System.Windows.Forms;

namespace ExchangeRateService
{
    public class ExchangeRatesForm : Form
    {
        public ExchangeRatesForm(string title, string message)
        {
            this.Text = title;

            TextBox textBoxExchangeRates = new TextBox();
            textBoxExchangeRates.Multiline = true;
            textBoxExchangeRates.ReadOnly = true;
            textBoxExchangeRates.ScrollBars = ScrollBars.Vertical;
            textBoxExchangeRates.Dock = DockStyle.Fill;
            textBoxExchangeRates.Text = message;

            this.Controls.Add(textBoxExchangeRates);
            Console.WriteLine("Notification displayed successfully.");
        }
    }
}
