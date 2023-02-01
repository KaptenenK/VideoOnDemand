using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.Services
{
    public interface IMembershipService
    {
        Task<CourseDTO> GetCourseAsync(int? id);
        Task<List<CourseDTO>> GetCoursesAsync();
        Task<VideoDTO> GetVideoAsync(int? id);
    }
}
