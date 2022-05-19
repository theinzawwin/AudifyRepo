using AudifyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategory();
        Task<CategoryViewModel> FindCategoryWithItems();
        Task<List<CategoryViewModel>> GetCategoryListWithTop5Items();

    }
}
