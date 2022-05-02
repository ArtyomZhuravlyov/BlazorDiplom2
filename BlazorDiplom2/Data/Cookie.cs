using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace BlazorDiplom2.Data
{
    public class Cookie 
    {
        public string Key { get;set; }

        public string Value { get; set; }
        //[Inject]
        //public static IHttpContextAccessor HttpContextAccessor { get; set; }

        //public static CookieTest GetTestCookies()
        //{
        //    CookieTest cookiesTest;


        //    if (HttpContextAccessor.HttpContext.Request.Cookies.ContainsKey("TestK"))
        //    {
        //        string value = HttpContextAccessor.HttpContext.Request.Cookies["TestK"].ToString(); //Response.Cookies
        //        cookiesTest = JsonConvert.DeserializeObject<CookieTest>(value);
        //    }
        //    else
        //    {
        //        cookiesTest = new CookieTest();
        //        HttpContextAccessor.HttpContext.Response.Cookies.Append("TestK", JsonConvert.SerializeObject(cookiesTest));
        //    }
        //    return cookiesTest;

        //}

        public static CookieTest GetTestCookies(List<Cookie> cookies)
        {
            CookieTest cookiesTest;


            if (cookies.Select(x=>x.Key).Contains("TestK"))
            {
                string value = cookies.First(x=>x.Key.Equals("TestK")).Value; //Response.Cookies
                cookiesTest = JsonConvert.DeserializeObject<CookieTest>(value);
            }
            else
            {
                cookiesTest = new CookieTest();
                cookies.Add(new Cookie() { Key = "TestK" , Value = JsonConvert.SerializeObject(cookiesTest) });
            }
            return cookiesTest;

        }

    }
}
