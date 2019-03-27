using restlessmedia.Module.Category.Data;
using restlessmedia.Module.File;
using System;

namespace restlessmedia.Module.Category
{
  internal sealed class CategoryService : ICategoryService
  {
    public CategoryService(IEntityService entityService, IFileService fileService, ICategoryDataProvider categoryDataProvider, ICacheProvider cacheProvider)
      : base()
    {
      _entityService = entityService ?? throw new ArgumentNullException(nameof(entityService));
      _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
      _categoryDataProvider = categoryDataProvider ?? throw new ArgumentNullException(nameof(categoryDataProvider));
      _cacheProvider = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
    }

    public ModelCollection<CategoryEntity> List(int categoryParentId)
    {
      return _cacheProvider.GetCategoryList(categoryParentId, () => _categoryDataProvider.List(categoryParentId));
    }

    public CategoryEntity Read(int categoryId)
    {
      return _cacheProvider.GetCategory(categoryId, () => _categoryDataProvider.Read(categoryId));
    }

    public void Save(CategoryEntity category)
    {
      if (category == null)
      {
        throw new ArgumentNullException(nameof(category));
      }

      if (category.CategoryId.HasValue)
      {
        _cacheProvider.RemoveCategory(category.CategoryId.Value);
      }

      _categoryDataProvider.Save(category);

      _cacheProvider.RemoveCategoryList(category.CategoryParentId.Value);
    }

    public void Delete(int categoryId)
    {
      CategoryEntity category;

      if (_categoryDataProvider.Delete(categoryId, out category) && category.CategoryParentId.HasValue)
      {
        _cacheProvider.RemoveCategoryList(category.CategoryParentId.Value);
      }

      _cacheProvider.RemoveCategory(categoryId);
    }

    public void Move(int categoryParentId, int categoryId, MoveDirection direction)
    {
      _entityService.Move(EntityType.Category, EntityType.Category, categoryParentId, categoryId, direction);
      _cacheProvider.RemoveCategoryList(categoryParentId);
    }

    private readonly IEntityService _entityService;

    private readonly IFileService _fileService;

    private readonly ICategoryDataProvider _categoryDataProvider;

    private readonly ICacheProvider _cacheProvider;
  }
}