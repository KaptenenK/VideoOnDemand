global using VOD.Membership.Database.Contexts;
global using VOD.Common.DTOs;
global using VOD.Membership.Database.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(policy => {
policy.AddPolicy("CorsAllAccessPolicy", opt =>
opt.AllowAnyOrigin()
.AllowAnyHeader()
 .AllowAnyMethod()
 );
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<VODContext>(
options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("VODConnection")));

ConfigureAutomapper();

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsAllAccessPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureAutomapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Video, VideoDTO>().ReverseMap();

    cfg.CreateMap<Instructor, InstructorDTO>()
    .ReverseMap()
    .ForMember(dest => dest.Courses, src => src.Ignore());

    cfg.CreateMap<Course, CourseDTO>()
       .ReverseMap()
       // Only needed for seeding data.
       .ForMember(dest => dest.Instructor, src => src.Ignore());

    cfg.CreateMap<CourseEditDTO, Course>()
        .ForMember(dest => dest.Instructor, src => src.Ignore())
        .ForMember(dest => dest.Sections, src => src.Ignore());

    cfg.CreateMap<CourseCreateDTO, Course>()
        .ForMember(dest => dest.Instructor, src => src.Ignore())
        .ForMember(dest => dest.Sections, src => src.Ignore());

    cfg.CreateMap<VideoEditDTO, Video>();
    cfg.CreateMap<VideoCreateDTO, Video>();

    cfg.CreateMap<SectionEditDTO, Section>();
    cfg.CreateMap<SectionCreateDTO, Section>();

    cfg.CreateMap<Section, SectionDTO>()
        .ForMember(dest => dest.Course, src => src.MapFrom(s => s.Course.Title))
        .ReverseMap()
        .ForMember(dest => dest.Course, src => src.Ignore());
});
    var mapper = config.CreateMapper();
        builder.Services.AddSingleton(mapper);
}
