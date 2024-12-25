using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokenGenerate.EF.Tables;
using TokenGenerate.EF;

namespace TokenGenerate.Controllers
{
    public class TokenController : Controller
    {
        private TokenContext db = new TokenContext();

        // Display all tokens
        public ActionResult Index()
        {
            var tokens = db.Tokens.ToList();
            return View(tokens);
        }

        // Generate token form
        [HttpGet]
        public ActionResult Generate()
        {
            return View();
        }

        // Generate a new token
        [HttpPost]
        public ActionResult Generate(string visaType)
        {
            if (string.IsNullOrEmpty(visaType))
            {
                ViewBag.Error = "Visa type is required.";
                return View();
            }

            string prefix = "";
            switch (visaType.ToUpper())
            {
                case "MEDICAL":
                    prefix = "MED-2";
                    break;
                case "TOURIST":
                    prefix = "TR-1";
                    break;
                case "BUSINESS":
                    prefix = "BS-3";
                    break;
                case "GO":
                    prefix = "GO-4";
                    break;
                default:
                    ViewBag.Error = "Invalid visa type.";
                    return View();
            }

            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            int tokenCount = db.Tokens.Count(t =>
                t.VisaType == visaType &&
                t.GeneratedDate >= today &&
                t.GeneratedDate < tomorrow);


            if (tokenCount >= 25)
            {
                ViewBag.Error = $"{visaType} tokens are at the maximum limit for today.";
                return View();
            }

            string tokenNumber = $"{prefix}-{tokenCount + 1}-{DateTime.Now:yyyyMMdd}";

            var newToken = new Token
            {
                TokenNumber = tokenNumber,
                VisaType = visaType,
                GeneratedDate = DateTime.Now
            };

            db.Tokens.Add(newToken);
            db.SaveChanges();

            ViewBag.Success = $"Generated Token: {tokenNumber}";
            return View();
        }
    }
}