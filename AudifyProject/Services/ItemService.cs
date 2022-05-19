using AudifyProject.Data;
using AudifyProject.Filter;
using AudifyProject.Helpers;
using AudifyProject.Models;
using AudifyProject.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFirebaseService _firebaseService;
        private readonly IMapper _mapper;
        public ItemService(ApplicationDbContext context,IFirebaseService firebaseService, IMapper mapper)
        {
            _context = context;
            _firebaseService = firebaseService;
            _mapper = mapper;
        }
        public async Task<List<ItemViewModel>> GetAllItems()
        {
            var items = await _context.Items.Include(i => i.Chapters).Include(i => i.Author).Include(i => i.Category).Where(i=>i.Status==true).ToListAsync();
            var itemList = _mapper.Map<List<ItemViewModel>>(items);
            return itemList;
        }

        public async Task<List<ItemViewModel>> GetAllItemsByAuthorAndCategory(long authorId=0, long categoryId=0)
        {
            
                var dataList = await _context.Items.Where(i => (i.AuthorId == authorId || i.AuthorId == 0)&&(i.CategoryId==categoryId||categoryId==0)).Include(i => i.Chapters).Include(i => i.Author).Include(i => i.Category).ToListAsync();
            return _mapper.Map<List<ItemViewModel>>(dataList);
        }

        public async Task<ItemViewModel> GetItemById(long Id)
        {
            var item = await _context.Items.Include(i => i.Chapters).Include(i=>i.Author).Include(i=>i.Category).Where(i => i.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<ItemViewModel>(item);
        }

        public async Task<List<ItemViewModel>> GetItemListByAuthor(long authorId)
        {
            var items = await _context.Items.Include(i => i.Chapters).Include(i => i.Author).Include(i => i.Category).Where(i => i.Status == true && i.AuthorId==authorId).ToListAsync();
            var itemList = _mapper.Map<List<ItemViewModel>>(items);
            return itemList;
        }

        public async Task<PagedResponse<List<ItemViewModel>>> GetItemListByCategory(long categoryId, PaginationFilter filter)
        {
            var pagedData = await _context.Items
                            .Skip((filter.PageNumber - 1) * filter.PageSize)
                            .Take(filter.PageSize)
                            .ToListAsync();
            var totalRecords = await _context.Items.Where(i=>i.CategoryId==categoryId).CountAsync();
            var itemList = _mapper.Map<List<ItemViewModel>>(pagedData);
            var pageResponse = PaginationHelper.CreatePagedReponse<ItemViewModel>(itemList,filter,totalRecords); //new PagedResponse<List<ItemViewModel>>(itemList,filter.PageNumber,filter.PageSize);
            return pageResponse;
        }

        public async Task<List<ItemViewModel>> GetTopAudioList(int qty)
        {
            var itemList = await _context.Items.Include(i=>i.Chapters).Include(i=>i.Author).Include(i=>i.Category).OrderByDescending(i=>i.CreatedDate).Take(qty).ToListAsync();
            return _mapper.Map<List<ItemViewModel>>(itemList);
        }

        public async Task<bool> Save(ItemViewModel itemViewModel)
        {
            string fileName = String.Empty;
            try
            {
                fileName = await _firebaseService.UploadFile(itemViewModel.CoverFile);
            }catch(Exception ex)
            {
                throw ex;
            }
            
            List<Chapter> chapters =new List<Chapter>();
            if (itemViewModel.Chapters != null && itemViewModel.Chapters.Count > 0)
            {
                foreach(var chapter in itemViewModel.Chapters) 
                {
                    string chapterName = await _firebaseService.UploadFile(chapter.File); //await _firebaseService.UploadAudio(chapter.File);
                    chapters.Add(new Chapter()
                    {
                        Name=chapter.Name,
                        FilePath=chapterName
                    });
                }
                
            }
            await Task.WhenAll();
            Item item = new Item()
            {
                Name = itemViewModel.Name,
                Description = itemViewModel.Description,
                Duration = itemViewModel.Duration,
                CoverFile = fileName,
                AuthorId = itemViewModel.AuthorId,
                CategoryId = itemViewModel.CategoryId,
                TotalPage=itemViewModel.TotalPage,
                CreatedBy=itemViewModel.CreatedBy,
                CreatedDate=DateTime.Now,
                Status=true,
                Chapters=chapters
            };
            _context.Add(item);
            int result =await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ChapterViewModel> UploadChapter(ChapterViewModel chapterItem)
        {
            string fileName = await _firebaseService.UploadFile(chapterItem.File);
            string originalName = chapterItem.File.FileName;
            var chapter = new Chapter()
            {
                ItemId = chapterItem.ItemId,
                Name = chapterItem.Name,
                CoverFile= originalName,
                FilePath = fileName,
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now,
                Status = true

            };
            _context.Add(chapter);
          int result= await _context.SaveChangesAsync();
            chapterItem = new ChapterViewModel()
            {
                Id = chapter.Id,
                Name = chapter.Name,
                FileName = chapter.FilePath,
                
            };
            return chapterItem;

        }
    }
}
