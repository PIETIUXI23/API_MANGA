using APIAnimeApp.Interface;
using APIAnimeApp.Model;

namespace APIAnimeApp.Repository
{
	public class PageRepository:IPageRepository
	{
		private readonly QLTruyenTranhContext _context;
		public PageRepository(QLTruyenTranhContext context)
		{
			_context = context;
		}
		public ICollection<Page> GetAllByChapterId(int id)
		{
			return _context.Pages.Where(p=>p.IdChap==id).ToList();
		}
		public ICollection<Page> GetByChapterIdAndPageNumber(int id,int pageNum, int size)
		{
			return _context.Pages.Where(p=>p.IdChap==id).Skip((pageNum-1)*size).Take(size).ToList();
		}
	}
}
