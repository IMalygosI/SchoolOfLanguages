using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolOfLanguages.Models;

public partial class Client
{
    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int Gender { get; set; }

    public string? Phone { get; set; }

    public string? ClientPhoto { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Email { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public int Id { get; set; }

    public int? Countvisit { get; set; }

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual ICollection<LinkingToFile> LinkingToFiles { get; set; } = new List<LinkingToFile>();

    public virtual ICollection<ListTag> ListTags { get; set; } = new List<ListTag>();

    public virtual ICollection<VisitList> VisitLists { get; set; } = new List<VisitList>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public DateOnly? Last_visit_date => VisitLists.Count != 0 ? VisitLists.Select(x => x.Data).Order().First() : null;
    public string gender => Gender == 1 ? "Муж." : "Жен.";
    public Bitmap? Picture => ClientPhoto != null ? new Bitmap($@"Assets\\{ClientPhoto}") : null;
}
