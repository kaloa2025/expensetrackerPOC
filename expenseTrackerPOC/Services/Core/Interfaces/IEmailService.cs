using expenseTrackerPOC.Data.Dtos;
using expenseTrackerPOC.Models;

namespace expenseTrackerPOC.Services.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendLoginAttemptMail(UserDto user);
        Task SendWelcomeMail(UserDto user);
    }
}
