using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Help> Helps { get; set; } = new List<Help>();

    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Role? Role { get; set; }
}
