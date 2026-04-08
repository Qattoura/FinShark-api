using FinShark.api.Interfaces;
using FinShark.api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }

    }
}
