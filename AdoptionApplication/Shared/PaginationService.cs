namespace AdoptionApplication.Shared
{
    public static class PaginationService
    {
        public static int PageItems = 1;
        public static int? HowManyItemsSkip(int? page)
        {
            if (page == null) return null;

            var toSkip = page.Value * PageItems;

            return toSkip - 1;
        }
    }
}
