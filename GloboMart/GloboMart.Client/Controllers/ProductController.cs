using GloboMart.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GloboMart.Client.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
       HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:49874/api/ProductAPI";
         
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public ProductController()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }
 
        // GET: Product
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
               var responseData =   responseMessage.Content.ReadAsStringAsync().Result ;
 
               var Products = JsonConvert.DeserializeObject<List<Product>>(responseData); 
 
                 return View(Products);
            }
            return View("Error");
        }


 
        public ActionResult Create()
        {
            return View(new Product());
        }
 
        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Product Prod)
        {
 
           HttpResponseMessage responseMessage =  await client.PostAsJsonAsync(url,Prod);
           if (responseMessage.IsSuccessStatusCode)
           {
               return   RedirectToAction("Index");
           }
           return RedirectToAction("Error");
        }
 
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url+"/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
 
                var Employee = JsonConvert.DeserializeObject<Product>(responseData);
 
                return View(Employee);
            }
            return View("Error");
        }
 
        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id,Product Prod)
        {
 
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url+"/" +id, Prod);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
 
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
 
                var Employee = JsonConvert.DeserializeObject<Product>(responseData);
 
                return View(Employee);
            }
            return View("Error");
        }
 
        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Product Prod)
        {
 
            HttpResponseMessage responseMessage =await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }

	
}