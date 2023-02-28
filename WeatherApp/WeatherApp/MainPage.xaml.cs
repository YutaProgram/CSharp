using System.Text.Json;
using WeatherApp.Model;

namespace WeatherApp;

public partial class MainPage : ContentPage
{
    static readonly HttpClient client = new HttpClient();
    IDispatcherTimer timer;

    public MainPage()
    {
        InitializeComponent();
    }

    private async Task Update()
    {
        var jsonObj = await Task.Run<List<Class1>>(async () =>
        {
            HttpResponseMessage response = await client.GetAsync("https://www.jma.go.jp/bosai/forecast/data/forecast/270000.json");
            response.EnsureSuccessStatusCode();
            string reaponseBody = await response.Content.ReadAsStringAsync();

            var jsonObj = JsonSerializer.Deserialize<List<Class1>>(reaponseBody);

            return jsonObj;
        });

        var todayData = jsonObj[0].timeSeries[0].areas[0];

        //WeatherIcon.Text = todayData.weatherCodes[0];
        MaxTemp.Text = "最高 " + jsonObj[1].tempAverage.areas[0].max + "℃";
        MinTemp.Text = "最低 " + jsonObj[1].tempAverage.areas[0].min + "℃";
        Overall.Text = todayData.weathers[0];
        UpdateTime.Text = "最終更新:" + DateTime.Now.ToString();
        WeatherIcon.Source = @"https://www.jma.go.jp/bosai/forecast/img/" + todayData.weatherCodes[0] + ".png";
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await Update();

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromHours(1);
        timer.Tick += async (s, e) => await Update();
        timer.Start();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        HttpResponseMessage response = await client.GetAsync("http://f.st-hatena.com/images/fotolife/s/shirakamisauto/20160120/20160120232256.png");
        response.EnsureSuccessStatusCode();
        var _ss = await response.Content.ReadAsStringAsync();

        await Update();
        WeatherIcon.Source = @"https://www.jma.go.jp/bosai/forecast/img/100.png";
    }
}
