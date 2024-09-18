using System;
using System.Collections.Generic;

namespace APIAnimeApp.Model
{
    public partial class Category
    {
        public Category()
        {
            Stories = new HashSet<Story>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}
