using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.DTOs;
public class CourseDTO
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string MarqueeImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Free { get; set; }

    public int InstructorId { get; set; }

    //Navigation properties
    public InstructorDTO Instructor { get; set; } = new();
    public List<SectionDTO> Sections { get; set; } = new();
}


//Användning av CourseDTO kan leda till återlöpande loops och leder till API CRASH!! därför använder vi oss av en ny DTO CourseCreateDTO
//Vi tar bort Navigation properties från CourseDTO och kopierar in det in i CourseCreateDTO
public class CourseCreateDTO
{
    public string ImageUrl { get; set; }
    public string MarqueeImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Free { get; set; }

    public int InstructorId { get; set; }
}


//Kopierar CourseCreateDTO 
public class CourseEditDTO : CourseCreateDTO
{
    public int Id { get; set; }
}