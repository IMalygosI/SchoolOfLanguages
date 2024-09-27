using System;
using System.Collections.Generic;

namespace SchoolOfLanguages.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ListTag> ListTags { get; set; } = new List<ListTag>();
}
