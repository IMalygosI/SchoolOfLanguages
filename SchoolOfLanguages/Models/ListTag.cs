using System;
using System.Collections.Generic;

namespace SchoolOfLanguages.Models;

public partial class ListTag
{
    public int IdTag { get; set; }

    public int Id { get; set; }

    public int IdClient { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Tag IdTagNavigation { get; set; } = null!;
}
