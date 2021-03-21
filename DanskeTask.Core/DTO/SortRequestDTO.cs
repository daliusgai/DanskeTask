using System.ComponentModel.DataAnnotations;

namespace DanskeTask.Core.DTO
{
    public class SortRequestDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Numbers { get; set; }
    }
}