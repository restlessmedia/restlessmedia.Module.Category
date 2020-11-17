using Dapper;
using restlessmedia.Module.Data;
using restlessmedia.Module.Data.Sql;
using restlessmedia.Module.File;
using SqlBuilder;
using SqlBuilder.DataServices;
using System;
using System.Data;
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
      return Query((connection) =>
      {
        return new ModelCollection<CategoryEntity>(connection.Query<CategoryEntity, FileEntity, CategoryEntity>("dbo.SPListCategories", (category, file) => { category.Thumb = file; return category; }, new { categoryParentId }, commandType: CommandType.StoredProcedure, splitOn: "TargetEntityId"));
      });
    }

    public CategoryEntity Read(int categoryId)
    {
      using (IGridReader reader = QueryMultiple("dbo.SPReadCategory", new { categoryId }))
      {
        CategoryEntity category = reader.Read<CategoryEntity>().SingleOrDefault();
        category.Thumb = reader.Read<FileEntity>().FirstOrDefault();
        return category;
      }
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