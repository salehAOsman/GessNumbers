using GessNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GessNumber.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //"bool reset=false" if user pass this value as true then we will get new random num 
        //If we need to use more than one parameter then we need this char "&" like this "?reset=true&parameter=1133" and we put new input in get method
        // we can give default value if we need to 
        public ActionResult GessingGame(bool reset=false/*,int parameter*/)
        {
            //if value null first time when we visit page 
            //we use this as input reset==true to check
            if (Session["randomNumber"]==null||reset==true)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                Session["randomNumber"] = rand.Next(1, 101);//to reach the max you have to write max+1 
                //we add this if reset=true then redirect to "GessingGame"
                // in this set may be the user hit this button reset then we have to redirect to this method again to have new random num
                if (reset)
                {
                    return RedirectToAction("GessingGame");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult GessingGame(int guess=0)
        {
            ViewBag.found = false;

            int randomNumberFromSession = int.Parse(Session["randomNumber"].ToString());

            GuessingNumber gessingList = new GuessingNumber();
            gessingList.Id++;
            gessingList.GuessingNum = guess;

            if (guess>randomNumberFromSession)
            {
                ViewBag.message = "too high, try again with lower num";
                gessingList.Description = "Try down";
               // gessingList.Guess.Add(gessingList);
            }
            else if(guess < randomNumberFromSession)
            {
                ViewBag.message = "too low, try again with higher num";
                gessingList.Description = "Try height";
              //  gessingList.Guess.Add(gessingList);
            }
            else
            {
                ViewBag.message = "Congratulations,\n you won please reset to start new game againg!";
                gessingList.Description = "you won";

                ViewBag.found = true;
            }
               // gessingList.Guess.Add(gessingList);

            return View(gessingList);
        }
    }
}