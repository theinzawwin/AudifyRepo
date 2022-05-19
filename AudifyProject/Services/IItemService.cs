using AudifyProject.Filter;
using AudifyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public interface IItemService
    {
        Task<bool> Save(ItemViewModel itemViewModel);
        Task<List<ItemViewModel>> GetAllItems();
        Task<ChapterViewModel> UploadChapter(ChapterViewModel chapterItem);
        Task<List<ItemViewModel>> GetAllItemsByAuthorAndCategory(long authorId,long categoryId);
        Task<ItemViewModel> GetItemById(long Id);
        Task<List<ItemViewModel>> GetTopAudioList(int qty);
        Task<List<ItemViewModel>> GetItemListByAuthor(long authorId);
        Task<PagedResponse<List<ItemViewModel>>> GetItemListByCategory(long categoryId, PaginationFilter filter);
    }
}
