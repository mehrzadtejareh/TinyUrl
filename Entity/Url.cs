using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TinyUrl.Resources;
namespace TinyUrl.Entity
{
    public class Url
    {
        public int id { get; set; }
        [Required(ErrorMessageResourceName = nameof(Messages.IsRequired), ErrorMessageResourceType = typeof(Messages))]
        public string TinyCode { get; set; }
        [StringLength(2048, MinimumLength = 5, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.StringLength))]
        [Required(ErrorMessageResourceName = nameof(Messages.IsRequired), ErrorMessageResourceType = typeof(Messages))]
        public string SourceUrl { get; set; }
        public int Hit { get; set; } = 0;
    }
}
