using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Models
{
    [Table("Amigos")]
    public class Amigo
    {
        [Key] public int Id { get; set; }
        [Required] [MaxLength(200)] public string Name { get; set; }

        [Required] [MaxLength(200)] public string LastName { get; set; }

        [Required] [MaxLength(200)] public string Email { get; set; }

        [Required] [Range(0, 11)] public int Tel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

    }

}