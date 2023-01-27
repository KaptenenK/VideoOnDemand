using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VOD.Common.DTOs;
using VOD.Membership.Database.Services;

namespace VOD.Membership.Database.Extensions
{
    public static class VODContextExtensions
    {
        public static async Task SeedMembershipData(this IDbService service)
        {

            var description = "If you're visiting this page, you're likely here because you're searching for a random sentence. " +
                "Sometimes a random word just isn't enough, and that is where the random sentence generator comes into play";

            try
            {
                //lägg till instructors
                await service.AddAsync<Instructor, InstructorDTO>(new InstructorDTO
                {
                    Name = "John Doe",
                    Description = description,
                    Avatar = "/images/Ice-Age-Scrat-icon.png"
                });
                await service.AddAsync<Instructor, InstructorDTO>(new InstructorDTO
                {
                    Name = "Jane Doe",
                    Description = description,
                    Avatar = "/images/Ice-Age-Scrat-icon.png"
                });
                    await service.SaveChangesAsync();

                //Lägg till Courses
                //-----------------------------------------------------------------------------------------------------
                var instructor1 = await service.SingleAsync<Instructor, InstructorDTO>(c => c.Name.Equals("John Doe"));

                var instructor2 = await service.SingleAsync<Instructor, InstructorDTO>(c => c.Name.Equals("Jane Doe"));

                await service.AddAsync<Course, CourseDTO>(new CourseDTO
                 {
                  InstructorId = instructor1.Id,
                  Title = "Course 1",
                  Description = description,
                  ImageUrl = "/images/course1.jpg",
                  MarqueeImageUrl = "/images/laptop.jpg"
                });
                await service.AddAsync<Course, CourseDTO>(new CourseDTO
                {
                    InstructorId = instructor2.Id,
                    Title = "Course 2",
                    Description = description,
                    ImageUrl = "/images/course1.jpg",
                    MarqueeImageUrl = "/images/laptop.jpg",
                    Free = true
                });
                await service.AddAsync<Course, CourseDTO>(new CourseDTO
                {
                    InstructorId = instructor1.Id,
                    Title = "Course 3",
                    Description = description,
                    ImageUrl = "/images/course1.jpg",
                    MarqueeImageUrl = "/images/laptop.jpg"
                });
                await service.SaveChangesAsync();

                //lägg till Section
                //_-----------------------------------------------------------------------------------------------

                var course1 = await service.SingleAsync<Course, CourseDTO>(c => c.Title.Equals("Course 1"));
                var course2 = await service.SingleAsync<Course, CourseDTO>(c => c.Title.Equals("Course 2"));
                var course3 = await service.SingleAsync<Course, CourseDTO>(c => c.Title.Equals("Course 3"));

                await service.AddAsync<Section, SectionDTO>(new SectionDTO
                {
                    CourseId = course1.Id,
                    Title = "Section 1"
                });
                await service.AddAsync<Section, SectionDTO>(new SectionDTO
                {
                    CourseId = course2.Id,
                    Title = "Section 2"
                });
                await service.AddAsync<Section, SectionDTO>(new SectionDTO
                {
                    CourseId = course3.Id,
                    Title = "Section 3"
                });
                await service.SaveChangesAsync();

                //lägg till Video
                //-----------------------------------------------------------------------------------------------

                var section1 = await service.SingleAsync<Section, SectionDTO>(c => c.Title.Equals("Section 1"));
                var section2 = await service.SingleAsync<Section, SectionDTO>(c => c.Title.Equals("Section 2"));
                var section3 = await service.SingleAsync<Section, SectionDTO>(c => c.Title.Equals("Section 3"));

                await service.AddAsync<Video, VideoDTO>(new VideoDTO
                {
                    SectionId = section1.Id,
                    Title = "Video 1 Title",
                    Description = description,
                    Duration = 50,
                    Thumbnail = "/images/video1.jpg",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                });
                await service.AddAsync<Video, VideoDTO>(new VideoDTO
                {
                    SectionId = section1.Id,
                    Title = "Video 2 Title",
                    Description = description,
                    Duration = 50,
                    Thumbnail = "/images/video2.jpg",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                });
                await service.AddAsync<Video, VideoDTO>(new VideoDTO
                {
                    SectionId = section3.Id,
                    Title = "Video 3 Title",
                    Description = description,
                    Duration = 50,
                    Thumbnail = "/images/video3.jpg",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                });
                await service.AddAsync<Video, VideoDTO>(new VideoDTO
                {
                    SectionId = section2.Id,
                    Title = "Video 4 Title",
                    Description = description,
                    Duration = 50,
                    Thumbnail = "/images/video4.jpg",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                });
                await service.AddAsync<Video, VideoDTO>(new VideoDTO
                {
                    SectionId = section1.Id,
                    Title = "Video 5 Title",
                    Description = description,
                    Duration = 50,
                    Thumbnail = "/images/video5.jpg",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                });
                await service.SaveChangesAsync();
            }

            catch(Exception ex) 
            {
                throw;
            }


        }
    }
}
