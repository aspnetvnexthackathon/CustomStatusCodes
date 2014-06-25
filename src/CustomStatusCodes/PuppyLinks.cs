using System;
using System.Collections.Generic;

namespace CustomStatusCodes
{
    public class PuppyLinks
    {
        public static IDictionary<int, string> Create()
        {
            // Courtesy of http://httpstatusdogs.com/
            IDictionary<int, string> links = new Dictionary<int, string>();
            links.Add(100, "http://httpstatusdogs.com/wp-content/uploads/100.jpg");
            links.Add(200, "http://httpstatusdogs.com/wp-content/uploads/200.jpg");
            links.Add(201, "http://httpstatusdogs.com/wp-content/uploads/201.jpg");
            links.Add(202, "http://httpstatusdogs.com/wp-content/uploads/202.jpg");
            links.Add(203, "http://httpstatusdogs.com/wp-content/uploads/203.jpg");
            links.Add(204, "http://httpstatusdogs.com/wp-content/uploads/204.jpg");
            links.Add(206, "http://httpstatusdogs.com/wp-content/uploads/206.jpg");
            links.Add(207, "http://httpstatusdogs.com/wp-content/uploads/207.jpg");
            links.Add(208, "http://httpstatusdogs.com/wp-content/uploads/208.jpg");
            links.Add(226, "http://httpstatusdogs.com/wp-content/uploads/226.jpg");
            links.Add(300, "http://httpstatusdogs.com/wp-content/uploads/300.jpg");
            links.Add(301, "http://httpstatusdogs.com/wp-content/uploads/301.jpg");
            links.Add(302, "http://httpstatusdogs.com/wp-content/uploads/302.jpg");
            links.Add(303, "http://httpstatusdogs.com/wp-content/uploads/303.jpg");
            links.Add(304, "http://httpstatusdogs.com/wp-content/uploads/304.jpg");
            links.Add(305, "http://httpstatusdogs.com/wp-content/uploads/305.jpg");
            links.Add(306, "http://httpstatusdogs.com/wp-content/uploads/306.jpg");
            links.Add(307, "http://httpstatusdogs.com/wp-content/uploads/307.jpg");
            links.Add(308, "http://httpstatusdogs.com/wp-content/uploads/308.jpg");
            links.Add(400, "http://httpstatusdogs.com/wp-content/uploads/400.jpg");
            links.Add(401, "http://httpstatusdogs.com/wp-content/uploads/401.jpg");
            links.Add(402, "http://httpstatusdogs.com/wp-content/uploads/402.jpg");
            links.Add(403, "http://httpstatusdogs.com/wp-content/uploads/403.jpg");
            links.Add(404, "http://httpstatusdogs.com/wp-content/uploads/2011/12/404.jpg");
            links.Add(405, "http://httpstatusdogs.com/wp-content/uploads/405.jpg");
            links.Add(406, "http://httpstatusdogs.com/wp-content/uploads/406.jpg");
            links.Add(407, "http://httpstatusdogs.com/wp-content/uploads/407.jpg");
            links.Add(408, "http://httpstatusdogs.com/wp-content/uploads/408.jpg");
            links.Add(409, "http://httpstatusdogs.com/wp-content/uploads/409.jpg");
            links.Add(410, "http://httpstatusdogs.com/wp-content/uploads/410.jpg");
            links.Add(411, "http://httpstatusdogs.com/wp-content/uploads/411.jpg");
            links.Add(412, "http://httpstatusdogs.com/wp-content/uploads/412.jpg");
            links.Add(500, "http://httpstatusdogs.com/wp-content/uploads/500.jpg");
            return links;
        }
    }
}