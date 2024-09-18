using APIAnimeApp.Interface;
using APIAnimeApp.Model;

namespace APIAnimeApp.Repository
{
	public class ChapterRepository:IChapterRepository
	{
		private readonly QLTruyenTranhContext _context;
		public ChapterRepository(QLTruyenTranhContext context) 
		{
			_context = context;
		}

		public ICollection<Chapter> getChapterByIdStory(int id) 
		{
			return _context.Chapters.Where(c=>c.IdStory == id).ToList();
		}
	}
}
