namespace CarQuest.Web.ViewModels.Ticket;

using System.ComponentModel.DataAnnotations;

using Car;

using Data.Models;

using Services.Mapping;

using static Common.EntityValidationConstants.TicketAddAndUpdateViewModel;

public class TicketAddAndUpdateViewModel : IMapTo<Ticket>
{
	public Guid Id { get; set; }

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual IEnumerable<CarAllViewModel> Cars { get; set; } = null!;
}
