﻿using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.SubNavbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/subnavbar")]
    public class SubNavbarController : Controller
    {

        private readonly DataContext _dataContext;


        public SubNavbarController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }


        [HttpGet("list", Name = "admin-subnavbar-list")]
        public async Task<IActionResult> List()
        {
            var model = await _dataContext.SubNavbars.Select(
                sn => new ListSubViewModel(sn.Id,sn.Title,sn.Url, sn.Order,sn.Navbar.Title)
                ).ToListAsync();
               
            return View("~/Views/Admin/SubNavbar/List.cshtml", model);
        }

        [HttpGet("add", Name = "admin-subnavbar-add")]
        public IActionResult Add()
        {
            var model = new SubAddViewModel
            {
                Navbar = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Title)).ToList()
            };
            
            return View("~/Views/Admin/SubNavbar/Add.cshtml", model);
        }
        [HttpPost("add", Name = "admin-subnavbar-add")]
        public IActionResult Add(SubAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = new SubAddViewModel
                {
                    Navbar = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Title)).ToList()
                };
                return View("~/Views/Admin/Subnavbar/Add.cshtml", model);
            }
            var newModel = new SubNavbar()
            {
                Title = model.Title,
                Url = model.Url,
                Order = model.Order,
                NavbarId = model.NavbarId,
            };
            _dataContext.SubNavbars.Add(newModel);
            _dataContext.SaveChanges();

            return RedirectToRoute("admin-subnavbar-list");
        }

        [HttpGet("update/{id}", Name = "admin-subnavbar-update")]
        public IActionResult Update([FromRoute] int id)
        {

            var subnavbar =  _dataContext.SubNavbars.FirstOrDefault(n => n.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }
            var model = new SubAddViewModel
            {
                Title = subnavbar.Title,
                Url=subnavbar.Url,
                Order=subnavbar.Order,
                NavbarId=subnavbar.NavbarId,
                Navbar = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Title)).ToList()
            };
            return View("~/Views/Admin/SubNavbar/Add.cshtml", model);
        }
        [HttpPost("update/{id}", Name = "admin-subnavbar-update")]
        public IActionResult Update(UpdateViewModel model)
        {

            if (!ModelState.IsValid)
            {

                model.Navbar = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Title)).ToList();
                return View("~/Views/Admin/Subnavbar/update.cshtml", model);
            }
            var subnavbar = _dataContext.SubNavbars.Include(n=> n.Navbar).FirstOrDefault(n => n.Id == model.Id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            subnavbar.Title=model.Title;
            subnavbar.Url=model.Url;
            subnavbar.Order=model.Order;
            subnavbar.NavbarId=model.NavbarId;

            _dataContext.SaveChanges();
            return RedirectToRoute("admin-subnavbar-list");

        }


        [HttpPost("delete/{id}", Name = "admin-subnavbar-delete")]
        public  IActionResult Delete([FromRoute] int id)
        {
            var model =  _dataContext.SubNavbars.FirstOrDefault(b => b.Id == id);
            if (model is null)
            {
                return NotFound();
            }

            _dataContext.SubNavbars.Remove(model);
            _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-subnavbar-list");
        }

    }
}
