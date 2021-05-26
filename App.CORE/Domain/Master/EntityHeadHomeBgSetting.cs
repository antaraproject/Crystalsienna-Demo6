using System;

namespace App.CORE.Domain.Master
{
    public class EntityHeadHomeBgSetting
    {
        public String BG_ABOUT_ME_IMAGE { get; set; }
        public String BG_TOUR_IMAGE { get; set; }
        public String BG_QUICK_FACTS_IMAGE { get; set; }
        public String BG_PREFER_IMAGE { get; set; }
        public String BG_GALLERY_IMAGE { get; set; }
        public String BG_EXCITING_OFFER_IMAGE { get; set; }
        public String BG_DAIRY_IMAGE { get; set; }
        public String BG_CLIENT_IMAGE { get; set; }
        public String BG_SELFIE_IMAGE { get; set; }
        public String BG_NEWS_IMAGE { get; set; }
        public String BG_RATE_IMAGE { get; set; }
        public String BG_AVAILABILITY_IMAGE { get; set; }
        public String BG_CALENDER_IMAGE { get; set; }   
        public String BG_VOTING_IMAGE { get; set; }
        
        public DateTime APPROVE_DATE { get; set; }


        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }
        public EntityHeadHomeBgSetting() { }

    }
}
