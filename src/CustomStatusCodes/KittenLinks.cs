using System;
using System.Collections.Generic;

namespace CustomStatusCodes
{
    public class KittenLinks
    {
        public static IDictionary<int, string> Create()
        {
            // Courtesy of http://www.flickr.com/photos/girliemac/sets/72157628409467125
            IDictionary<int, string> links = new Dictionary<int, string>();
            links.Add(100, "http://farm8.staticflickr.com/7162/6512768893_a821929823.jpg");
            links.Add(101, "http://farm8.staticflickr.com/7022/6540479029_730c095b63.jpg");

            links.Add(200, "http://farm8.staticflickr.com/7153/6512628175_6a4e8ab6ba.jpg");
            links.Add(201, "http://farm8.staticflickr.com/7149/6540221577_ed29955a01.jpg");
            links.Add(202, "http://farm8.staticflickr.com/7167/6540479079_16e97a624a.jpg");
            links.Add(204, "http://farm8.staticflickr.com/7154/6547319943_442c6509bb.jpg");
            links.Add(206, "http://farm8.staticflickr.com/7021/6514473163_4e2a681cbd.jpg");
            links.Add(207, "http://farm8.staticflickr.com/7141/6514472979_c44518c4ce.jpg");

            links.Add(300, "http://farm8.staticflickr.com/7019/6519540181_d4eae6ee7a.jpg");
            links.Add(301, "http://farm8.staticflickr.com/7022/6519540231_73756bac6c.jpg");
            links.Add(302, "http://farm8.staticflickr.com/7019/6508023829_3d44c4ac16.jpg");
            links.Add(303, "http://farm8.staticflickr.com/7007/6513125065_ef7cfa6256.jpg");
            links.Add(304, "http://farm8.staticflickr.com/7166/6540551929_eeee6bf3dd.jpg");
            links.Add(305, "http://farm8.staticflickr.com/7002/6540365403_01e93b44a3.jpg");
            links.Add(307, "http://farm8.staticflickr.com/7161/6513001269_edff1f0079.jpg");

            links.Add(400, "http://farm8.staticflickr.com/7022/6540669737_7527a5de13.jpg");
            links.Add(401, "http://farm8.staticflickr.com/7148/6508023065_8dae48a30b.jpg");
            links.Add(402, "http://farm8.staticflickr.com/7165/6513001321_8ecc400e0a.jpg");
            links.Add(403, "http://farm8.staticflickr.com/7173/6508023617_f3ffc34e17.jpg");
            links.Add(404, "http://farm8.staticflickr.com/7172/6508022985_b22200ced0.jpg");

            links.Add(500, "http://farm8.staticflickr.com/7001/6509400855_aaaf915871.jpg");
            return links;
        }
    }
}