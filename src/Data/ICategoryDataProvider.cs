using restlessmedia.Module.Data;

namespace restlessmedia.Module.Category.Data
{
  public interface ICategoryDataProvider : IDataProvider
  {
    ModelCollection<CategoryEntity> List(int categoryParentId);

    CategoryEntity Read(int categoryId);

    void Save(CategoryEntity category);

    void Delete(int categoryId);

    bool Delete(int categoryId, out CategoryEntity category);
  }
}