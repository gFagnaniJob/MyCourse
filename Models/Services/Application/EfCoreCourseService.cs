using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCourse.Models.Services.Infrastructure;
using MyCourse.Models.ViewModels;

namespace MyCourse.Models.Services.Application
{
  public class EfCoreCourseService : ICourseService
  {
    private readonly MyCourseDbContext dbContext;

    public EfCoreCourseService(MyCourseDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public async Task<CourseDetailViewModel> GetCourseAsync(int id)
    {
      IQueryable<CourseDetailViewModel> queryLinq = dbContext.Courses
          .Where(course => course.Id == id)
          .Select(course => new CourseDetailViewModel
          {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Author = course.Author,
            ImagePath = course.ImagePath,
            Rating = course.Rating,
            CurrentPrice = course.CurrentPrice,
            FullPrice = course.FullPrice,
            Lessons = course.Lessons.Select(lesson => new LessonViewModel
            {
              Id = lesson.Id,
              Title = lesson.Title,
              Description = lesson.Description,
              Duration = lesson.Duration
            }).ToList()
          })
          .AsNoTracking();
      CourseDetailViewModel courseDetailViewModel = await queryLinq.SingleAsync(); //Restituisce il primo elemento dell'elenco, ma se l'elenco ne contiene 0 o più di 1 solleva un'eccezione
      //.FirstAsync() //Restituisce il primo elemento, ma se l'elenco è vuoto solleva un'eccezione
      //.SingleOrDefaultAsync() //Tollera il fatto che l'elenco sia vuoto e in quel caso resitutisce il valore di default
      //.FirstOrDefaultAsync() //Tollera il fatto che l'elenco sia vuoto
      return courseDetailViewModel;
    }

    public async Task<List<CourseViewModel>> GetCoursesAsync()
    {
      IQueryable<CourseViewModel> queryLinq = dbContext.Courses
          .Select(course =>
              new CourseViewModel {
                  Id = course.Id,
                  Title = course.Title,
                  ImagePath = course.ImagePath,
                  Author = course.Author,
                  Rating = course.Rating,
                  CurrentPrice = course.CurrentPrice,
                  FullPrice = course.FullPrice
              })
          .AsNoTracking();
      List<CourseViewModel> courses = await queryLinq.ToListAsync();
      return courses;
    }
  }
}