using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIAnimeApp.Model
{
    public partial class Comment
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? UserName { get; set; }
        public int? RatingValue { get; set; }
        public int IdStory { get; set; }

        public virtual Story IdStoryNavigation { get; set; } = null!;
    }
}
