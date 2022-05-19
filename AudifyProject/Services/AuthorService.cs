using AudifyProject.Data;
using AudifyProject.Models;
using AudifyProject.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFirebaseService _firebaseService;
        private readonly ILogger<FirebaseService> _logger;
        public AuthorService(ApplicationDbContext context, IMapper mapper, IFirebaseService firebaseService, ILogger<FirebaseService> logger)
        {
            _context = context;
            _mapper = mapper;
            _firebaseService = firebaseService;
            _logger = logger;
        }

        public async Task<List<AuthorViewModel>> GetAuthorList()
        {
            var authorList = await _context.Authors.Where(a=>a.Status==true).ToListAsync();
            
            return _mapper.Map<List<AuthorViewModel>>(authorList);
        }

        public async Task<List<AuthorViewModel>> GetAuthorListByStatus(bool status)
        {
            var authorList =await _context.Authors.Where(a => a.Status == status).Select(a => new AuthorViewModel() { Id = a.Id, Name = a.Name, Description = a.Description, Remark = a.Remark }).ToListAsync();
            return authorList;
        }

        public async Task<AuthorViewModel> GetAuthorWithItems(long Id)
        {
            var author =await _context.Authors.Include(a => a.Items).Where(a => a.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<AuthorViewModel>(author);
        }

        public async Task<List<AuthorViewModel>> GetTop5List()
        {
            var authorList = await _context.Authors.Take(5).ToListAsync();
            return _mapper.Map<List<AuthorViewModel>>(authorList);
        }

        public async Task<bool> Save(AuthorFormViewModel author)
        {

            try
            {
                string ProfileName = string.Empty;
                if (author.File != null)
                {
                    ProfileName = await _firebaseService.UploadFile(author.File);
                }
               // await Task.WhenAll();
                var a = new Author()
                {
                    Name = author.Name,
                    Description = author.Description,
                    Profile = ProfileName,
                    CreatedDate = DateTime.Now,
                    Status = true,
                    Remark = author.Remark,
                    CreatedBy = author.CreatedBy
                };
                _context.Authors.Add(a);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            
        }
    }
}
