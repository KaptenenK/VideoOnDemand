using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.DTOs
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CourseId { get; set; }
        public string Course { get; set; }
        public List<VideoDTO> Videos { get; set; }
    }

    public class SectionCreateDTO
    {
        public string Title { get; set; }

        public int CourseId { get; set; }
    }

    public class SectionEditDTO : SectionCreateDTO
    {
        public int Id { get; set; }
    }
}
