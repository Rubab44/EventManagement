// IEventService.cs
using BlazorAuthPolicy.Models.ViewModels;

namespace BlazorAuthPolicy.Service
{
    public interface IEventService
    {
        Task SaveEventAsync(EventViewModel eventViewModel);
    }
}
