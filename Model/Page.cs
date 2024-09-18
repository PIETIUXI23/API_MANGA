using System;
using System.Collections.Generic;

namespace APIAnimeApp.Model
{
    public partial class Page
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public int? PageNumber { get; set; }
        public int? IdChap { get; set; }

        public virtual Chapter? IdChapNavigation { get; set; }
    }
}
