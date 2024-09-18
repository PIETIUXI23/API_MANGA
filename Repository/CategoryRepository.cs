using APIAnimeApp.Interface;
using APIAnimeApp.Model;

namespace APIAnimeApp.Repository
{
	public class CategoryRepository:ICategoryRepository
	{
		private readonly QLTruyenTranhContext _context;
		public CategoryRepository(QLTruyenTranhContext context)
		{
			_context = context;
		}
		public ICollection<Category> GetAll()
		{
			return _context.Categories.ToList();
		}
	}
}
