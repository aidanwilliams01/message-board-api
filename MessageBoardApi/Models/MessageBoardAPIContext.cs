using Microsoft.EntityFrameworkCore;

namespace MessageBoardApi.Models
{
  public class MessageBoardApiContext : DbContext
  {
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }

    public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
              .HasData(
                new Message { MessageId = 1 },
                new Message { MessageId = 2, Text = "example text", Group = "Group 1", MessageDateTime = DateTime.Parse("2/26/2024") },
                new Message { MessageId = 3, Text = "example text", Group = "Group 2", MessageDateTime = DateTime.Parse("2/26/2023") },
                new Message { MessageId = 4, Text = "example text", Group = "Group 3", MessageDateTime = DateTime.Parse("2/26/2022") }
                // new Animal { AnimalId = 2, Name = "Rexie", Species = "Dinosaur", Age = 10 },
                // new Animal { AnimalId = 3, Name = "Matilda", Species = "Dinosaur", Age = 2 },
                // new Animal { AnimalId = 4, Name = "Pip", Species = "Shark", Age = 4 },
                // new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22 }
              );

              builder.Entity<Group>()
                .HasData(
                  new Group { GroupId = 1, Name = "Group 1" },
                  new Group { GroupId = 2, Name = "Group 2" },
                  new Group { GroupId = 3, Name = "Group 3" }
                );
        }
    }
}