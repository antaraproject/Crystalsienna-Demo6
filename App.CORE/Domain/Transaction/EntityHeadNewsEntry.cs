using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.CORE.Domain.Transaction
{
    public class EntityHeadNewsEntry
    {
        public Int32 HEAD_NEWS_ENTRY_KEY { get; set; }
        public String HEAD_NEWS_CODE { get; set; }
        public DateTime NEWS_DATE { get; set; }
        public String NEWS_REGION_KEY { get; set; }
        public String NEWS_REGION { get; set; }
        public String NEWS_CATEGORY_KEY { get; set; }
        public String NEWS_CATEGORY { get; set; }
        public String NEWS_SECTION_KEY { get; set; }
        public String NEWS_SECTION { get; set; }
        public String BLOG_HEADING { get; set; }
        public String BLOG_DETAIL { get; set; }
        public String BLOGGER_NAME { get; set; }
        public String PIC_FILE { get; set; }

        public Int32 ENT_USER_KEY { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 SYS_COMPANY_KEY { get; set; }
        public String START_YEAR { get; set; }
        public String END_YEAR { get; set; }

        public string PIC_FILE_NAME { get; set; }
    }
}
