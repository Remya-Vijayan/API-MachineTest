using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class BackgroundVerification
{
    public int VerificationId { get; set; }

    public int? LoanId { get; set; }

    public int? LoanOfficerId { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Loan? Loan { get; set; }

    public virtual User? LoanOfficer { get; set; }
}
