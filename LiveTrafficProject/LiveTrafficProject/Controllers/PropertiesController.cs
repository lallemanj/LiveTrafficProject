#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveTrafficProject.Data;
using LiveTrafficProject.Models;
using LiveTrafficProject.Services;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Localization;

namespace LiveTrafficProject.Controllers
{
    public class PropertiesController : ApplicationController
    {
        private readonly IStringLocalizer<PropertiesController> _localizer;

        public PropertiesController(IdentityContext context, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationController> logger, IStringLocalizer<PropertiesController> localizer)
           : base(context, httpContextAccessor, logger)
        {
            _localizer = localizer;
        }

        // GET: Properties
        public async Task<IActionResult> Index(string? traffic)
        {
            if (traffic != null)
            {

                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.tomtom.com/traffic/services/5/incidentDetails?bbox=4.8854592519716675%2C52.36934334773164%2C4.897883244144765%2C52.37496348620152&fields=%7Bincidents%7Btype%2Cgeometry%7Btype%2Ccoordinates%7D%2Cproperties%7Bid%2CiconCategory%2CmagnitudeOfDelay%2Cevents%7Bdescription%2Ccode%7D%2CstartTime%2CendTime%2Cfrom%2Cto%2Clength%2Cdelay%2CroadNumbers%2CtimeValidity%2Caci%7BprobabilityOfOccurrence%2CnumberOfReports%2ClastReportTime%7D%2Ctmc%7BcountryCode%2CtableNumber%2CtableVersion%2Cdirection%2Cpoints%7Blocation%2Coffset%7D%7D%7D%7D%7D&language=en-GB&categoryFilter=0%2C1%2C2%2C3%2C4%2C5%2C6%2C7%2C8%2C9%2C10%2C11%2C14&timeValidityFilter=present%2Cfuture&key=hIQ7sERCrsAIdaBcD4I2inoY9sFjc7ms");
                    var json = web.DownloadString(url);
                    Root info = JsonConvert.DeserializeObject<Root>(json);
                    //IList<Root> incidents = new List<Root>();
                    //ViewData["traffics"] = incidents;
                    ViewBag.traffic = info;
                    //traffic = info.incidents[0].properties.Events[0].Description
                    Console.WriteLine(info);
                }
            }
            return View(await _context.Properties.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IconCategory,MagnitudeOfDelay,StartTime,EndTime,From,To,Length,Delay,TimeValidity")] Properties properties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(properties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(properties);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties.FindAsync(id);
            if (properties == null)
            {
                return NotFound();
            }
            return View(properties);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IconCategory,MagnitudeOfDelay,StartTime,EndTime,From,To,Length,Delay,TimeValidity")] Properties properties)
        {
            if (id != properties.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(properties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertiesExists(properties.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(properties);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var properties = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(properties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertiesExists(string id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
