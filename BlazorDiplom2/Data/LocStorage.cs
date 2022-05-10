using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace BlazorDiplom2.Data
{
    public class LocStorage 
    {
        //public static IRequestCookieCollection ReqCookies { get; set; }

        //public static IResponseCookies ResCookies { get; set; }

        //public static IHttpContextAccessor HttpContextAccessor { get; set; }
        //public string Key { get;set; }

        //public string Value { get; set; }

        //public static 
        //[Inject]
        //public static IHttpContextAccessor HttpContextAccessor { get; set; }


        //public static CookieTest GetTestCookies()
        //{
        //    CookieTest cookiesTest;


        //    if (ReqCookies.ContainsKey("TestK"))
        //    {
        //        string value = ReqCookies["TestK"].ToString(); //Response.Cookies
        //        cookiesTest = JsonConvert.DeserializeObject<CookieTest>(value);
        //    }
        //    else
        //    {
        //        cookiesTest = new CookieTest();
        //        ResCookies.Append("TestK", JsonConvert.SerializeObject(cookiesTest));
        //    }
        //    return cookiesTest;

        //}

        public static LocalStorage LocalStorage { get; set; }


        public static async Task<LocStorageTest> GetTestLocalStorageAsync(DB db, Student student)
        {
            try
            {
                LocStorageTest locStorageTest;
                var value = await LocalStorage.GetItemAsync(Constants.LOC_STOR);

                if (value != null)
                {
                    locStorageTest = JsonConvert.DeserializeObject<LocStorageTest>(value);
                    if (locStorageTest.MinutesTest != 0 && DateTime.Now.Subtract(locStorageTest.DateTimeStartTest).TotalMinutes > locStorageTest.MinutesTest)// время теста вышло и студент не завершил тест выйдя со страницы
                        locStorageTest.EndTestAsync(db);
                        

                }
                else
                {
                    locStorageTest = new LocStorageTest(student.Id);
                    await LocalStorage.SetItemAsync(Constants.LOC_STOR, JsonConvert.SerializeObject(locStorageTest));
                }
                return locStorageTest;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        //public static LocStorageTest GetTestCookies()
        //{
        //    try
        //    {
        //        LocStorageTest locStorageTest;

        //        if (HttpContextAccessor.HttpContext.Request.Cookies.ContainsKey("TestK"))
        //        {
        //            string value = HttpContextAccessor.HttpContext.Request.Cookies["TestK"].ToString(); //Response.Cookies
        //            LocStorageTest = JsonConvert.DeserializeObject<LocStorageTest>(value);
        //        }
        //        else
        //        {
        //            LocStorageTest = new LocStorageTest();
        //            HttpContextAccessor.HttpContext.Response.Cookies.Append("TestK", JsonConvert.SerializeObject(LocStorageTest));
        //        }
        //        return LocStorageTest;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }


        //}

        //public static CookieTest GetTestCookies(List<Cookie> cookies)
        //{
        //    CookieTest cookiesTest;


        //    if (cookies.Select(x => x.Key).Contains("TestK"))
        //    {
        //        string value = cookies.First(x => x.Key.Equals("TestK")).Value; //Response.Cookies
        //        cookiesTest = JsonConvert.DeserializeObject<CookieTest>(value);
        //    }
        //    else
        //    {
        //        cookiesTest = new CookieTest();
        //        cookies.Add(new Cookie() { Key = "TestK", Value = JsonConvert.SerializeObject(cookiesTest) });
        //    }
        //    return cookiesTest;

        //}

    }
}
