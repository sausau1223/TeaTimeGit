using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeaTimeDemo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(30)]
        [DisplayName("類別名稱")]
        public string? Name { get; set; }



        [Range(1, 100,ErrorMessage ="輸入範圍應該要在1-100之間")]
        [DisplayName("顯示順序")]
        public int DisplayOrder {  get; set; }


    }
}
