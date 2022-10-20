namespace WorldOfPowerToolsTest.Models.ViewModels
{
    public class PagingInfo
    {
        public int Totalltems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)Totalltems / ItemsPerPage);
    }
}