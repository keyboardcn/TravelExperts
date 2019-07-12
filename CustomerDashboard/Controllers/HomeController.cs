using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomerDashboard.Controllers
{
    public class HomeController : Controller
    {
        private TravelExpertsEntities db = new TravelExpertsEntities();
        private TravelExpertsBookings bk = new TravelExpertsBookings();
        private TravelExpertsBookingDetails bd = new TravelExpertsBookingDetails();
       
       

        public ActionResult Index()
        {
            return View();
     
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Bookings1()
        {

            int custId = Convert.ToInt32(Session["ID"]);

            var cust = bk.Bookings.Where(a => a.CustomerId == custId);

            //List<Booking> bkg = bk.Bookings.Where(a => a.CustomerId.Equals(custId)).ToList();
            List<Booking> bkg = cust.ToList();

            return View(bkg);
        }



        public ActionResult BookingDetails(string id)
        {
            int bId = Convert.ToInt32(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var BookingDetails = bd.BookingDetails.Where(b => b.BookingId == bId).FirstOrDefault();
            if (BookingDetails == null)
            {
                return HttpNotFound();
            }
            return View(BookingDetails);


        }


        public ActionResult Customers()
        {
            List<Customer> cust = db.Customers.ToList();

            return View(cust);
        }

        public ActionResult Login()
        {
            if(Session["ID"]!=null)
            {
                Session["ID"] = null;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer c)
        {
            var cust = db.Customers.Where(a => a.CustomerId == c.CustomerId && a.CustPassword.Equals(c.CustPassword)).FirstOrDefault();
            if (cust != null)
            {
                //Session["fName"] = cust.CustFirstName.ToString();
                //Session["lName"] = cust.CustLastName.ToString();
                System.Web.HttpContext.Current.Session["Id"] = cust.CustomerId.ToString();
                return RedirectToAction("UserDashBoard");
            }
            return View(c);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
                var cust = db.Customers.Find(id);
                return View(cust);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    

    public ActionResult Details()
        {
            //Session["ID"] = "105";
            int id = Convert.ToInt32(Session["ID"]);
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Customer customerToView = db.Customers.Find(id);
            Customer customerToView = db.Customers.Find(id);
            if (customerToView == null)
            {
                return HttpNotFound();
            }
            return View(customerToView);
        }


        // GET: Customer/Register
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Register
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // perform INSERT
                    db.Customers.Add(c);
                   
                    db.SaveChanges();

                    Customer newCust = db.Customers.ToList().Last();

                    Session["ID"] = newCust.CustomerId.ToString();
                    // after successfull insert display Customer page
                    return RedirectToAction("UserDashBoard");
                    //return View(c);
                }
                catch
                {
                    return RedirectToAction("Create"); // stay on the same page
                }
            }
            else
            {
                return View(); // stay on the same page
            }

        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customerToEdit = db.Customers.Find(id);
            if (customerToEdit == null)
            {
                return HttpNotFound();
            }
            return View(customerToEdit);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    Customer customerToEdit = db.Customers.Find(id);

                    if (TryUpdateModel(customerToEdit, "",
                        new string[] { "CustFirstName", "CustLastName", "CustAddress", "CustCity", "CustProv",
                            "CustPostal", "CustCountry", "CustHomePhone", "CustBusPhone", "CustEmail" }))
                    {
                        // perform UPDATE
                        db.SaveChanges();
                        return RedirectToAction("UserDashBoard");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }

        }

    }
}