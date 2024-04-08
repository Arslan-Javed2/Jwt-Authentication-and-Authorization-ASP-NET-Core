using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Repositories.Interfaces
{
    public interface IEmail:IDisposable
    {
        Task<ActionResult> SendEmail(string body);
    }
}
