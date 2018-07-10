using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Dz3zad1.Models;

namespace Dz3zad1.Controllers
{
    public class HomeController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            Shov_items();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ModelUser modelUser)
        {
            if (ModelState.IsValid)
            {
                User user=new User(modelUser.FirstName,modelUser.LastName,modelUser.Login,modelUser.Passvord,modelUser.Email,modelUser.Phone);
                var find_rol = singelton.GetRoles().Find(Role => Role.Id == Convert.ToInt32(modelUser.role));
                user.Add_Rol(find_rol);
                singelton.AddUsers(user);
                ViewBag.listUser = singelton.GetUsers();
                return RedirectToAction("ShowTable");
            }
            else
            {
                Shov_items();
                return View("Index");
            }
            
        }

        private void Shov_items()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (Role VARIABLE in singelton.GetRoles())
            {
                item.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
            }

            ViewBag.Item = item;
        }
        
        public ActionResult ShowTable()
        {
            ViewBag.listUser = singelton.GetUsers();
            return View();
        }

        
        public ActionResult Edit(int id)
        {
            
            var Fin_user = singelton.GetUsers().Find(User => User.Id == id);
            ViewBag.user = Fin_user;
            return View();
        }
        [HttpGet]
        public ActionResult Rename(int id)
        {
            
            var Fin_user = singelton.GetUsers().Find(User => User.Id == id);
            ViewBag.user = Fin_user;
            Show_itemSelected(Fin_user);
            return View();
        }

        [HttpPost]
        public ActionResult Rename(ModelUser user,int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Fin_User = singelton.GetUsers().Find(User => User.Id == id);
                    Fin_User.Renam_User(user.FirstName,user.LastName,user.Login,user.Passvord,user.Email,user.Phone);
                    var find_rol = singelton.GetRoles().Find(Role => Role.Id == Convert.ToInt32(user.role));
                    Fin_User.Add_Rol(find_rol);
                    ViewBag.listUser = singelton.GetUsers();
                    return RedirectToAction("ShowTable");
                }
                else
                {
                    var Fin_user = singelton.GetUsers().Find(User => User.Id == id);
                    ViewBag.user = Fin_user;
                    Show_itemSelected(Fin_user);
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Exseption = e.Message;
                return View("~/Views/Error.cshtml");
            }
            
        }

        private void Show_itemSelected(User user)
        {
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (Role VARIABLE in singelton.GetRoles())
            {
                if (user!=null)
                {
                    if (user.Role!=null)
                    {
                        if (user.Role.Name.Equals(VARIABLE.Name))
                        {
                            item.Add(new SelectListItem {Selected = true,Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                        }
                        else
                        {
                            item.Add(new SelectListItem { Selected = false, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                        }
                    }
                    else
                    {
                        item.Add(new SelectListItem { Selected = false, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                    }
                }
                else
                {
                    item.Add(new SelectListItem { Selected = false, Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                }
            }

            ViewBag.Item = item;
        }

        public ActionResult DeleteUser(int id)
        {
            var Fin_user = singelton.GetUsers().Find(User => User.Id == id);
            singelton.GetUsers().Remove(Fin_user);
            ViewBag.listUser = singelton.GetUsers();
            return View("ShowTable");
        }
    }
}