namespace UKParliament.CodeTest.Web.ViewModels
{
    public class MPPaginator
    {
        public MPPaginator(IEnumerable<MPViewModel> mpvm)
        {
            Data = mpvm;
        }

        public IEnumerable<MPViewModel> Data { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
