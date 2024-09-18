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
	public class ChapterController : ControllerBase
	{
		private readonly IChapterRepository _chapterRepository;
		private readonly IMapper _mapper;
		public ChapterController(IChapterRepository chapterRepository,IMapper mapper)
		{ 
			_chapterRepository = chapterRepository;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200,Type=typeof(IEnumerable<Chapter>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public IActionResult getChapterByIdStory(int id)
		{
			if(!ModelState.IsValid) return BadRequest(ModelState);
			var chapters=_mapper.Map<List<ChapterDto>>(_chapterRepository.getChapterByIdStory(id));
			return Ok(chapters);
		}
	}
}
