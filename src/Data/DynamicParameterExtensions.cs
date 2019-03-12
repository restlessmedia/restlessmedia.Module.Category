using restlessmedia.Module.Category;
using System.Data;

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
      AddId(parameters, "categoryId", category.CategoryId);
    }

    public static void AddId(this DynamicParameters parameters, string name, int? value)
    {
      parameters.Add(name, value, DbType.Int32, ParameterDirection.InputOutput, 4);
    }
  }
}