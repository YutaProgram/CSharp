using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HttpConsoleApp
{
    internal class Class1 : MyHttpClient
    {
        public Class1(){ }

       public async void GetTest()
       {
            //GETメソッドを利用する場合
            var result = await client.GetAsync(@"https://umayadia-apisample.azurewebsites.net/api/persons/");
            
            var json = await result.Content.ReadAsStringAsync();
            Console.WriteLine($"{(int)result.StatusCode} {result.StatusCode}");
            Console.WriteLine(json);
       }


        public async void PostTest()
        {
            //POSTメソッドを利用する場合

            //ボディの設定
            var param = new Dictionary<string, object>()
            {
                ["name"] = "Joan of Arc",
                ["note"] = "France",
                ["age"] = 19,
                ["registerDate"] = "1412/1/6",
            };

            //nugetからSystem.Text.jsonをインストールする必要あり
            //作ったオブジェクトをjson形式にシリアライズ
            var jsonString = System.Text.Json.JsonSerializer.Serialize(param);
            var content = new StringContent(jsonString, Encoding.UTF8, @"application/json");

            //POST
            var result = await client.PostAsync(@"https://umayadia-apisample.azurewebsites.net/api/persons", content);
            Console.WriteLine($"{(int)result.StatusCode}\n{result.StatusCode}");

            //GET
            var resultGet = await client.GetAsync(@"https://umayadia-apisample.azurewebsites.net/api/persons");
            var json = await resultGet.Content.ReadAsStringAsync();
            Console.WriteLine($"{(int)resultGet.StatusCode}\n{resultGet.StatusCode}");
            Console.WriteLine(json);
        }
    }
}
