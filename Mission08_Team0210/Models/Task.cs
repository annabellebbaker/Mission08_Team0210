﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0210.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }// getter and setter applied
        [Required(ErrorMessage = "Please enter a Task Name.")]
        public string TaskName { get; set; }   
        public string? DueDate { get; set; }
        [Required(ErrorMessage = "Please select a Quadrant.")]
        public int? Quadrant { get; set; }
        
        [ForeignKey("CategoryId")]
        public int? CategoryId {  get; set; }
        public Category? Category { get; set; }
        public bool Completed { get; set; }

     


    }
}
