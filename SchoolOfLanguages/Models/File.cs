using System;
using System.Collections.Generic;

namespace SchoolOfLanguages.Models;

public partial class File
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public virtual ICollection<LinkingToFile> LinkingToFiles { get; set; } = new List<LinkingToFile>();
}
