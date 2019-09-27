using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData1 =
                @"[
                  {
                    'id': '5241585099662481339',
                    'displayName': 'Music',
                    'name': 'music',
                    'slug': 'music',
                    'imageUrl': 'http://kcdn3.klout.com/static/images/music-1333561300502.png'
                  },
                  {
                    'id': '6953585193220490118',
                    'displayName': 'Celebrities',
                    'name': 'celebrities',
                    'slug': 'celebrities',
                    'imageUrl': 'http://kcdn3.klout.com/static/images/topics/celebrities_b32741b6703151cc7bd85fba24c44c52.png'
                  },
                  {
                                'id': '5757029936226020304',
                    'displayName': 'Entertainment',
                    'name': 'entertainment',
                    'slug': 'entertainment',
                    'imageUrl': 'http://kcdn3.klout.com/static/images/topics/Entertainment_7002e5d2316e85a2ff004fafa017ff44.png'
                  },
                  {
                    'id': '3718',
                    'displayName': 'Saturday Night Live',
                    'name': 'saturday night live',
                    'slug': 'saturday-night-live',
                    'imageUrl': 'http://kcdn3.klout.com/static/images/icons/generic-topic.png'
                  },
                  {
                    'id': '8113008320053776960',
                    'displayName': 'Hollywood',
                    'name': 'hollywood',
                    'slug': 'hollywood',
                    'imageUrl': 'http://kcdn3.klout.com/static/images/topics/hollywood_9eccd1f7f83f067cb9aa2b491cd461f3.png'
                  }
                ]";

            //dynamic dynJson = JsonConvert.DeserializeObject(jsonData1);
            //foreach (var item in dynJson)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}\n", item.id, item.displayName,
            //        item.slug, item.imageUrl);
            //}


            string jsonData =
                @"[
                    {
                        'ID': '1',
                        'Name': 'Chevrolet'
                    },
                    {
                        'ID': '2',
                        'Name': 'Fiat'
                    },
                    {
                        'ID':'50',
                        'Name': 'Wolkswagen'
                    },
                    {
                        'ID':'51',
                        'Name': 'Ferrari'
                    }
                ]";

            /*DYNAMIC OBJECT*/
            dynamic dynJson = JsonConvert.DeserializeObject(jsonData);
            foreach (var item in dynJson)
            {
                Console.WriteLine("{0} {1}\n", item.id, item.Name);
            }


            /*DECLARED OBJECT*/
            //var list = JsonConvert.DeserializeObject<List<MyItem>>(jsonData);
            //foreach (var item in list)
            //{
            //    Console.WriteLine("{0} {1}\n", item.id, item.name);
            //}


        }

        public class MyItem
        {
            public string id;
            public string name;
        }


    }

}
