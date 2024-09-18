using APIAnimeApp.Model;

namespace APIAnimeApp.Interface
{
	public interface ICommentRepository
	{
		public ICollection<Comment> GetAllByIdStory(int id);
		public bool isExist(int id);
		public bool createComment(Comment comment);
	}
}
