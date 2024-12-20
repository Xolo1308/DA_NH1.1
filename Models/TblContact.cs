using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class TblContact
{
    public int tblContactId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    //public int? IsRead { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }
}
