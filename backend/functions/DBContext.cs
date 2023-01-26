using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DBContext : DbContext
{
    public DbSet<Gebruiker> gebruikers{ get; set; }
    public DbSet<Artiest> artiesten { get; set; }
    public DbSet<Band> bands { get; set; }
    public DbSet<Donateur> donateurs { get; set; }
    public DbSet<Huren> reserveringen { get; set; }
    public DbSet<Leden> leden { get; set; }
    public DbSet<Ruimte> ruimtes { get; set; }
    public DbSet<Zaal> zalen { get; set; }
    public DbSet<Ticket> tickets { get; set; }
    public DbSet<Show> shows { get; set; }
    public DbSet<Stoelrij> stoelrijen {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder builder) {
    builder.UseSqlite($"Data Source=database.db");
    builder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Gebruiker>().HasData(
            new Gebruiker(){ Email = "test2@email.com",Username="Jan2",Naam = "Jan2", Wachtwoord = "Test2", UserID = 2, rol = new Role(){roleid=1}},
            new Gebruiker(){ Email = "test3@email.com",Username="Jan3",Naam = "Jan3", Wachtwoord = "Test3", UserID = 3, rol = new Role(){roleid=1}},
            new Gebruiker(){ Email = "test4@email.com",Username="Jan4",Naam = "Jan4", Wachtwoord = "Test4", UserID = 4, rol = new Role(){roleid=1}}
        );
        builder.Entity<Artiest>().HasData(
            new Artiest(){Email = "artiestmail1@email.com", Username="Artiest1", Naam = "Artiest1", Wachtwoord = "Test1", artiest_naam = "Artiest1", UserID = 5, rol = new Role(){roleid=2}},
            new Artiest(){Email = "artiestmail2@email.com", Username="Artiest2", Naam = "Artiest2", Wachtwoord = "Test2", artiest_naam = "Artiest2", UserID = 6, rol = new Role(){roleid=2}},
            new Artiest(){Email = "artiestmail3@email.com", Username="Artiest3", Naam = "Artiest3", Wachtwoord = "Test3", artiest_naam = "Artiest3", UserID = 7, rol = new Role(){roleid=2}},
            new Artiest(){Email = "artiestmail4@email.com", Username="Artiest4", Naam = "Artiest4", Wachtwoord = "Test4", artiest_naam = "Artiest4", UserID = 8, rol = new Role(){roleid=2}},
            new Artiest(){Email = "artiestmail5@email.com", Username="Artiest5", Naam = "Artiest5", Wachtwoord = "Test5", artiest_naam = "Artiest5", UserID = 9, rol = new Role(){roleid=2}}
        );

        builder.Entity<Donateur>().HasData(
            new Donateur(){Email = "test1@email.com",Username="Jan1",Naam = "Jan1", Wachtwoord = "Test1",TotaleDonatie = 1000, UserID = 1, rol = new Role(){roleid=3}}
        );
        builder.Entity<Stoelrij>().HasData(
            new Stoelrij(){Rangnummer=1,Aantal_stoelen=20,  rijid=11, Zaalnr=1},
            new Stoelrij(){Rangnummer=2,Aantal_stoelen=100, rijid=12, Zaalnr=1},
            new Stoelrij(){Rangnummer=3,Aantal_stoelen=120, rijid=13, Zaalnr=1},
            new Stoelrij(){Rangnummer=1,Aantal_stoelen=2,   rijid=21, Zaalnr=2},
            new Stoelrij(){Rangnummer=2,Aantal_stoelen=160, rijid=22,Zaalnr=2},
            new Stoelrij(){Rangnummer=1,Aantal_stoelen=10,  rijid=31, Zaalnr=3},
            new Stoelrij(){Rangnummer=2,Aantal_stoelen=80,  rijid=32, Zaalnr=3},
            new Stoelrij(){Rangnummer=1,Aantal_stoelen=40,  rijid=41, Zaalnr=4},
            new Stoelrij(){Rangnummer=2,Aantal_stoelen=200, rijid=42, Zaalnr=4},
            new Stoelrij(){Rangnummer=3,Aantal_stoelen=200, rijid=43, Zaalnr=4}
        );

        builder.Entity<Zaal>().HasData(
            new Zaal(){
                Zaalnr=1,
                Naam="Zaal 1",
                Aantal_stoelen=240,
            },
            new Zaal(){
                Zaalnr=2,
                Naam="Zaal 2",
                Aantal_stoelen=180,
            },
            new Zaal(){
                Zaalnr=3,
                Naam="Zaal 3",
                Aantal_stoelen=90
            },
            new Zaal(){
                Zaalnr=4,
                Naam="Zaal 4",
                Aantal_stoelen=440,
            }
        );

        builder.Entity<Ruimte>().HasData(
            new Ruimte(){RuimteNr=1 ,Naam="Ruimte 1" , Capaciteit=30},
            new Ruimte(){RuimteNr=2 ,Naam="Ruimte 2" , Capaciteit=30},
            new Ruimte(){RuimteNr=3 ,Naam="Ruimte 3" , Capaciteit=30},
            new Ruimte(){RuimteNr=4 ,Naam="Ruimte 4" , Capaciteit=30},
            new Ruimte(){RuimteNr=5 ,Naam="Ruimte 5" , Capaciteit=30},
            new Ruimte(){RuimteNr=6 ,Naam="Ruimte 6" , Capaciteit=30},
            new Ruimte(){RuimteNr=7 ,Naam="Ruimte 7" , Capaciteit=30},
            new Ruimte(){RuimteNr=8 ,Naam="Ruimte 8" , Capaciteit=30},
            new Ruimte(){RuimteNr=9 ,Naam="Ruimte 9" , Capaciteit=30},
            new Ruimte(){RuimteNr=10,Naam="Ruimte 10", Capaciteit=30}
        );

        builder.Entity<Show>().HasData(
            new Show(){Shownr = 1, Naam = "Show 1", BeginTijd = DateTime.Now, EindTijd = DateTime.Now, zaal = "zaal 1", Genre = "Horor", Afbeelding = "", Leeftijdsgroep = "18"},
            new Show(){Shownr = 2, Naam = "Show 2", BeginTijd = DateTime.Now, EindTijd = DateTime.Now, zaal = "zaal 2", Genre = "Horor", Afbeelding = "", Leeftijdsgroep = "18"},
            new Show(){Shownr = 3, Naam = "Show 3", BeginTijd = DateTime.Now, EindTijd = DateTime.Now, zaal = "zaal 3", Genre = "Horor", Afbeelding = "", Leeftijdsgroep = "18"}  
        );

        // builder.Entity<Role>().HasData(new Role(){Name = "Medewerker", NormalizedName = "MEDEWERKER"});
        // builder.Entity<Role>().HasData(new Role(){Name = "Gebruiker", NormalizedName = "GEBRUIKER"});
        // builder.Entity<Role>().HasData(new Role(){Name = "Artiest", NormalizedName = "ARTIEST"});
        // builder.Entity<Role>().HasData(new Role(){Name = "Donateur", NormalizedName = "DONATEUR"});

        //TODO: voor lucas gebruik week 6 van je portfolio
    }
}