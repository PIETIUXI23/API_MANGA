using System;
using System.Collections.Generic;

namespace APIAnimeApp.Model
{
    public partial class Story
    {
        public Story()
        {
            Chapters = new HashSet<Chapter>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CoverImage { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        public int? IdCategory { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
