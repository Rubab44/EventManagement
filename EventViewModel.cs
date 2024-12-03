using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAuthPolicy.Models.ViewModels
{
	public class EventViewModel
	{
		[Required]
		public string? Name { get; set; }

		public string? Description { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int VenueId { get; set; }

		[Required]
		public int OrganizerId { get; set; }

		[Required]
		public string? Status { get; set; }
	}
}
