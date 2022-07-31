using AudifyProject.Data;
using AudifyProject.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoryViewModel> FindCategoryWithItems()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var allCategories = await _context.Categories.Where(c => c.Status == true).ToListAsync();
            return _mapper.Map<List<CategoryViewModel>>(allCategories);
        }

        public async Task<List<CategoryViewModel>> GetCategoryListWithTop5Items()
        {
            var allCategories = await _context.Categories.Include(c => c.Items).ThenInclude(i=>i.Author).Where(c => c.Status == true && c.Items.Count>0).ToListAsync();
            return _mapper.Map<List<CategoryViewModel>>(allCategories);
        }
    }
}
