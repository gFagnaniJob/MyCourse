using System;
using System.Data;

namespace MyCourse.Models.Services.Infrastructure
{
  public interface IDatabaseAccessor
  {
    DataSet Query(FormattableString query);
  }
}