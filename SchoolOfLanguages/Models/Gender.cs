using System;
using System.Collections.Generic;

namespace SchoolOfLanguages.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string NameGender { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
