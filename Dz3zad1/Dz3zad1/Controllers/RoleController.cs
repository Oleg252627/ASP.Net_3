using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz3zad1.Models;

namespace Dz3zad1.Controllers
{
    public class RoleController : Controller
    {
        private Singelton singelton = Singelton.Instens;

        //private string menu = @"<div class=""menu"">
        //<a href = ""~/Views/Home/Index.cshtml"" > Добавить пользователя</a>
        //<a href = ""~/Views/Home/ShowTable.cshtml"" > Таблица пользователей</a>
        //<a href = ""~/Views/Role/Index.cshtml"" > Добавить роль</a>
        //<a href = ""~/Views/Role/TableRole.cshtml"" > Таблица ролей</a>
        //</div>";
        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(ModelRole role)
        {
            if (ModelState.IsValid)
            {
                Role rol=new Role(role.Name);
                singelton.AddRoles(rol);
                ViewBag.Roles = singelton.GetRoles();
                
                return RedirectToAction("TableRole");
            }
            else
            {
               
                return View("Index");
            }
        }
        public ActionResult TableRole()
        {
            ViewBag.Roles = singelton.GetRoles();
            return View();
        }
        [HttpGet]
        public ActionResult RenameRole(int id)
        {
            var Fin_role = singelton.GetRoles().Find(Role => Role.Id == id);
            ViewBag.Role = Fin_role;
            return View();
        }

        [HttpPost]
        public ActionResult RenameRole(ModelRole Rol, int id)
        {
            if (ModelState.IsValid)
            {
                var Fin_role = singelton.GetRoles().Find(Role => Role.Id == id);
                Fin_role.Renem_Role(Rol.Name);
                ViewBag.Roles = singelton.GetRoles();
                return RedirectToAction("TableRole");
            }
            else
            {
                var Fin_role = singelton.GetRoles().Find(Role => Role.Id == id);
                ViewBag.Role = Fin_role;
                return View("RenameRole");
            }
        }

        public ActionResult DeleteRole(int id)
        {
            var Fin_role = singelton.GetRoles().Find(Role => Role.Id == id);
            singelton.GetRoles().Remove(Fin_role);
            ViewBag.Roles = singelton.GetRoles();
            return View("TableRole");
        }

    }
    
}