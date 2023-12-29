using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaintenancePro2.Models;

namespace MaintenancePro2.Controllers
{
    public class HomeController : Controller
    {
        private theContext _context;

        public HomeController(theContext context)
        {
            _context = context;
        }
        
        [HttpGet("")]
        public IActionResult ShowMotor()
        {
            IndexView motorsWithItems = new IndexView()
            {
                AllItems = _context.Items
                .Include(item => item.Bike)
                .ToList(),

                AllMotors = _context.Motors
                .Include(motor => motor.motorItems)
                .ToList()
            };
            return View(motorsWithItems);
        }

        [HttpGet("newMotor")]
        public IActionResult AddMotor()
        {
            return View();
        }

        [HttpPost("newVehicle")]
        public RedirectToActionResult NewVic(Motor aMotor)
        {
            if(ModelState.IsValid)
            {
                _context.Add(aMotor);
                _context.SaveChanges();
                return RedirectToAction("ShowMotor");
            }
            return RedirectToAction("AddMotor");
        }

        [HttpPost("oneMotor")]
        public RedirectToActionResult ThisMotor()
        {
            return RedirectToAction("mainSchedule");
        }

        [HttpGet("Schedule/{id}")]
        public IActionResult mainSchedule(int id)
        {
            Console.WriteLine(id);
            IndexView allItemsAndMotors = new IndexView()
            {
                AllItems = _context.Items
                .Include(item => item.Bike)
                .ToList(),

                AMotorID = id
            };
            return View(allItemsAndMotors);
        }

        [HttpGet("addItem/{id}")]
        public IActionResult AddItem(int id)
        {

            MaintenanceItem newItem = new MaintenanceItem()
            {
                MotorList = _context.Motors
                .Where(m => m.motorID == id)
                .ToList()
                
            };
            return View(newItem);
        }

        [HttpPost("newItem")]
        public RedirectToActionResult NewItem(MaintenanceItem anItem)
        {
            if(ModelState.IsValid)
            {
                _context.Add(anItem);
                _context.SaveChanges();
                return RedirectToAction("mainSchedule");
            }

            return RedirectToAction("AddItem");
        }

        [HttpGet("logItem/{iid}/{mid}")]
        public IActionResult LogItem(int iid, int mid)
        {
            Console.WriteLine(iid);
            Console.WriteLine(mid);
            PreformedItem itemAndMotor = new PreformedItem()
            {
                ItemList = _context.Items
                .Where(i => i.itemID == iid)
                .ToList(),

                MotorList = _context.Motors
                .Where(m => m.motorID == mid)
                .ToList()

            };

            return View(itemAndMotor);
        }

        [HttpPost("newlyPreformed")]
        public RedirectToActionResult NewlyPreformed(PreformedItem Log)
        {
            if(ModelState.IsValid)
            {
                _context.Add(Log);
                _context.SaveChanges();
                return RedirectToAction("mainLog");
            }
            return RedirectToAction("LogItem");
        }

        [HttpGet("MaintenanceLog")]
        public IActionResult mainLog()
        {
            IndexView itemsPerformed = new IndexView()
            {
                AllPerformedItems = _context.PerformedItems
                .Include(p => p.Item)
                .ToList()
            };
            return View(itemsPerformed);
        }

    }
}
