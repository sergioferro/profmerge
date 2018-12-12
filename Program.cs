using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace profmerge{
    public class Bio {
        public Person person { get; set; }
    }
    public class Person{
        public String id { get; set; }
        public String name { get; set; }
        public String professionalHeadline { get; set; }
    }
    
    class Principal{
        public static void Main(String[] args){
            var client = new RestClient();
            client.BaseUrl = new Uri("https://torre.bio");
            //client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest();
            request.Resource = "api/bios/rhfsalaman";

            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            Bio bio = JsonConvert.DeserializeObject<Bio>(response.Content);
            Console.WriteLine(bio.person.id);
            Console.WriteLine(bio.person.name);
            Console.WriteLine(bio.person.professionalHeadline);
        }
    }
}