using AudifyProject.Models;
using AudifyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public interface IAuthorService
    {
        Task<bool> Save(AuthorFormViewModel author);
        Task<List<AuthorViewModel>> GetAuthorListByStatus(bool status);
        Task<List<AuthorViewModel>> GetAuthorList();
        Task<AuthorViewModel> GetAuthorWithItems(long Id);
        Task<List<AuthorViewModel>> GetTop5List();
    }
}
