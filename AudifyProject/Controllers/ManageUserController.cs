using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudifyProject.Data;
using AudifyProject.Models;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudifyProject.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public ManageUserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
        }
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateUser()
        {
            ViewData["RoleList"] = _roleManager.Roles;
           //ViewData["HeadDepartmentList"] = new SelectList(_context.HeadDepartments, "Id", "Name");
           // ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(ManagerRegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = register.UserName,
                   
                    //HeadDepartmentId = register.HeadDepartmentId
                };
              /*  if (register.Role == "Manager")
                {
                    user.TownshipId = register.TownshipId;
                    user.RegionId = register.RegionId;
                }
                else if (register.Role == "Region Manager")
                {
                    user.RegionId = register.RegionId;
                }*/

                var result = await _userManager.CreateAsync(user, register.Password);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                if (result.Succeeded)
                {
                    //_userManager.AddToRoleAsync(appUser, "User").Wait();
                    await _userManager.AddToRoleAsync(user, "Manager");
                    return RedirectToAction(nameof(Index));
                }

            }
            //ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Name");
           // ViewData["HeadDepartmentList"] = new SelectList(_context.HeadDepartments, "Id", "Name");
            return View();
        }
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> Index()
        {
            var userList = await _context.ApplicationUsers.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
           List<ApplicationUser> managerList = new List<ApplicationUser>();
            userList.ForEach(u =>
            {
                var urList = u.UserRoles.Where(r => r.Role.Name.Equals("Manager")).Select(u => u.User).ToList<ApplicationUser>();
                managerList.AddRange(urList);
            });
           
            return View(managerList);
        }
        public async Task<IActionResult> AppUserList()
        {
            var userList = await _context.ApplicationUsers.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
            List<ApplicationUser> managerList = new List<ApplicationUser>();
            userList.ForEach(u =>
            {
                var urList = u.UserRoles.Where(r => r.Role.Name.Equals("User")).Select(u => u.User).ToList<ApplicationUser>();
                managerList.AddRange(urList);
            });

            return View(managerList);
        }
        public async Task<IActionResult> ChangePassword(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            var changePasswordModel = new ChangePasswordViewModel()
            {
                UserId = appUser.Id,
                UserName = appUser.UserName,

            };
            return View(changePasswordModel);
        }
        public async Task<IActionResult> UserChangePassword(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            var changePasswordModel = new ChangePasswordViewModel()
            {
                UserId = appUser.Id,
                UserName = appUser.UserName,

            };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changeVM)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(changeVM.UserId);
                var result = await _userManager.RemovePasswordAsync(appUser);
                if (result.Succeeded)
                {
                    var changeResult = await _userManager.AddPasswordAsync(appUser, changeVM.Password);
                    if (changeResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(changeVM);
        }
        [HttpPost]
        public async Task<IActionResult> UserChangePassword(ChangePasswordViewModel changeVM)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(changeVM.UserId);
                var result = await _userManager.RemovePasswordAsync(appUser);
                if (result.Succeeded)
                {
                    var changeResult = await _userManager.AddPasswordAsync(appUser, changeVM.Password);
                    if (changeResult.Succeeded)
                    {
                        return RedirectToAction(nameof(AppUserList));
                    }
                }
            }
            return View(changeVM);
        }
    }
}

