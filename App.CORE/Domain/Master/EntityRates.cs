using System;

namespace App.CORE.Domain.Master
{
    public class EntityRates
    {
        public String IMAGE_NAME { get; set; }
        public String SERVICE_ONE_HEADING { get; set; }
        public String SERVICE_ONE_NOTE { get; set; }
        public String SERVICE_TWO_HEADING { get; set; }
        public String SERVICE_TWO_NOTE { get; set; }
        public String DISCLAIMER { get; set; }


        public Int32 MAST_SINGLE_PRICING_KEY { get; set; }
        public Int32 MAST_DOUBLE_PRICING_KEY { get; set; }
        public String DURATION { get; set; }
        public Decimal ROOM_HIRE { get; set; }
        public Decimal SERVICE_FEE { get; set; }
        public Decimal TOTAL { get; set; }



        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityRates() { }
    }
}
