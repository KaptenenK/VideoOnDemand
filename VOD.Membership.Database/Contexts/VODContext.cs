using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOD.Membership.Database.Entities;

namespace VOD.Membership.Database.Contexts;

public class VODContext : DbContext
{

    
    public VODContext(DbContextOptions<VODContext> options) :base(options)
	{
        
    }

    //Vi overridar Cascading delete. Default när en rad i en tabell är raderad, alla rader även i relaterade tabeller som har Foreign key contrains blir raderade.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }


    // dbset entities
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Video> Videos => Set<Video>();
}
