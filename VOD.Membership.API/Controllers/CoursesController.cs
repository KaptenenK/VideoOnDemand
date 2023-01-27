using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Migrations;

namespace VOD.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IDbService _db;

        public CoursesController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get(bool freeOnly)
        {
            try
            {
                _db.Include<Instructor>();
                List<CourseDTO>? courses;
                if (freeOnly)
                {
                    courses = await _db.GetAsync<Course, CourseDTO>(c => c.Free.Equals(freeOnly));
                }
                else
                {
                    courses = await _db.GetAsync<Course, CourseDTO>();
                }

                return Results.Ok(courses);
            }
            catch
            {
            }

            return Results.NotFound();
        }


        [HttpGet("{id}")]

        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Instructor>();
                _db.Include<Section>();
                _db.Include<Video>();

                var course = await _db.SingleAsync<Course, CourseDTO>(c => c.Id.Equals(id));
                return Results.Ok(course);
            }

            catch
            {

            }
            return Results.NotFound();
        }


        //EJ RIKTIG NÖJD FRÅGA JONAS
        [HttpPost]

        public async Task<IResult> Post([FromBody] CourseCreateDTO dto)
        {
            try
            {
                if (dto == null)
                {

                    return Results.BadRequest();
                }

                var course = await _db.AddAsync<Course, CourseCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }
                //vad händer här?

                return Results.Created(_db.GetURI<Course>(course), course);
            }

            catch
            {

            }

            return Results.BadRequest();
        }


        //funkar inte att uppdatera.
        [HttpPut("{id}")]

        public async Task<IResult> Put(int id, [FromBody] CourseEditDTO dto)
        {
            try
            {
                if (dto == null )
                {
                    return Results.BadRequest();
                }

                if (!id.Equals(dto.Id))
                {
                    return Results.BadRequest();
                }

                var finns = await _db.AnyAsync<Instructor>(i => i.Id.Equals(dto.InstructorId));
                if (!finns)
                {
                    return Results.NotFound();
                }
                finns = await _db.AnyAsync<Course>(i => i.Id.Equals(id));
                if (!finns)
                {
                    return Results.NotFound();
                }

                _db.Update<Course, CourseEditDTO>(dto.Id, dto);

                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }

                return Results.NoContent();

            }

            catch
            {

            }
            return Results.BadRequest();
        }

        [HttpDelete("{id}")]

        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success = await _db.DeleteAsync<Course>(id);
                if (!success)
                {
                    return Results.NotFound();
                }

                success = await _db.SaveChangesAsync();
                if(!success)
                {
                    return Results.BadRequest();
                }
                return Results.NoContent();
            }

            catch
            {

            }
            return Results.BadRequest();
        }


    }
}
