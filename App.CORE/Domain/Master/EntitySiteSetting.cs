using System;

namespace App.CORE.Domain.Master
{
    public class EntitySiteSetting
    {
        public Int32 HEAD_SITE_SETTING_KEY { get; set; }
        public String SITE_SETTING_CODE { get; set; }
        public String SITE_TITLE { get; set; }
        public String CONTACT_NO { get; set; }
        public String MAIL { get; set; }
        public String FACEBOOK_LINK { get; set; }
        public String TWITTER_LINK { get; set; }
        public String LINKEDIN_LINK { get; set; }
        public String BUSINESS_HOURS { get; set; }
        public String ADDRESS { get; set; }
        public String FOOTER_NOTE { get; set; }
        public String LOGO_NAME { get; set; }
        public String ICON_IMG { get; set; }

        public String HEADER_IMG { get; set; }
        public String FOOTER_IMG { get; set; }

        public Int32 DTLS_USEFULL_LINKS_KEY { get; set; }
        public String TITLE { get; set; }
        public String LINK { get; set; }

        public Int32 DTLS_PAGE_SETTING_KEY { get; set; }
        public Int32 MAST_PAGE_KEY { get; set; }
        public String PAGE_TITLE { get; set; }
        public String META_DESCRIPTION { get; set; }
        public String META_KEYWORD { get; set; }


        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }


        public EntitySiteSetting() { }
    }
}
