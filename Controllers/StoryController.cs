using APIAnimeApp.Dto;
using APIAnimeApp.Interface;
using APIAnimeApp.Model;
using APIAnimeApp.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAnimeApp.Controllers
{	
    [Route("api/[controller]")]
	[ApiController]
	public class StoryController : ControllerBase
	{
		public static int pageSize = 10;
		private readonly IStoryRepository _storyRepository;
		private readonly IMapper _mapper;
		public StoryController(IStoryRepository storyRepository,IMapper mapper)
		{
			_storyRepository = storyRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200,Type=typeof(IEnumerable<Story>))]
		[ProducesResponseType(400)]
		public IActionResult getAllStory()
		{
			var stories = _mapper.Map<List<StoryDto>>(_storyRepository.getAll());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(stories);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200,Type=typeof(Story))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public IActionResult getStoryById(int id) 
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if(!_storyRepository.isExist(id))
			{
				return NotFound();
			}
			var story=_mapper.Map<StoryDto>(_storyRepository.getById(id));
			return Ok(story);
		}

		[HttpGet("name/{name}")]
		[ProducesResponseType(200, Type = typeof(Story))]
		[ProducesResponseType(400)]
		public IActionResult getStoryByName(String name)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var story = _mapper.Map<List<StoryDto>>(_storyRepository.getByName(name));
			return Ok(story);
		}

		[HttpGet("category/{categoryId}")]
		[ProducesResponseType(200, Type = typeof(Story))]
		[ProducesResponseType(400)]
		public IActionResult getStoryByCategoryId(int categoryId)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var story = _mapper.Map<List<StoryDto>>(_storyRepository.getByCategory(categoryId));
			return Ok(story);
		}

		[HttpGet("page/{pageNum}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Story>))]
		[ProducesResponseType(400)]
		public IActionResult getPageByIdChapterAndPageNum(int pageNum)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var pages = _mapper.Map<List<StoryDto>>(_storyRepository.getByPageNum(pageNum, pageSize));
			return Ok(pages);
		}
	}
}
