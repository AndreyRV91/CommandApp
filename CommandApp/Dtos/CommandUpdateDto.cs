using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandApp.Dtos
{
    //could be differ from CommandCreateDto in the future
    public class CommandUpdateDto
    {
        [Required]
        [StringLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
