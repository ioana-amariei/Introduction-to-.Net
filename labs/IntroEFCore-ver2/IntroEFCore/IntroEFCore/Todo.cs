using System;
using System.ComponentModel.DataAnnotations;

namespace IntroEFCore
{
    public class Todo
    {
        public Guid Id { get; set; }

       public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}