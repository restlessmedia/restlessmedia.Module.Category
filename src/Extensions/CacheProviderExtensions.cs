using restlessmedia.Module.Category;
using System;

namespace restlessmedia.Module
{
  internal static class CacheProviderExtensions
  {
    public static ModelCollection<CategoryEntity> GetCategoryList(this ICacheProvider cache, int categoryParentId, Func<ModelCollection<CategoryEntity>> valueFactory)
    {
      return cache.Get(cache.GetKey("categoryList", categoryParentId), valueFactory);
    }

    public static void RemoveCategoryList(this ICacheProvider cache, int categoryParentId)
    {
      cache.Remove(cache.GetKey("categoryList", categoryParentId));
    }

    public static CategoryEntity GetCategory(this ICacheProvider cache, int categoryId, Func<CategoryEntity> valueFactory)
    {
      return cache.Get(cache.GetKey("category", categoryId), valueFactory);
    }

    public static void RemoveCategory(this ICacheProvider cache, int categoryId)
    {
      cache.Remove(cache.GetKey("category", categoryId));
    }
  }
}