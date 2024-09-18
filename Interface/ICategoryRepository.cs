using APIAnimeApp.Model;

namespace APIAnimeApp.Interface
{
	public interface ICategoryRepository
	{
		public ICollection<Category> GetAll();
	}
}
