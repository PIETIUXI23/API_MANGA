using APIAnimeApp.Model;

namespace APIAnimeApp.Interface
{
	public interface IChapterRepository
	{
		public ICollection<Chapter> getChapterByIdStory(int id);
	}
}
