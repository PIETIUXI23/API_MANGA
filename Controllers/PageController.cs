using APIAnimeApp.Dto;
using APIAnimeApp.Interface;
using APIAnimeApp.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace APIAnimeApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PageController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IPageRepository _pageRepository;
		private static int pageSize = 5;
		public PageController(IPageRepository pageRepository,IMapper mapper)
		{
			_pageRepository = pageRepository;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public IActionResult GetAllById(int id) 
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var pages = _mapper.Map<List<PageDto>>(_pageRepository.GetAllByChapterId(id));
			return Ok(pages);
		}

		[HttpGet("{id}/{pageNum}")]
		[ProducesResponseType(200,Type=typeof(IEnumerable<Page>))]
		[ProducesResponseType(400)]
		public IActionResult getPageByIdChapterAndPageNum(int id,int pageNum)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var pages= _mapper.Map<List<PageDto>>(_pageRepository.GetByChapterIdAndPageNumber(id,pageNum,pageSize));
			return Ok(pages);
		}

	}
}
