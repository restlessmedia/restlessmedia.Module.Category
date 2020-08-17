using Dapper;
using FastMapper;
using restlessmedia.Module.Configuration;
using restlessmedia.Module.Data;
using restlessmedia.Module.Data.Sql;
using restlessmedia.Module.File;
using SqlBuilder;
using SqlBuilder.DataServices;
using System;
using System.Dynamic;
using System.Linq;

namespace restlessmedia.Module.Category.Data
{
  public abstract class CategorySqlDataProvider : SqlDataProviderBase
  {
    public CategorySqlDataProvider(IDataContext context, IModelDataService<DataModel.VCategory> modelDataService)
      : base(context)
    {
      _modelDataService = modelDataService ?? throw new ArgumentNullException(nameof(modelDataService));
    }

    public ModelCollection<CategoryEntity> List(int categoryParentId)
    {
      Select<DataModel.VCategory> select = _modelDataService.DataProvider.NewSelect();
      select.Where(x => x.CategoryParentId, categoryParentId);
      DataPage<dynamic> dataPage = _modelDataService.DataProvider.QueryPage<dynamic>(select, connection => select.WithLicenseId(connection, DataContext.LicenseSettings));
      return new ModelCollection<CategoryEntity>(ObjectMapper.MapAll<CategoryEntity>(dataPage.Data), dataPage.Count);
    }

    public CategoryEntity Read(int categoryId)
    {
      Select<DataModel.VCategory> select = _modelDataService.DataProvider.NewSelect();
      select.Where(x => x.CategoryId, categoryId);
      IDynamicMetaObjectProvider dynamicCategory = _modelDataService.DataProvider.QueryDynamic(select, connection => select.WithLicenseId(connection, DataContext.LicenseSettings)).FirstOrDefault();
      return ObjectMapper.Map<IDynamicMetaObjectProvider, CategoryEntity>(dynamicCategory, config =>
      {
        config.For(x => x.Thumb).ResolveWith<FileEntity>();
      });
    }

    public void Save(CategoryEntity category)
    {
      const string commandName = "dbo.SPSaveCategory";
      DynamicParameters parameters = new DynamicParameters();
      parameters.Add(category);
      Execute(commandName, parameters);
      category.CategoryId = parameters.Get<int>("categoryId");
    }

    public void Delete(int categoryId)
    {
      //Delete<DataModel.VCategory> delete = new Delete<DataModel.VCategory>(categoryId);
      //_modelDataService.DataProvider.Execute(delete);

      Execute("dbo.SPDeleteCategory", new { categoryId });
    }

    public bool Delete(int categoryId, out CategoryEntity category)
    {
      category = Read(categoryId);
      bool exists = category != null;

      if (exists)
      {
        Delete(categoryId);
      }

      return exists;
    }

    private readonly IModelDataService<DataModel.VCategory> _modelDataService;
  }
}