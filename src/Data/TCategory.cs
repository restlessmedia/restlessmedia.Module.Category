using restlessmedia.Module.Data.EF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restlessmedia.Module.Category
{
  [Table("TCategory")]
  public class TCategory : ICategory
  {
    public TCategory() { }

    public TCategory(ICategory category)
    {
      CategoryId = category.CategoryId;
      Title = category.Title;
      Description = category.Description;
      CategoryParentId = category.CategoryParentId;
    }

    [Key]
    public int? CategoryId { get; set; }

    [Varchar]
    public string Title { get; set; }

    [Varchar]
    public string Description { get; set; }

    public int? CategoryParentId { get; set; }
  }
}