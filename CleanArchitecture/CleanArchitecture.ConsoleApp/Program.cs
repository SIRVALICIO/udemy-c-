
using CleanArchitecture.Data;
using CleanArchitecture.Data.Migrations;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography;

StreamerDbContext dbContext = new();
await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewStreamerWithVideo();
//await TrackingAndNotTracking();
//await QueryLinq();
///await QueryMethods();
//await AddNewRecords();
///await QueryFilter();
//QueryStreaming();
Console.WriteLine("Presione cualquier tecla para terminar el programa");
Console.ReadKey();

async Task TrackingAndNotTracking()
{
    var StreamerWithtracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x=>x.Id==1);
    var StreamerWithNotracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    StreamerWithtracking.Nombre = "Disney+";
    StreamerWithNotracking.Nombre = "Disney+";

    await dbContext!.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine(); 
    var streamers = await (from i in dbContext.Streamers where EF.Functions.Like(i.Nombre,$"%{streamerNombre}") select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id}-{streamer.Nombre}");
        
    }
}

async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;
    var firstAsync = await dbContext!.Streamers!.Where(y=>y.Nombre.Contains("a")).FirstAsync();
    var firstOrDefaultAsync = await dbContext!.Streamers!.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefault_v2 = await dbContext!.Streamers!.FirstOrDefaultAsync(y => y.Nombre.Contains("a"));

    var singleAsync = await streamer.Where(y => y.Id==1).SingleAsync();
    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();
    var resultado = await streamer.FindAsync(1);

}
async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de Streaming: ");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext!.Streamers!.Where(x=>x.Nombre.Equals(streamingNombre)).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id}-{streamer.Nombre}");
    }

    ///var streamerPartialResults = await dbContext!.Streamers!.Where(x=>x.Nombre.Contains(streamingNombre)).ToListAsync();
    var streamerPartialResults = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre,$"%{streamingNombre}%")).ToListAsync();

    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id}-{streamer.Nombre}");
    }
}
void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id}-{streamer.Nombre}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney+",
        Url = "https://www.disneyplus.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
        Nombre="Dumbo",
        StreamerId=streamer.Id
    },
    new Video
    {
        Nombre="El Rey Leon",
        StreamerId=streamer.Id
    },
    new Video
    {
        Nombre="Aladin",
        StreamerId=streamer.Id
    },
    new Video
    {
        Nombre="Frozen",
        StreamerId=streamer.Id
    }
};
    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();

}

async Task AddNewStreamerWithVideo()
{
    var pantalla = new Streamer
    {
        Nombre = "Pantalla"
    };

    var Halo = new Video
    {
        Nombre = "Halo",
        Streamer = pantalla
    };

    await dbContext.AddAsync(Halo);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{


    var Batman = new Video
    {
        Nombre = "batman",
        StreamerId=6
    };

    await dbContext.AddAsync(Batman);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor1 = new Actor
    {

        Nombre = "The Rock",
        Apellido = "Wayne"

    };
    await dbContext.AddAsync(actor1); //AddAsync mete en la base ded datos de la informacion, pero solo se compelta la transaccion cuando se establece el SaveChangeAsync()
    await dbContext.SaveChangesAsync();
    var VideoActor = new VideoActor
    {

        ActorId = actor1.Id,
        VideoId = 14

    };

    await dbContext.AddAsync(VideoActor);
    await dbContext.SaveChangesAsync();

}

async Task AddNewDirectorWithVideo()



{

    var sonic = new Video
    {
        Nombre = "Video",
        StreamerId = 8
    };

    await dbContext.AddAsync(sonic);
    await dbContext.SaveChangesAsync();


    var director1 = new Director
    {
        Nombre = "Spilver",
        Apellido = "Spilver",
        VideoId=sonic.Id
    };
    await dbContext.AddAsync(director1);
    await dbContext.SaveChangesAsync();
}

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);
    //var actor = await dbContext!.Actores!.Select(q=>q.Nombre).ToListAsync();

    /*
         var videoWithDirector = await dbContext!.Videos!.Include(q => q.Director).Select(q => new
    {
        Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
        Movie=q.Nombre
    }
    ).ToListAsync();

     
     
     */

    var videoWithDirector = await dbContext!.Videos!
        .Where(q=>q.Director!=null)
        .Include(q => q.Director).Select(q => new
    {
        Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
        Movie=q.Nombre
    }
    ).ToListAsync();

    foreach ( var movie in videoWithDirector)
    {
        Console.WriteLine($"{movie.Movie} - {movie.Director_Nombre_Completo}");
    }

}