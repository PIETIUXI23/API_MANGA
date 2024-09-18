using System;
using System.Collections.Generic;

namespace APIAnimeApp.Model
{
    public partial class Chapter
    {
        public Chapter()
        {
            Pages = new HashSet<Page>();
        }

        public int Id { get; set; }
        public string? ChapterName { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? IdStory { get; set; }

        public virtual Story? IdStoryNavigation { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
