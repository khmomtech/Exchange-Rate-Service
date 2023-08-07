using System.Drawing;
using System.Text;
using System.Text.Json;

namespace ExchangeRateService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Fetch exchange rates and display notifications.
            await FetchExchangeRates();

            // Wait for 5 seconds before fetching the rates again.
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    private async Task FetchExchangeRates()
    {
        string apiKey = "..."; // write here your api key, or otherwise conact to me, to provide you my api key (nin.dautashvili@gmail.com)
        string apiEndPoint = $"https://api.currencyfreaks.com/v2.0/rates/latest?apikey={apiKey}";

        try
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiEndPoint);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var deserialize = JsonSerializer.Deserialize<ExchangeRate>(result);
                    var formattedRates = GetFormattedExchangeRates(deserialize.rates);
                    ShowNotification("Exchange Rates for USD", formattedRates);
                }
                else
                {
                    Console.WriteLine($"Failed to fetch exchange rates! Status code: {response.StatusCode}");
                }
            }
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // method which describes how to show the result
    private void ShowNotification(string title, string message)
    {
        Application.Run(new ExchangeRatesForm(title, message)); // call the custom form
    }

    // format rates to be presented as more readable for users
    private string GetFormattedExchangeRates(Rates rates)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var prop in typeof(Rates).GetProperties())
        {
            string currencyCode = prop.Name;
            string exchangeRate = prop.GetValue(rates)?.ToString();
            if (!string.IsNullOrEmpty(exchangeRate))
            {
                sb.AppendLine($"{currencyCode}: {exchangeRate}");
            }
        }
        return sb.ToString();
    }
}
