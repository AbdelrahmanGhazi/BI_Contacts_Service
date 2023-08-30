using System;
using System.ComponentModel.DataAnnotations;

namespace BI_Contacts_Service.Models;

public partial class ContactTypes
{
    [Key]
    public int Type { get; set; }

    public string Description { get; set; } = null!;

    public string ArabicDescription { get; set; } = null!;
}
