using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs
{
    public class UpdateTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
