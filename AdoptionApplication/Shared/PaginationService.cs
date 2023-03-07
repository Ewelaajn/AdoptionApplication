namespace AdoptionApplication.Shared
{
    public static class PaginationService
    {
        public static int PageItems = 3;
        public static int? HowManyItemsSkip(int? page)
        {
            if (page == null) return null;
            if (page == 1) return 0;
            var toSkip = (page.Value -1) * PageItems;

            return toSkip;
        }
    }
}
