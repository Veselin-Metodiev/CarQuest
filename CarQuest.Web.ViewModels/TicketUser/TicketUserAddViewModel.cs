namespace CarQuest.Web.ViewModels.TicketUser;

using System.ComponentModel.DataAnnotations;

using Car;

using Data.Models;

using Services.Mapping;

using static Common.EntityValidationConstants.TicketAddAndUpdateViewModel;

public class TicketUserAddViewModel : IMapTo<Ticket>
{
	public TicketUserAddViewModel()
	{
		Cars = new HashSet<CarAllViewModel>();
	}

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual IEnumerable<CarAllViewModel> Cars { get; set; }
}
