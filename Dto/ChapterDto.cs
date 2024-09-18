namespace APIAnimeApp.Dto
{
	public class ChapterDto
	{
		public int Id { get; set; }
		public string? ChapterName { get; set; }
		public DateTime? CreateAt { get; set; }
		public int? IdStory { get; set; }
	}
}
