using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreePark.Data;
using FreePark.Models;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace FreePark.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarDetails
        public async Task<IActionResult> Index()
        {
            // Sign up at https://vindecoder.eu/register and request API keys
            // See API documentation at https://vindecoder.eu/my/api/3.1/docs

            WebClient proxy = new WebClient();
            string api = "https://api.vindecoder.eu/3.2";
            string apikey = "d8c45794c8f8";
            string secretkey = "aaddd1480c";
            string vin = "1GNEK13ZX3R298984";//"19XFA1F51BE026858";
            string id = "decode";

            // Implementation of the abstract class SHA1.
            SHA1 sha = new SHA1CryptoServiceProvider();
            string hash;

            string textToSha = string.Concat(vin, "|", id, "|", apikey, "|", secretkey);

            SHA1Managed sha1 = new SHA1Managed();
            String controlCheckComputed = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(textToSha))).Replace("-", "").Substring(0, 10);

            string serviceUrl = string.Format(api + "/" + apikey + "/" + controlCheckComputed + "/" + "decode" + "/" + vin + ".json");

            byte[] _data = proxy.DownloadData(serviceUrl);
            Stream _mem = new MemoryStream(_data);
            var reader = new StreamReader(_mem);
            var result = reader.ReadToEnd();

            Console.WriteLine(result);


            Root rootResponse = JsonConvert.DeserializeObject<Root>(result);//response.Content will print the while json of instructions.
            Decode decodeResponse = rootResponse.decode[0];
            List<Decode> decodeList = rootResponse.decode;
            if(decodeList.Count >= 5)
            {
                List<Decode> decodeListSliced = decodeList.Take(5).ToList();
                ViewBag.decodeList = decodeListSliced;
                return View();
            }

            ViewBag.decodeList = decodeList;
            return View();

        }
    }
}
       
    

