using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;

namespace Dafabet
{
    public class Tests
    {
        public static string baseUrl= " https://showcase.api.linx.twenty57.net";
        
        public static RestRequest restRequest;
        public static RestClient restClient;
        public static RestResponse restResponse;
        public static string path= "/UnixTime/fromunixtimestamp";
       
        [OneTimeSetUp]
        public void Setup1()
        {

            RestClientOptions options = new RestClientOptions(baseUrl)
            {

            };
            restClient = new RestClient(options);
        }





        [SetUp]
        public void Setup()
        {
           
        }

        [Test, Category("Dafabet"), Order(1), Author("Niranjan")]
        [Description("Valid Case")]
        public void Test1()
        {
            try
            {
               // restClient.AddDefaultQueryParameter("unixtimestamp", "1549892280");
                restRequest = new RestRequest(path, Method.Get);
                restRequest.AddParameter("unixtimestamp", "1549892280");
                restResponse = restClient.Execute(restRequest);
                Assert.AreEqual(200, (int)restResponse.StatusCode);
                var value = JObject.Parse(restResponse.Content);
                var resdatetime = value["Datetime"].ToString();
                var actudatetime = "2019-02-11 13:38:00";
                Assert.AreEqual(resdatetime, actudatetime);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        [Test, Category("Dafabet"), Order(2), Author("Niranjan")]
        [Description("Negative Value")]
        public void Test2()
        {
            try
            {
                restRequest = new RestRequest(path, Method.Get);
                restRequest.AddParameter("unixtimestamp", "-1549892280");
                restResponse = restClient.Execute(restRequest);
                Assert.AreEqual(200, (int)restResponse.StatusCode);
                var value = JObject.Parse(restResponse.Content);
                var status = value["Datetime"];
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Test, Category("Dafabet"), Order(3), Author("Niranjan")]
        [Description("Exceding Int Range")]
        public void Test3()
        {
            try
            {
                restRequest = new RestRequest(path, Method.Get);
                restRequest.AddParameter("unixtimestamp", "2147483649");
                restResponse = restClient.Execute(restRequest);
                Assert.AreEqual(400, (int)restResponse.StatusCode);
                var value = JObject.Parse(restResponse.Content);
                var status = value["Error"];


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Test, Category("Dafabet"), Order(4), Author("Niranjan")]
        [Description("With Alphabets")]
        public void Test4()
        {
            try
            {
                restRequest = new RestRequest(path, Method.Get);
                restRequest.AddParameter("unixtimestamp", "NI1549892280");
                restResponse = restClient.Execute(restRequest);
                Assert.AreEqual(400, (int)restResponse.StatusCode);
                var value = JObject.Parse(restResponse.Content);
                var status = value["Error"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Test, Category("Dafabet"), Order(5), Author("Niranjan")]
        [Description("Null Check")]
        public void Test5()
        {
            try
            {
                restRequest = new RestRequest(path, Method.Get);
                restRequest.AddParameter("unixtimestamp", " ");
                restResponse = restClient.Execute(restRequest);
                Assert.AreEqual(400, (int)restResponse.StatusCode);
                var value = JObject.Parse(restResponse.Content);
                var status = value["Error"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Test, Category("Dafabet"), Order(6), Author("Niranjan")]
        [Description("No Parameters ")]
        public void Test6()
        {
            try
            {
                restRequest = new RestRequest(path, Method.Get);
              //  restRequest.AddParameter("unixtimestamp", " ");
                restResponse = restClient.Execute(restRequest);
                Assert.AreEqual(400, (int)restResponse.StatusCode);
                var value = JObject.Parse(restResponse.Content);
                var status = value["Error"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}