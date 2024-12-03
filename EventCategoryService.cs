using BlazorAuthPolicy.Data;
using BlazorAuthPolicy.Models.Entities;
using BlazorAuthPolicy.Models.ViewModels;

namespace BlazorAuthPolicy.Services
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly AppDbContext _context;

        public EventCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveEventCategoryAsync(EventCategoryViewModel eventCategoryViewModel)
        {
            var eventCategory = new EventCategory
            {
                Name = eventCategoryViewModel.Name
            };

            _context.EventCategories.Add(eventCategory);
            await _context.SaveChangesAsync();
        }
    }
}
