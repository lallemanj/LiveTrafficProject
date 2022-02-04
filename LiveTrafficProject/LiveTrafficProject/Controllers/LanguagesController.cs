﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveTrafficProject.Data;
using LiveTrafficProject.Models;
using Microsoft.AspNetCore.Localization;
using LiveTrafficProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LiveTrafficProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguagesController : ApplicationController
    {
        //private readonly IdentityContext _context;
        //private readonly UserManager<LiveTrafficProjectUser> _userManager;


        public LanguagesController(IdentityContext context, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationController> logger)
            : base(context, httpContextAccessor, logger)
        {

        }

        public IActionResult ChangeLanguage(string id, string returnUrl)
        {
            string culture = Thread.CurrentThread.CurrentCulture.ToString();
            culture = id + culture.Substring(2);  // bv. als de cookie "en-US" bevat, en Nederlands wordt gekozen: --> "nl-US"

            if (culture.Length != 5) culture = id;

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            if (_user.Id != "-")
            {
                _user.LanguageId = id;
                Language language = _context.Language.FirstOrDefault(l => l.Id == id);
                _user.Language = language;
                LiveTrafficProjectUser user = _context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user.Language = language;
                _context.SaveChanges();
            }

            return LocalRedirect(returnUrl);
        }

        // GET: Languages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Language.ToListAsync());
        }

        // GET: Languages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cultures,IsSystemLanguage")] Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Cultures,IsSystemLanguage")] Language language)
        {
            if (id != language.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.Id))
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
            return View(language);
        }

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language
                .FirstOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var language = await _context.Language.FindAsync(id);
            _context.Language.Remove(language);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(string id)
        {
            return _context.Language.Any(e => e.Id == id);
        }

    }
}
