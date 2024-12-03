// EventService.cs
using BlazorAuthPolicy.Models.ViewModels;
using BlazorAuthPolicy.Models.Entities;
using BlazorAuthPolicy.Data;

namespace BlazorAuthPolicy.Service
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveEventAsync(EventViewModel eventViewModel)
        {
            var eventEntity = new Event
            {
                Name = eventViewModel.Name,
                Description = eventViewModel.Description,
                Date = eventViewModel.Date,
                VenueId = eventViewModel.VenueId,
                OrganizerId = eventViewModel.OrganizerId,
                Status = eventViewModel.Status
            };

            _context.Events.Add(eventEntity);
            await _context.SaveChangesAsync();
        }
    }
}
