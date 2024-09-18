using APIAnimeApp.Dto;
using APIAnimeApp.Interface;
using APIAnimeApp.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAnimeApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository commentRepository,IMapper mapper)
        {
            _commentRepository= commentRepository;
            _mapper= mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Comment>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult getByIdStory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_commentRepository.isExist(id))
            {
                return NotFound();
            }
            var comments=_mapper.Map<List<CommentDto>>(_commentRepository.GetAllByIdStory(id));
            return Ok(comments);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult createComment([FromBody]CommentDto commentCreate)
        {
            
            if(commentCreate==null)
            {
                return BadRequest(ModelState);
            }

			if (!ModelState.IsValid)
			{
			    return BadRequest(ModelState);
			}
			Comment newComment = _mapper.Map<Comment>(commentCreate);
			if (!_commentRepository.createComment(newComment))
            {
                ModelState.AddModelError("", "Some thing went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok(commentCreate);
        }
    }
}
