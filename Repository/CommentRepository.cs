using APIAnimeApp.Interface;
using APIAnimeApp.Model;

namespace APIAnimeApp.Repository
{
	public class CommentRepository:ICommentRepository
	{
		private readonly QLTruyenTranhContext _context;
		public CommentRepository(QLTruyenTranhContext context)
		{
			_context = context;
		}

		public bool createComment(Comment comment)
		{
			_context.Add(comment);
			int n=_context.SaveChanges();
			return n>0? true: false;
		}

		public ICollection<Comment> GetAllByIdStory(int id)
		{
			return _context.Comments.Where(cm => cm.IdStory == id).ToList();
		}

		public bool isExist(int id)
		{
			return _context.Stories.Any(st => st.Id == id);
		}

		
	}
}
