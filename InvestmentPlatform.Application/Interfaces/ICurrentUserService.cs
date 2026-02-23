using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPlatform.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string? Email { get; }
        bool IsAuthenticated { get; }
    }
}
