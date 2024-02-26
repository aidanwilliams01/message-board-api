using Microsoft.EntityFrameworkCore;

namespace MessageBoardApi.Models
{
  public class MessageBoardApiContext : DbContext
  {
    public DbSet<Message> Messages { get; set; }

    public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
              .HasData(
                new Message { MessageId = 1 }
                // new Animal { AnimalId = 2, Name = "Rexie", Species = "Dinosaur", Age = 10 },
                // new Animal { AnimalId = 3, Name = "Matilda", Species = "Dinosaur", Age = 2 },
                // new Animal { AnimalId = 4, Name = "Pip", Species = "Shark", Age = 4 },
                // new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22 }
              );
        }
    }
}