using restlessmedia.Module.Data;
using SqlBuilder.DataServices;

namespace restlessmedia.Module.Category.Data
{
  public class CategoryDataProvider : CategorySqlDataProvider, ICategoryDataProvider
  {
    public CategoryDataProvider(IDataContext context, IModelDataService<DataModel.VCategory> modelDataService)
      : base(context, modelDataService) { }
  }
}