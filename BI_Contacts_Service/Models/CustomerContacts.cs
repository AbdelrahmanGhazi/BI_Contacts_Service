using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BI_Contacts_Service.Models;

public partial class CustomerContacts
{
    [Key]
    public int ContactID { get; set; }
    public string CustomerID { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactArabicName { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string CellPhone { get; set; } = null!;

    public string E_Mail { get; set; } = null!;

    public int ContactType { get; set; }
}
