using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JSONSampleConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ramen型のListを作成
            List<Ramen> ramen = new List<Ramen>();
            ramen.Add(new Ramen { Name = "Ramen", Price = 500});
            ramen.Add(new Ramen { Name = "Miso Ramen", Price = 600});
            ramen.Add(new Ramen { Name = "Ramen", Price = 500, Tuika = new List<string> { "Ajitama", "Negi" } });
            ramen.Add(new Ramen { Name = "Ramen", Price = 500, Info = new Ramen_Info { Men = "Futomen", Soup = "Tonkotsu" } });

            //ListをJSON形式にシリアライズ データ→JSON
            string jsonStr = JsonSerializer.Serialize(ramen);
            Console.WriteLine("シリアライズ結果");
            Console.WriteLine(jsonStr);
            Console.WriteLine();

            //JSONをRamen型のListにデシリアライズ JSON→データ
            List<Ramen> ramenData = JsonSerializer.Deserialize<List<Ramen>>(jsonStr);

            //Listの中身を表示
            Console.WriteLine("デシリアライズ結果");
            foreach(Ramen ramen1 in ramenData)
            {
                Console.WriteLine("Name: "+ramen1.Name);
                Console.WriteLine("Price: " + ramen1.Price);
                Console.WriteLine("Tuika:" + ramen1.Tuika);
                Console.WriteLine("Info:" + ramen1.Info);
                Console.WriteLine();
            }

            Console.WriteLine("\nENTERで終了");
            Console.ReadLine();
        }
    }
}
