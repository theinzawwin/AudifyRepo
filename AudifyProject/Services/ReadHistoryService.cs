using AudifyProject.Data;
using AudifyProject.Models;
using AudifyProject.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public class ReadHistoryService : IReadHistoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReadHistoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> DeleteReadHistory(string userId, Guid chapterId)
        {
           
            var readHistory = _context.ReadingHistories.Where(r => r.UserId == userId && r.ChapterId == chapterId).FirstOrDefault();
            if (readHistory != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<List<ReadHistoryViewModel>> GetReadHistoryList(string userId)
        {

            var readList = _context.ReadingHistories.Include(r=>r.Chapter).ThenInclude(c=>c.Item).Where(r => r.UserId == userId).ToList();
            return _mapper.Map<List<ReadHistoryViewModel>>(readList);
        }

        public async Task<bool> SaveReadHistory(string userId, Guid chapterId)
        {
            
            try
            {
                var existHistory = _context.ReadingHistories.Where(r => r.UserId == userId && r.ChapterId == chapterId).FirstOrDefault();
                if (existHistory == null)
                {
                    var readHistory = new ReadingHistory()
                    {
                        ChapterId = chapterId,
                        UserId = userId,
                        CreatedDate = DateTime.Now,
                        Status = true
                    };
                    _context.Add(readHistory);
                    var result = await _context.SaveChangesAsync();
                    var totalQty = _context.ReadingHistories.Where(r => r.ChapterId == chapterId).Count();
                    var audio = _context.ReadingHistories.Include(r => r.Chapter).ThenInclude(r => r.Item).Where(r => r.Id == readHistory.Id).FirstOrDefault();

                    var item = audio.Chapter.Item;
                    item.ReadQty = totalQty;
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var audio = _context.ReadingHistories.Include(r => r.Chapter).ThenInclude(r => r.Item).Where(r => r.Id == existHistory.Id).FirstOrDefault();

                    var item = audio.Chapter.Item;
                    item.ReadQty = item.ReadQty+1;
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                   
                    return false;
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
