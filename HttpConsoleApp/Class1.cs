using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HttpConsoleApp
{
    internal class Class1
    {
        //httpクライアントをメソッド実行のたびに作成するのは非推奨
        //インスタンス生成時に作成して使いまわしていく。
        private static HttpClient client;

       public Class1()
       {
            //httpクライアント作成
            client = new HttpClient();
       }

       public async void Test()
       {
            //GETメソッドを利用する場合
            var result = await client.GetAsync(@"https://umayadia-apisample.azurewebsites.net/api/persons");

            var json = await result.Content.ReadAsStringAsync();
            Console.WriteLine($"{(int)result.StatusCode} {result.StatusCode}");
            Console.WriteLine(json);
       }


        public async void Test2()
        {
            //POSTメソッドを利用する場合

            //ボディの設定
            var param = new Dictionary<string, object>()
            {
                ["name"] = "山本雄大",
                ["note"] = "兵庫県出身",
                ["age"] = 23,
                ["registerDate"] = "1999-07-30",
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
