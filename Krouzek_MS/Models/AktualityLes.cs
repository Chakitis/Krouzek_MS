using System.ComponentModel.DataAnnotations;

namespace Krouzek_MS.Models
{
    public class AktualityLes
    {
        
            public int Id { get; set; }
            
            public string Content { get; set; } = "";
         
            public string Title { get; set; } = "";
            public string Description { get; set; } = "";
        
    }
}
