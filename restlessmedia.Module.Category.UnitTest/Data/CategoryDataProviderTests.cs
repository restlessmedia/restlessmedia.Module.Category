using FakeItEasy;
using restlessmedia.Module.Category.Data;
using restlessmedia.Module.Data;
using SqlBuilder.DataServices;
using System;
using System.Data;
using System.Dynamic;
using Xunit;

namespace restlessmedia.Module.Category.UnitTest.Data
{
  public class CategoryDataProviderTests
  {
    public CategoryDataProviderTests()
    {
      IDataContext dataContext = A.Fake<IDataContext>();
      _modelDataService = A.Fake<IModelDataService<Category.Data.DataModel.VCategory>>();
      _categoryDataProvider = new CategoryDataProvider(dataContext, _modelDataService);
    }

    [Fact]
    public void testing_read()
    {
      dynamic result = new ExpandoObject();

      A.CallTo(() => _modelDataService.DataProvider.Query<object>(A<string>.Ignored, A<object>.Ignored, A<CommandType>.Ignored, A<Action<IDbConnection>>.Ignored))
        .Returns(new object[] { result });

      CategoryEntity category = _categoryDataProvider.Read(1);
    }

    private readonly CategoryDataProvider _categoryDataProvider;

    private readonly IModelDataService<Category.Data.DataModel.VCategory> _modelDataService;
  }
}
