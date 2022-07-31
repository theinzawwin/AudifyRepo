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
        Task<bool> Update(ItemViewModel itemViewModel);
        Task<List<ItemViewModel>> GetAllItems();
        Task<ChapterViewModel> UploadChapter(ChapterViewModel chapterItem);
        Task<List<ItemViewModel>> GetAllItemsByAuthorAndCategory(long authorId,long categoryId);
        Task<ItemViewModel> GetItemById(long Id,string userId);
        Task<ItemViewModel> GetItemEditViewModel(long Id);
        Task<List<ItemViewModel>> GetTopAudioList(int qty);
        Task<List<ItemViewModel>> GetItemListByAuthor(long authorId);
        Task<PagedResponse<List<ItemViewModel>>> GetItemListByCategory(long categoryId, PaginationFilter filter);
        Task<bool> FavoriteAudio(long id, string userId);

        Task<List<FavoriteItemViewModel>> GetFavoriteItemList(string userId);

        Task<List<ItemViewModel>> GetTopTrending();

        Task<List<ItemViewModel>> GetNewReleaseList();
        Task<SearchItemViewModel> SearchAudio(string name);

        Task<bool> SaveFeedback(FeedbackViewModel feedback);
    }
}
