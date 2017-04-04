namespace VehicleManager.API.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using VehicleManager.API.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<VehicleManager.API.Data.VehicleManagerDataContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(VehicleManager.API.Data.VehicleManagerDataContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
			if (context.Customers.Count() == 0)
			{
				for (int i = 0; i < 1000; i++)
				{
					context.Customers.Add(new Models.Customer
					{
						EmailAddress = Faker.InternetFaker.Email(),
						DateOfBirth = Faker.DateTimeFaker.BirthDay(),
						FirstName = Faker.NameFaker.FirstName(),
						LastName = Faker.NameFaker.LastName(),
						Telephone = Faker.PhoneFaker.Phone()
					});
				}

				context.SaveChanges();
			}
			string[] colors = new string[]
			  {
				"Green", "White", "Red", "Hot Pink"
			  };
			string[] makers = new string[]
			  {
				"Toyota", "Nissan", "Ford", "Chevrolett"
			  };
			string[] models = new string[]
			  {
				"Standard", "Sport", "Luxury", "SportLuxury"
			  };

			if (context.Vehicles.Count() == 0)
			{
				for (int i = 0; i < 1000; i++)
				{
					context.Vehicles.Add(new Models.Vehicle
					{
						Color = colors[0],
						Make = makers[0],
						Model = models[0]
					});
				}
				context.SaveChanges();
			}
		}
	}
}

