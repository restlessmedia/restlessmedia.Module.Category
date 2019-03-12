namespace restlessmedia.Module.Category
{
  public interface ICategoryService : IService
  {
    ModelCollection<CategoryEntity> List(int categoryParentId);

    CategoryEntity Read(int categoryId);

    void Save(CategoryEntity category);
    
    void Delete(int categoryId);
    
    void Move(int categoryParentId, int categoryId, MoveDirection direction);
  }
}