using AudifyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public interface IReadHistoryService
    {
        Task<List<ReadHistoryViewModel>> GetReadHistoryList(string userId);
        Task<bool> SaveReadHistory(string userId, Guid chapterId);
        Task<bool> DeleteReadHistory(string userId, Guid chapterId);
    }
}
