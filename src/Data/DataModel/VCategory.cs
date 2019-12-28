using SqlBuilder;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restlessmedia.Module.Category.Data.DataModel
{
  [Table("_VCategory", Schema = "dbo")]
  public class VCategory : DataModel<VCategory, CategoryEntity>
  {
    [Key]
    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int? CategoryParentId { get; set; }

    [ReadOnly(true)]
    public int? EntityGuid { get; set; }

    [ReadOnly(true)]
    public int? LicenseId { get; set; }
  }
}
