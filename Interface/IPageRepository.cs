using APIAnimeApp.Model;

namespace APIAnimeApp.Interface
{
	public interface IPageRepository
	{
		public ICollection<Page> GetAllByChapterId(int id);
		public ICollection<Page> GetByChapterIdAndPageNumber(int id,int pageNum,int size);
	}
}
