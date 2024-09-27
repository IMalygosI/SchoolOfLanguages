using System;
using System.Collections.Generic;

namespace SchoolOfLanguages.Models;

public partial class LinkingToFile
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public int IdFile { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual File IdFileNavigation { get; set; } = null!;
}
