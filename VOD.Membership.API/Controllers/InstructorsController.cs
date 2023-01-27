using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VOD.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IDbService _db;

        public InstructorsController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<InstructorDTO>? instructors = await _db.GetAsync<Instructor, InstructorDTO>();

                return Results.Ok(instructors);
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
                var instructor = await _db.SingleAsync<Instructor, InstructorDTO>(c => c.Id.Equals(id));
                if (instructor is null) return Results.NotFound();

                return Results.Ok(instructor);
            }
            catch
            {
            }
            return Results.NotFound();
        }


        //EJ RIKTIG NÖJD FRÅGA JONAS
        [HttpPost]

        public async Task<IResult> Post([FromBody] InstructorDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var instructor = await _db.AddAsync<Instructor, InstructorDTO>(dto);

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Instructor>(instructor), instructor);
            }
            catch
            {
            }

            return Results.BadRequest();
        }


        //funkar inte att uppdatera.
        [HttpPut("{id}")]

        public async Task<IResult> Put(int id, [FromBody] InstructorDTO dto)
        {
            try
            {
                if (dto == null )
                {
                    return Results.BadRequest("Ingen entitiy angiven");
                }

                if (!id.Equals(dto.Id))
                {
                    return Results.BadRequest("Id:n stämmer ej överrens");
                }

                var finns = await _db.AnyAsync<Instructor>(c => c.Id.Equals(id));
                if (!finns)
                {
                    return Results.NotFound();
                }
                
                if (!finns)
                {
                    return Results.NotFound();
                }

                _db.Update<Instructor, InstructorDTO>(dto.Id, dto);

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
                var success = await _db.DeleteAsync<Instructor>(id);

                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {
            }

            return Results.BadRequest();
        }
    }
    }

