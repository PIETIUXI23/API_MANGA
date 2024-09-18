using APIAnimeApp.Dto;
using APIAnimeApp.Interface;
using APIAnimeApp.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace APIAnimeApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;
		public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200,Type=typeof(IEnumerable<Category>))]
		[ProducesResponseType(400)]
		public IActionResult getAllCategory()
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetAll());
			return Ok(categories);
		}
	}
}
