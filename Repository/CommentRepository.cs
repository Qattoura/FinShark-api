using FinShark.api.Data;
using FinShark.api.Interfaces;
using FinShark.api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
            
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
