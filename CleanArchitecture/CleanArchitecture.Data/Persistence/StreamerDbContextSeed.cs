using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers.Any())
            {
                context.Streamers.AddRange(GetPreconfiguredStreamer());
                context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}",typeof(StreamerDbContext).Name);
            }



        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {

                new Streamer
                {
                    CreateBy="Alguien",
                    Nombre="Hbo Al revez",
                    Url="https://HBOAlRevez.com"

                },

                new Streamer
                {
                    CreateBy="Lucho",
                    Nombre="Amazonuc",
                    Url="https://Amazonuc.com"

                }



            };


        }


    }
}
