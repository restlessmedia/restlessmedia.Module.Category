using restlessmedia.Module.Category;
using restlessmedia.Module.Data;

namespace Dapper
{
  public static class DynamicParameterExtensions
  {
    public static void Add(this DynamicParameters parameters, CategoryEntity category)
    {
      parameters.Add("title", category.Title);
      parameters.Add("description", category.Description);
      parameters.Add("categoryParentId", category.CategoryParentId);
      parameters.Add("rank", category.Rank);
      parameters.AddId("categoryId", category.CategoryId);
    }
  }
}