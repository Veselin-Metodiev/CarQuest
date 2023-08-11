namespace CarQuest.Services.Tests;

using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;

using static DataSeeder;

public class MechanicServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private IMechanicService mechanicService;

	[OneTimeSetUp]
	public void OneTimeSetup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		mechanicService = new MechanicService(context);
	}

	[Test]
	public async Task MechanicExistByUserIdShouldReturnTrueWhenExists()
	{
		bool exists = await mechanicService.MechanicExistsByUserIdAsync(MechanicUser.Id);

		Assert.True(exists);
	}

	[Test]
	public async Task MechanicExistByUserIdShouldReturnFalseWhenNotExists()
	{
		bool exists = await mechanicService.MechanicExistsByUserIdAsync(User.Id);

		Assert.False(exists);
	}

	[Test]
	public 
}