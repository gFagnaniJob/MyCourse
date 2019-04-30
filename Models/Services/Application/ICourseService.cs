using System.Collections.Generic;
using System.Threading.Tasks;
using MyCourse.Models.ViewModels;

namespace MyCourse.Models.Services.Application
{
  public interface ICourseService
  {
    Task<List<CourseViewModel>> GetCourses();
    Task<CourseDetailViewModel> GetCourse(int id);
  }
}