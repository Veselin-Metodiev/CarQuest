namespace CarQuest.Web.ViewModels.TicketUser;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Car;

using Data.Models;

using Services.Mapping;

using static Common.EntityValidationConstants.TicketAddAndUpdateViewModel;

public class TicketUserUpdateViewModel : IMapFrom<Ticket>
{
	public TicketUserUpdateViewModel()
	{
		Cars = new HashSet<CarAllViewModel>();
	}

	public Guid Id { get; set; }

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual IEnumerable<CarAllViewModel> Cars { get; set; }
}
