namespace withEF.Helpers
{
    public class PagingModel
    {
        public int CurrentPage {set; get;}
        public int CountPage {set; get;}
        
        public Func<int? , string> GenerateUrl { get; set; }
    }
}