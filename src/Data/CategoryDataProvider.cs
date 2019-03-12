using restlessmedia.Module.Data;

namespace restlessmedia.Module.Category.Data
{
  public class CategoryDataProvider : CategorySqlDataProvider, ICategoryDataProvider
  {
    public CategoryDataProvider(IDataContext context)
      : base(context) { }
  }
}