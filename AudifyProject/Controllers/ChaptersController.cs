using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AudifyProject.Data;
using AudifyProject.Models;
using System.Threading;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Http;
using AudifyProject.Services;

namespace AudifyProject.Controllers
{
    public class ChaptersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IItemService _itemService;

        public ChaptersController(ApplicationDbContext context,IItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        // GET: Chapters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Chapters.Include(c => c.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chapters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters
                .Include(c => c.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        // GET: Chapters/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
            return View();
        }

        // POST: Chapters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,FilePath,CoverFile,CoverType,CreatedDate,CreatedBy,Status,UpdatedDate,UpdatedBy,ItemId")] Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                chapter.Id = Guid.NewGuid();
                _context.Add(chapter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", chapter.ItemId);
            return View(chapter);
        }

        // GET: Chapters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", chapter.ItemId);
            return View(chapter);
        }

        // POST: Chapters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Duration,FilePath,CoverFile,CoverType,CreatedDate,CreatedBy,Status,UpdatedDate,UpdatedBy,ItemId")] Chapter chapter)
        {
            if (id != chapter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chapter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChapterExists(chapter.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", chapter.ItemId);
            return View(chapter);
        }
        [HttpPost]
        public async Task<IActionResult> UploadChapter(CancellationToken cancellationToken)
        {

            IFormFile formFile = Request.Form.Files[0];
            string Name = Request.Form["Name"].ToString();
            long itemId = long.Parse(Request.Form["ItemId"]);
            var chapterVM = new ChapterViewModel()
            {
                Name = Name,
                ItemId = itemId,
                File = formFile
            };
            var chapter=await _itemService.UploadChapter(chapterVM);
            if (formFile == null || formFile.Length <= 0)
            {
                return NotFound();
            }
            //return new JsonResult(chapter);
            return RedirectToAction("Details", "Items",new { id = itemId });
        }
        
            // GET: Chapters/Delete/5
            public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters
                .Include(c => c.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        // POST: Chapters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var chapter = await _context.Chapters.FindAsync(id);
            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChapterExists(Guid id)
        {
            return _context.Chapters.Any(e => e.Id == id);
        }
    }
}
