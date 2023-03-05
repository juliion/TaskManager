using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
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
        [MaxLength(100)]
        public string Hashtag { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
