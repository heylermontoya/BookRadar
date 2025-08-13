using System.Collections.Generic;

namespace BookRadar.Models
{
    public class LibroApiResult
    {
        public List<LibroItem> Docs { get; set; }
    }

    public class LibroItem
    {
        public List<string> author_name;

        public string Title { get; set; }
        public int? First_Publish_Year { get; set; }
        public string Publisher { get; set; }
    }
}
