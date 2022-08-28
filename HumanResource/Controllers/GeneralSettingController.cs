using HumanResource.Data;
using HumanResource.Models;
using HumanResource.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Controllers
{
    [Authorize]
    public class GeneralSettingController : Controller
    {
        private readonly ApplicationDbContext context;
        public GeneralSettingController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Policy ="GeneralSettingShow")]
        public IActionResult Index()
        {
            var holidayes = context.Holidayes.Where(x => x.IsSelected == true).ToList();
            
            var extra = context.ExtraAndDiscounts.FirstOrDefault();
            
            GeneralSettingViewModel model = new GeneralSettingViewModel();
            model.ExtraAndDiscount = extra;
            model.Holidayes = holidayes;
            return View(model);
        }
        
        [HttpGet]
        [Authorize(Policy = "GeneralSettingAdd")]
        public IActionResult AddGeneralSetting()
        {
            List<string>Dayes = new List<string>();
            Dayes.Add("Saturday");
            Dayes.Add("Sunday");
            Dayes.Add("Monday");
            Dayes.Add("Tuesday");
            Dayes.Add("Wednesday");
            Dayes.Add("Thursday");
            Dayes.Add("Friday");
            List<Holidayes> model = new List<Holidayes>();
            for(int i=0; i<Dayes.Count; i++)
            {
                Holidayes holi = new Holidayes
                {
                    Name = Dayes[i],
                    IsSelected = false
                };
                model.Add(holi);
            }
            GeneralSettingViewModel Gene = new GeneralSettingViewModel
            {
                Holidayes = model
            };
            return View(Gene);
        }
        
        [HttpPost]
        [Authorize(Policy = "GeneralSettingAdd")]
        public async Task<IActionResult> AddGeneralSetting(GeneralSettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool flag = true;
                foreach(var item in model.Holidayes)
                {
                    if(item.IsSelected == true)
                    {
                        
                        flag = false;
                    }
                }
                if(flag == true)
                {
                    ModelState.AddModelError("", "You Shoud Select At Least One Day for holiday");
                    return View(model);
                }
                foreach(var item in model.Holidayes)
                {
                    context.Holidayes.Add(item);
                    await context.SaveChangesAsync();
                }
                context.ExtraAndDiscounts.Add(model.ExtraAndDiscount);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "GeneralSetting");

            }
            return View(model);
        }
        
        [HttpGet]
        [Authorize(Policy = "GeneralSettingEdit")]
        public IActionResult EditGeneralSetting()
        {
            ExtraAndDiscount extra = context.ExtraAndDiscounts.FirstOrDefault();
            var holidayes = context.Holidayes.ToList();
            GeneralSettingViewModel model = new GeneralSettingViewModel
            {
                Holidayes = holidayes,
                ExtraAndDiscount = extra
            };
            return View(model);
        }
       
        [HttpPost]
        [Authorize(Policy = "GeneralSettingEdit")]
        public async Task<IActionResult> EditGeneralSetting(GeneralSettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool flag = true;
                foreach (var item in model.Holidayes)
                {
                    if (item.IsSelected == true)
                    {
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    ModelState.AddModelError("", "You Shoud Select At Least One Day for holiday");
                    return View(model);
                }
                var holidayesIndb = context.Holidayes.ToList();
                //Remove Holidayes From Database
                for (int i = 0; i < holidayesIndb.Count; i++)
                {
                    context.Holidayes.Remove(holidayesIndb[i]);
                    await context.SaveChangesAsync();
                }
                List<Holidayes> ll = new List<Holidayes>();
                for (int i = 0; i < model.Holidayes.Count; i++)
                {
                    Holidayes holidayes1 = new Holidayes
                    {
                        Name = model.Holidayes[i].Name,
                        IsSelected = model.Holidayes[i].IsSelected
                    };
                    ll.Add(holidayes1);
                }

                // Add New Holidayes 
                foreach (var item in ll)
                {
                    context.Holidayes.Add(item);
                    await context.SaveChangesAsync();
                }
                //Update ExtraAnd Discount
                context.ExtraAndDiscounts.Update(model.ExtraAndDiscount);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "GeneralSetting");

            }
            return View(model);
        }

        [Authorize(Policy = "GeneralSettingShow")]
        public IActionResult OficialVacations()
        {
            var model = context.OfficialVacations.ToList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "GeneralSettingadd")]
        public IActionResult AddVacation()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "GeneralSettingAdd")]
        public async Task<IActionResult> AddVacation(OfficialVacations officialVacations)
        {
            if (ModelState.IsValid)
            {
                 context.OfficialVacations.Add(officialVacations);
                await context.SaveChangesAsync();
                return RedirectToAction("OficialVacations");
            }
            return View(officialVacations);
        }
        
        [HttpGet]
        [Authorize(Policy = "GeneralSettingEdit")]
        public async Task<IActionResult> EditVacation(int id)
        {
            var vacation = await context.OfficialVacations.FindAsync(id);
            if(vacation == null)
            {
                return View("NotFound");
            }
            return View(vacation);
        }
        
        [HttpPost]
        [Authorize(Policy = "GeneralSettingEdit")]
        public async Task<IActionResult> EditVacation(OfficialVacations officialVacations)
        {
            if (ModelState.IsValid)
            {
                //var official = context.OfficialVacations.Find(officialVacations.Id);
                //if (official == null)
                //{
                //    return View("NotFound");
                //}
                context.OfficialVacations.Update(officialVacations);
                await context.SaveChangesAsync();
                return RedirectToAction("OficialVacations");
            }
            return View(officialVacations);
        }
        
        [HttpPost]
        [Authorize(Policy = "GeneralSettingDelete")]
        public async Task<IActionResult> DeleteVacation(int id)
        {
            var vacation = context.OfficialVacations.Find(id);
            if(vacation == null)
            {
                return View("NotFound");
            }
            context.OfficialVacations.Remove(vacation);
            await context.SaveChangesAsync();
            return RedirectToAction("OficialVacations");
        }
    }
}
