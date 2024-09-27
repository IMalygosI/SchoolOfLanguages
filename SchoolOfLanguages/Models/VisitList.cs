using System;
using System.Collections.Generic;

namespace SchoolOfLanguages.Models;

public partial class VisitList
{
    public int Id { get; set; }

    public DateOnly? Data { get; set; }

    public TimeOnly? Time { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
