using BlazorAuthPolicy.Models.ViewModels;

namespace BlazorAuthPolicy.Services
{
    public interface IEventCategoryService
    {
        Task SaveEventCategoryAsync(EventCategoryViewModel eventCategoryViewModel);
    }
}
