using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AudifyProject.Data;
using AudifyProject.Models;
using AudifyProject.ViewModels;
using AudifyProject.Services;
using System.Security.Claims;
using System.Threading;

namespace AudifyProject.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IItemService _itemService;

        public ItemsController(ApplicationDbContext context,IItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(i => i.Author).Include(i => i.Category).Include(i=>i.Chapters);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Author)
                .Include(i => i.Category).Select(c=>new ItemViewModel() {Id=c.Id,Name=c.Name,Description=c.Description,AuthorId=c.AuthorId,AuthorName=c.Author.Name,CategoryId=c.CategoryId,CategoryName=c.Category.Name,
                TotalPage=c.TotalPage,TotalReview=c.TotalReview,Duration=c.Duration,CoverFileName=c.CoverFile, Chapters=c.Chapters.Select(ch=>new ChapterViewModel() {Id=ch.Id,Name=ch.Name,FileName=ch.FilePath }).ToList()
                })
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit =int.MaxValue)]
        [RequestSizeLimit(int.MaxValue)]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,TotalReview,TotalPage,Duration,CategoryId,AuthorId,HasChapter,Status,CoverFile,Chapters")] ItemViewModel item, CancellationToken cancellationToken)
        {
            string ErrorMessage = "";
            if (ModelState.IsValid)
            {
                /*_context.Add(item);
                await _context.SaveChangesAsync();
                */
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                item.CreatedBy = userId;

                try
                {
                    await _itemService.Save(item);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }


            }
            ViewData["ErrorMessage"] = ErrorMessage;
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", item.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemService.GetItemEditViewModel(id??0L);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
        [RequestSizeLimit(int.MaxValue)]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,TotalReview,TotalPage,Duration,CategoryId,AuthorId,HasChapter,Status,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,CoverFile,CoverType")] ItemViewModel item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bool result =  await  _itemService.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", item.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Author)
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(long id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
