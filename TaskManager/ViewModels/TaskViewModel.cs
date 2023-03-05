using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using TaskManager.Enums;

namespace TaskManager.ViewModels
{
    public class TaskViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public TaskPriority Priority { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [ForeignKey("Hashtag")]
        public int HashtagId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
