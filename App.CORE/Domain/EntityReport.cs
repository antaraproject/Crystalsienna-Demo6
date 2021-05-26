using System;

namespace App.CORE.Domain
{
    public class EntityReport
    {
        public Int32 MAST_WAREHOUSE_KEY { get; set; }
        public Int32 MAST_BRANCH_KEY { get; set; }
        public Int32 MAST_PART_KEY { get; set; }
        public Int32 PUBLISHER_KEY { get; set; }
        public Int32 MAST_PUBLICATION_KEY { get; set; }
        public Int32 MAST_EDITION_KEY { get; set; }
        public Int32 MAST_LEDGER_KEY { get; set; }
        public Int32 MAST_GROUP_KEY { get; set; }
        public Int32 MAST_LEDGER_SUPPLIER_KEY { get; set; }
        public Int32 MAST_STAFF_KEY { get; set; }
        public Int32 SUPPLIER_REG_UNREG_TYPE_KEY { get; set; }
        public Int32 BILL_TO_LEDGER_KEY { get; set; }
        public Int32 MAST_CHANNEL_KEY { get; set; }
        public Int32 REPORT_TYPE { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public DateTime INS_START_DATE { get; set; }
        public DateTime INS_END_DATE { get; set; }
        public DateTime OPENING_START_DATE { get; set; }
        public DateTime OPENING_END_DATE { get; set; }

        public Int32 ENT_USER_KEY { get; set; }
        public Int16 COMPANY_KEY { get; set; }
        public String START_YEAR { get; set; }
        public String END_YEAR { get; set; }
    }
}
