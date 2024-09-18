namespace APIAnimeApp.Dto
{
	public class CommentDto
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public DateTime? CreateAt { get; set; }
		public string? UserName { get; set; }
		public int IdStory { get; set; }
	}
}
