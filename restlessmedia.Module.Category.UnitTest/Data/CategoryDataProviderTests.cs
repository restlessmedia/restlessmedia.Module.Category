using FakeItEasy;
using restlessmedia.Module.Category.Data;
using restlessmedia.Module.Data;
using SqlBuilder.DataServices;
using System;
using System.Data;
using Xunit;

namespace restlessmedia.Module.Category.UnitTest.Data
{
  public class CategoryDataProviderTests
  {
    [Fact(Skip = "Not working")]
    public void asdsad()
    {
      CategoryDataProvider categoryDataProvider = CreateInstance(out IModelDataService<Category.Data.DataModel.VCategory> modelDataService);
      object result = new object();

      A.CallTo(() => modelDataService.DataProvider.Query<object>(A<string>.Ignored, A<object>.Ignored, A<CommandType>.Ignored, A<Action<IDbConnection>>.Ignored)).Returns(new object[] { result });

      categoryDataProvider.Read(1);
    }

    private CategoryDataProvider CreateInstance(out IModelDataService<Category.Data.DataModel.VCategory> modelDataService)
    {
      IDataContext dataContext = A.Fake<IDataContext>();
      modelDataService = A.Fake<IModelDataService<Category.Data.DataModel.VCategory>>();
      CategoryDataProvider categoryDataProvider = new CategoryDataProvider(dataContext, modelDataService);
      return categoryDataProvider;
    }
  }
}
