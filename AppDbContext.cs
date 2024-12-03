using BlazorAuthPolicy.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthPolicy.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
		{
		}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserAccount>()
				.HasIndex(u => u.UserName)
				.IsUnique();

            var demoUserAccounts = new UserAccount[]
			{
				new UserAccount { Id = 1, UserName = "user1" , Password = "user1", Role = "Customer" },
				new UserAccount { Id = 2, UserName = "user2" , Password = "user2" , Role = "Manager"},
				new UserAccount { Id = 3, UserName = "user3" , Password = "user3", Role = "Manager" },
				new UserAccount { Id = 4, UserName = "user4" , Password = "user4" , Role = "Customer"},
				new UserAccount { Id = 5, UserName = "user5" , Password = "user5" , Role = "Admin"},
			};
			modelBuilder.Entity<UserAccount>().HasData(demoUserAccounts);

			var demoUserAccountPolicies = new UserAccountPolicy[]
			{
                //user 1 policy

                new UserAccountPolicy { Id = 1, UserAccountId = 1, UserPolicy = UserPolicy.VIEW_EVENT.ToString(), IsEnable = false },
				new UserAccountPolicy { Id = 2, UserAccountId = 1, UserPolicy = UserPolicy.ADD_EVENT.ToString(), IsEnable = false },
				new UserAccountPolicy { Id = 3, UserAccountId = 1, UserPolicy = UserPolicy.EDIT_EVENT.ToString(), IsEnable = false },
				new UserAccountPolicy { Id = 4, UserAccountId = 1, UserPolicy = UserPolicy.DELETE_EVENT.ToString(), IsEnable = false },

                //user 2 policy

                new UserAccountPolicy { Id = 5, UserAccountId = 2, UserPolicy = UserPolicy.VIEW_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 6, UserAccountId = 2, UserPolicy = UserPolicy.ADD_EVENT.ToString(), IsEnable = false },
				new UserAccountPolicy { Id = 7, UserAccountId = 2, UserPolicy = UserPolicy.EDIT_EVENT.ToString(), IsEnable = false },
				new UserAccountPolicy { Id = 8, UserAccountId = 2, UserPolicy = UserPolicy.DELETE_EVENT.ToString(), IsEnable = false },

                //user 3 policy

                new UserAccountPolicy { Id = 9, UserAccountId = 3, UserPolicy = UserPolicy.VIEW_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 10, UserAccountId = 3, UserPolicy = UserPolicy.ADD_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 11, UserAccountId = 3, UserPolicy = UserPolicy.EDIT_EVENT.ToString(), IsEnable = false },
				new UserAccountPolicy { Id = 12, UserAccountId = 3, UserPolicy = UserPolicy.DELETE_EVENT.ToString(), IsEnable = false },

                //user 4 policy

                new UserAccountPolicy { Id = 13, UserAccountId = 4, UserPolicy = UserPolicy.VIEW_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 14, UserAccountId = 4, UserPolicy = UserPolicy.ADD_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 15, UserAccountId = 4, UserPolicy = UserPolicy.EDIT_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 16, UserAccountId = 4, UserPolicy = UserPolicy.DELETE_EVENT.ToString(), IsEnable = false },

                //user 5 policy

                new UserAccountPolicy { Id = 17, UserAccountId = 5, UserPolicy = UserPolicy.VIEW_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 18, UserAccountId = 5, UserPolicy = UserPolicy.ADD_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 19, UserAccountId = 5, UserPolicy = UserPolicy.EDIT_EVENT.ToString(), IsEnable = true },
				new UserAccountPolicy { Id = 20, UserAccountId = 5, UserPolicy = UserPolicy.DELETE_EVENT.ToString(), IsEnable = true }

			};
			modelBuilder.Entity<UserAccountPolicy>().HasData(demoUserAccountPolicies);
		}
		public DbSet<UserAccount> UserAccounts { get; set; }
		public DbSet<UserAccountPolicy> UserAccountPolicies { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<EventCategory> EventCategories { get; set; }
	}
}
