using expenseTrackerPOC.Data.Dtos;
using expenseTrackerPOC.Services.Core.Interfaces;

namespace expenseTrackerPOC.Services.Core
{
    public class EmailService : IEmailService
    {
        public Task SendLoginAttemptMail(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task SendWelcomeMail(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
