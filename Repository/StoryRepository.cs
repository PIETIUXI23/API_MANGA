using APIAnimeApp.Interface;
using APIAnimeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace APIAnimeApp.Repository
{
	public class StoryRepository:IStoryRepository
	{
		private readonly QLTruyenTranhContext _context;
		public StoryRepository(QLTruyenTranhContext context) { 
			this._context = context;
		}

		public ICollection<Story> getAll()
		{
			return _context.Stories.Include(s=>s.IdCategoryNavigation).Include(s => s.Chapters).ToList();
		}

		public Story getById(int id)
		{
			return _context.Stories.Where(s => s.Id == id).Include(s => s.IdCategoryNavigation).Include(s=>s.Chapters).FirstOrDefault();
		}

		public bool isExist(int id)
		{
			return _context.Stories.Any(s => s.Id == id);
		}

		public ICollection<Story> getByName(string name)
		{
			return _context.Stories.Where(s=>s.Name.ToLower().Contains(name.ToLower())).Include(s => s.IdCategoryNavigation).Include(s => s.Chapters).ToList();
		}
		public ICollection<Story> getByCategory(int categoryId)
		{
			return _context.Stories.Where(s=>s.IdCategory==categoryId).Include(s=>s.IdCategoryNavigation).Include(s => s.Chapters).ToList();
		}

		public ICollection<Story> getByPageNum(int pageNum, int pageSize)
		{
			return _context.Stories.Skip((pageNum-1)*pageSize).Take(pageSize).Include(s => s.IdCategoryNavigation).Include(s => s.Chapters).ToList();
		}
	}
}
