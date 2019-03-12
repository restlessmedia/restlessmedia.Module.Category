using restlessmedia.Module.File;
using System;

namespace restlessmedia.Module.Category
{
  [Serializable]
  public class CategoryEntity : Entity, ICategory
  {
    public CategoryEntity(string title, string description)
      : this()
    {
      Title = title;
      Description = description;
    }

    public CategoryEntity(){ }

    public override EntityType EntityType
    {
      get
      {
        return EntityType.Category;
      }
    }

    public override int? EntityId
    {
      get
      {
        return CategoryId;
      }
    }

    public int? CategoryId { get; set; }

    public int? CategoryParentId { get; set; }

    public string Description { get; set; }

    public FileEntity Thumb { get; set; }

    public int? Rank { get; set; }

    #region Dapper Mapping

    /// <summary>
    /// Used for dapper when category appears in select with another entity using the title column
    /// </summary>
    private string Category
    {
      get
      {
        return base.Title;
      }
      set
      {
        base.Title = value;
      }
    }

    #endregion
  }
}