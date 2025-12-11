using System.ComponentModel.DataAnnotations;

namespace VanDongNguyen_FinalExam.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public double? Grade { get; set; }

        // You can use this to mark an assignment as completed when it has a grade
        public bool Completed => Grade.HasValue;
    }
}
