# Exchange Rate Service

Exchange Rate Service is a .NET Core Windows service application that periodically fetches exchange rates from the free API [Currency freaks](https://billing.currencyfreaks.com/) and displays them as a Windows notification popup form. **The service runs in the background**, fetching the latest exchange rates every 5 seconds and presenting them in a user-friendly format.

## How It Works

The Exchange Rate Service uses the `HttpClient` class to make a request to the API and fetch the latest exchange rates. The response is then deserialized into a custom `ExchangeRate` class using JSON serialization. The application runs as a background service, continuously fetching the rates and displaying them as notifications.

## Installation and Usage

### Prerequisites

- .NET Core SDK (version 3.1 or later) must be installed on your machine.

### Steps to Run the Service

1. Clone this repository or download the source code to your local machine.

2. Open a terminal or command prompt and navigate to the project's root directory.

3. Build the project:
```dotnet build```

4. Run the application:
```dotnet run```

The service will start running, fetching exchange rates from the API, and displaying them as Windows notifications.

## Configuration

The API endpoint and API key for the API can be configured in the `FetchExchangeRates` method of the `Worker` class. **Make sure to replace the `apiKey` variable with your own API key to access the API**(for that simple sign up on site: [Currency freaks](https://billing.currencyfreaks.com/) and you will have 1000 free request for 1 month).

## Customizing the Notification Popup

The notification popup window is created using a custom `ExchangeRatesForm` class. You can customize the appearance and layout of the notification popup by modifying the `ExchangeRatesForm` class in the code.

| :point_up:    | Important Notes! |
|---------------|:------------------------|

- The service is designed to run in the background and fetch exchange rates periodically. Make sure to keep the application running to receive continuous updates.

- The application is currently set to fetch exchange rates for **USD**.

## Disclaimer

This application is provided as-is and may be subject to rate limits or other restrictions imposed by the API. Ensure compliance with the API's terms of service and usage limitations.

## Support, Contact and Author
This "Exchange Rate Service" was created by [n1nni](https://github.com/n1nni). If you have any suggestions, feedback, issues or inquiries related to the app, please feel free to reach me out.

Contact Information:

:love_letter: - Email: [nin.dautashvili@gmail.com](mailto:nin.dautashvili@gmail.com)

:love_letter: - LinkedIn: [Nino Dautashvili](https://www.linkedin.com/in/nino-dautashvili/)


| :exclamation:  This is very important   |
|-----------------------------------------|
To use application you have to change in code apiKey and write your own Key. If you have problems with generated your ApiKey, reach me out and i can provide my own apiKey for testing the app. :blush:
---

**Happy currency monitoring!** 
:collision::collision:

