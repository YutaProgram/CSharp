using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpConsoleApp
{
    internal class MyHttpClient
    {
        //アクセス修飾子がprotectedのstatic変数に生成したインスタンスを保存する
        protected static HttpClient client;

        public MyHttpClient() 
        {
            //初期化処理
            client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string URL)
        {
            var res = await client.GetAsync(URL);
            return res;
        }
    
        public async Task<HttpResponseMessage> PostAsync(string URL,HttpContent content)
        {
            var res = await client.PostAsync(URL,content);
            return res;
        }

        // プロパティとして公開する場合
        //public static HttpClient Client
        //{ 
        //    get
        //    {
        //        if (_httpClient == null)
        //        {
        //            _httpClient = new HttpClient();
        //        }
        //        return _httpClient;
        //    } 
        //}
    }
}
