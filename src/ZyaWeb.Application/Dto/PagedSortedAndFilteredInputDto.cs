﻿using ZyaWeb.PersonArticles.Persons;

namespace ZyaWeb.Dto
{
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Filter { get; set; }
    }
}