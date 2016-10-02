using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Affinity.Data.Model
{
    [DbConfigurationType(typeof(MyDbConfiguration))]
    public class DbModel:DbContext
    {
        public DbModel():base("DefaultConnection")
        {
            this.Database.CommandTimeout = 360;
        }

        public virtual DbSet<myWeekDataLogs> myWeekDataLogs { get; }

        public virtual DbSet<MyDataLogs> MyDataLogs { get; set; }

        public virtual DbSet<MyDataLogs_2015> MyDataLogs_2015 { get; set; }

        public virtual DbSet<MySettings> MySettings { get; set; }


        public virtual DbSet<OperationLogs> OperationLogs { get; set; }

      
        public virtual DbSet<myErrorLog> myErrorLog { get; set; }

        public virtual DbSet<myDateDatas> myDateDatas { get; set; }

        public virtual DbSet<mycachedatas> mycachedatas { get; set; }


        public virtual DbSet<InsertedLog> InsertedLogs { get; set; }

        public virtual DbSet<myAppSettings> myAppSettings { get; set; }


        public virtual DbSet<ProfileFileIndexes> ProfileFileIndexes { get; set; }

        public virtual DbSet<CheckLogDatas> CheckLogDatas { get; set; }

        public virtual DbSet<FarmDefinitionsWLog> FarmDefinitionsWLogs { get; set; }
        public virtual DbSet<PowerDataLog> PowerDataLogs { get; set; }
        public virtual DbSet<PowerRevenueLog> PowerRevenueLogs { get; set; }
        public virtual DbSet<DM21_ManualData> DM21_ManualData { get; set; }
        public virtual DbSet<DM43_ManualData> DM43_ManualData { get; set; }

        public virtual DbSet<FarmDefinition> FarmDefinitions { get; set; }
        public virtual DbSet<DM21MSData> DM21MSData { get; set; }
        public virtual DbSet<DM43MSData> DM43MSData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DM21_ManualData>()
                .Property(e => e.DM21_Export_Rev)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DM43_ManualData>()
                .Property(e => e.DM43_Export_Rev)
                .HasPrecision(19, 4);
        }


    }
    public class DM43MSData
    {
        public int Id { get; set; }
        public DateTime MSDate { get; set; }
        public string POD34_MS { get; set; }
        public string POD35_MS { get; set; }
        public string POD41_MS { get; set; }
        public string POD42_MS { get; set; } 
        public string POD43_MS { get; set; }
        public string POD44_MS { get; set; }
    }

    public class DM21MSData
    {
        public int Id { get; set; }
        public DateTime MSDate { get; set; }
        public string POD21_MS { get; set; }
        public string POD22_MS { get; set; }
        public string POD23_MS { get; set; }
        public string POD24_MS { get; set; }
    }


    public  class FarmDefinition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfileName { get; set; }

        [Required]
        [StringLength(50)]
        public string FarmName { get; set; }

        public int BarnNo { get; set; }

        public int OrderNo { get; set; }
    }

    public  class DM21_ManualData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? Date_GEN { get; set; }

        public double? DM21_Gen_Budget_DAA { get; set; }

        public double? DM21_Gen_Budget_DMA { get; set; }

        public double? DM21_Export_Budget_DAA { get; set; }

        public double? DM21_Export_Budget_DMA { get; set; }

        public double? DM21_Export_Actual { get; set; }

        [Column(TypeName = "money")]
        public decimal? DM21_Export_Rev { get; set; }

        public double? POD21_PC { get; set; }

        public double? POD22_PC { get; set; }

        public double? POD23_PC { get; set; }

        public double? POD24_PC { get; set; }

        public double? DM21_PC_Tot { get; set; }

        public double? POD21_PAW { get; set; }

        public double? POD22_PAW { get; set; }

        public double? POD23_PAW { get; set; }

        public double? POD24_PAW { get; set; }

        public double? DM21_PAW_Tot { get; set; }

        [StringLength(255)]
        public string POD21_MS { get; set; }

        [StringLength(255)]
        public string POD22_MS { get; set; }

        [StringLength(255)]
        public string POD23_MS { get; set; }

        [StringLength(255)]
        public string POD24_MS { get; set; }
    }

    public  class DM43_ManualData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? Date_Gen { get; set; }

        public double? DM43_Gen_Budget_DAA { get; set; }

        public double? DM43_Gen_Budget_DMA { get; set; }

        public double? DM43_Export_Budget_DAA { get; set; }

        public double? DM43_Export_Budget_DMA { get; set; }

        public double? DM43_Export_Actual { get; set; }

        [Column(TypeName = "money")]
        public decimal? DM43_Export_Rev { get; set; }

        public double? POD34_PC { get; set; }

        public double? POD35_PC { get; set; }

        public double? POD41_PC { get; set; }

        public double? POD42_PC { get; set; }

        public double? POD43_PC { get; set; }

        public double? POD44_PC { get; set; }

        public double? DM43_PC_Tot { get; set; }

        public double? POD34_PAW { get; set; }

        public double? POD35_PAW { get; set; }

        public double? POD41_PAW { get; set; }

        public double? POD42_PAW { get; set; }

        public double? POD43_PAW { get; set; }

        public double? POD44_PAW { get; set; }

        public double? DM43_PAW_Tot { get; set; }

        [StringLength(255)]
        public string POD34_MS { get; set; }

        [StringLength(255)]
        public string POD35_MS { get; set; }

        [StringLength(255)]
        public string POD41_MS { get; set; }

        [StringLength(255)]
        public string POD42_MS { get; set; }

        [StringLength(255)]
        public string POD43_MS { get; set; }

        [StringLength(255)]
        public string POD44_MS { get; set; }
    }


    public  class FarmDefinitionsWLog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfileName { get; set; }

        [Required]
        [StringLength(50)]
        public string FarmName { get; set; }

        public int Barn { get; set; }

        public int PlacedInBarn { get; set; }

        public double PoundsPlaced { get; set; }

        public int TotalMortlity { get; set; }

        public int HeadSold { get; set; }

        public int HeadRemaining { get; set; }

        public DateTime PlacedOrProjectedDate { get; set; }

        public DateTime DateConcern { get; set; }

        public float PigAge { get; set; }
    }



    public  class PowerDataLog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfileName { get; set; }

        public DateTime LogDate { get; set; }

        public int PowerData { get; set; }

        public DateTime SumLogDate { get; set; }
    }

    public  class PowerRevenueLog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfileName { get; set; }

        public DateTime LogDate { get; set; }

        public double RevenueAmtData { get; set; }
    }

    public class CheckLogDatas
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string ProFileName { get; set; }


        public string ErrorLog { get; set; }

    }


    public class ProfileFileIndexes
    {
        [Key]
        public int Id { get; set; }

        public string ProfileName { get; set; }

        public string FileDefinition { get; set; }

        public Boolean OptionalFile { get; set; }
    }

    public class myAppSettings
    {
        [Key]
        public int Id { get; set; }
        public string StorageAccName { get; set; }
        public string StorageAccKey { get; set; }
        public Boolean StorageAccHttp { get; set; }
        public string MailUser { get; set; }
        public string MailHost { get; set; }
        public string MailFrom { get; set; }
        public string MailPass { get; set; }
        public int MailPort { get; set; }
        public Boolean MailUseSSL { get; set; }
        public string SendTo { get; set; }
        public string ExternalIP { get; set; }
        public Boolean UsePassive { get; set; }
    }

    public class mycachedatas
    {
        [Key]
        public int Id { get; set; } //5* 12 * 5 , 60 * 5 records per project.
        public string WeekNo { get; set; }
        public string WeekStr { get; set; }
        public int? NoOfWeeks { get; set; }
        public int? MonthNo { get; set; }
        public string Project { get; set; }
        public double? WKws { get; set; }
        
    }


    public class myErrorLog
    {
        public int Id { get; set; }
        public DateTime ErrorCreated { get; set; }
        public string ProfileName { get; set; }
        public string DString { get; set; }
        public string errorDescription { get; set; }
        public Boolean ReadError { get; set; }
    }

    public class myLMD1minuteTable2
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double LT_BR1_EU { get; set; }
        public double LT_BR2_EU { get; set; }
        public double TT_GT_EU { get; set; }
        public double TT_OT_EU { get; set; }
        public double TT_RP_EU { get; set; }
        public double VC1 { get; set; }
        public double VC2 { get; set; }
        public double VC3 { get; set; }
        public double MODBUS_COGEN_PWROUT_ACT { get; set; }
        public double TT_GF_EU { get; set; }
        public double IT_E1_EU { get; set; }
        public double IT_E2_EU { get; set; }

    }

    public class myLMD1minuteTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double PT_G1_EU { get; set; }
        public double PT_G2_EU { get; set; }
        public double FT_L_1_EU { get; set; }
        public double FT_L_2_EU { get; set; }
        public double FT_G1_EU { get; set; }
        public double FT_CHP_EU { get; set; }
        public double FT_GF_EU { get; set; }
        public double PX { get; set; }
        public double VT_GT { get; set; }
        public double PT_GT_EU { get; set; }
        public double FT_G2_EU { get; set; }
        public double LT_ES_EU { get; set; }
        public double LT_RP_EU { get; set; }


    }

    public class myLMD24HourTable2
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double OC1 { get; set; }
        public double GF { get; set; }
        public double GCHP { get; set; }
        public double ECHP { get; set; }
        public double MODBUS_COGEN_TODAYKWH_ACT { get; set; }
        public double MODBUS_COGEN_TOTALHRS_ACT { get; set; }

    }

    public class myLMD24HourTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double EV3 { get; set; }
        public double EV4 { get; set; }
        public double MF3 { get; set; }
        public double MF4 { get; set; }
        public double VC4 { get; set; }
        public double VC5 { get; set; }
        public double VC6_DAILAY_LOG { get; set; }
        public double VC7_DAILAY_LOG { get; set; }
        public double DELTA_VOLUME_BIODOME { get; set; }

    }

    public class myLMD1HourTable2
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double TT_L1_1_EU { get; set; }
        public double TT_L1_2_EU { get; set; }
        public double TT_L1_3_EU { get; set; }
        public double TT_L1_4_EU { get; set; }
        public double TT_L2_1_EU { get; set; }
        public double TT_L2_2_EU { get; set; }
        public double TT_L2_3_EU { get; set; }
        public double TT_L2_4_EU { get; set; }

    }

    public class myLMD1HourTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double PT_CA_EU { get; set; }

        public double TT_H1_1_EU { get; set; }
        public double TT_H1_2_EU { get; set; }
        public double TT_H1_3_EU { get; set; }
        public double TT_H1_4_EU { get; set; }
        public double TT_H2_1_EU { get; set; }
        public double TT_H2_2_EU { get; set; }
        public double TT_H2_3_EU { get; set; }
        public double TT_H2_4_EU { get; set; }
        public double TT_HZ_1_EU { get; set; }
        public double TT_HZ_2_EU { get; set; }



    }

    public class myOLD1minuteTable2
    {


        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double LT_RP_EU { get; set; }
        public double LT_BR1_EU { get; set; }
        public double LT_BR2_EU { get; set; }
        public double TT_G1_EU { get; set; }
        public double TT_OT_EU { get; set; }
        public double TT_RP_EU {get;set;}
        public double MODBUS_WM_PD_ACT { get; set; }
        public double MODBUS_COGEN_PWROUT_ACT { get; set; }
        public double TT_GF_EU { get; set; }
}

    public class myOLD1minuteTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double PT_G1_EU { get; set; }
        public double PT_G2_EU { get; set; }
        public double FT_L_1_EU { get; set; }
        public double FT_L_2_EU { get; set; }
        public double FT_G1_EU { get; set; }
        public double FT_C_EU { get; set; }
        public double FT_F_EU { get; set; }
        public double VT_GT { get; set; }
        public double PT_GT_EU { get; set; }
        public double MODBUS_WM_PCHP_ACT { get; set; }
        public double IT_E1_EU { get; set; }
        public double IT_E2_EU { get; set; }
        public double MODBUS_FLARE_LOG { get; set; }
        public double PT_CA_EU { get; set; }
    }

    public class myOLD24HourTable2
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double EPARA { get; set; }
        public double AI1 { get; set; }
        public double OC1 { get; set; }
        public double GF { get; set; }
        public double GCHP { get; set; }
        public double ECHP { get; set; }
        public double DELTA_VOLUME_BIODOME { get; set; }
    }

    public class myOLD24HourTable1
    {


        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double EV3 { get; set; }
        public double EV4 { get; set; }
        public double MF3 { get; set; }
        public double MF4 { get; set; }
        public double VC4_DAILY_LOG { get; set; }
        public double VC5_DAILY_LOG { get; set; }
        public double VC6_DAILAY_LOG { get; set; }
        public double VC7_DAILAY_LOG { get; set; }
        public double CPLE { get; set; }
        public double MODBUS_COGEN_TOTALKWH_ACT { get; set; }
        public double MODBUS_COGEN_TOTALHRS_ACT { get; set; }
    }

    public class myOLD1HourTable2
    {

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double TT_L1_1_EU { get; set; }
        public double TT_L1_2_EU { get; set; }
        public double TT_L1_3_EU { get; set; }
        public double TT_L1_4_EU { get; set; }
        public double TT_L2_1_EU { get; set; }
        public double TT_L2_2_EU { get; set; }
        public double TT_L2_3_EU { get; set; }
        public double TT_L2_4_EU { get; set; }

    }

    public class myOLD1HourTable1
    {

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }

        public double PT_CA_EU { get; set; }
        public double TT_H1_1_EU { get; set; }
        public double TT_H1_2_EU { get; set; }
        public double TT_H1_3_EU { get; set; }
        public double TT_H1_4_EU { get; set; }
        public double TT_H2_1_EU { get; set; }
        public double TT_H2_2_EU { get; set; }
        public double TT_H2_3_EU { get; set; }
        public double TT_H2_4_EU { get; set; }
    }


    /// <summary>
    /// The default object to used in ETL process and create the Final Schema Data.
    /// </summary>
    public class MyDataLogs_2015
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } //Date Created Based on Profile TimeZone.
        public string ProfileName { get; set; }
        public string FileName { get; set; }
        public string fl1 { get; set; }
        public string fl2 { get; set; }
        public string fl3 { get; set; }
        public string fl4 { get; set; }
        public string fl5 { get; set; }
        public string fl6 { get; set; }
        public string fl7 { get; set; }
        public string fl8 { get; set; }
        public string fl9 { get; set; }
        public string fl10 { get; set; }
        public string fl11 { get; set; }
        public string fl12 { get; set; }
        public string fl13 { get; set; }
        public string fl14 { get; set; }
        public string fl15 { get; set; }
        public string fl16 { get; set; }
        public string fl17 { get; set; }
        public string fl18 { get; set; }
        public string fl19 { get; set; }
        public string fl20 { get; set; }
        public Boolean ETLComplete { get; set; } //Default false;
        public string oFileName { get; set; }
        public string oProfileName { get; set; }
    }


    /// <summary>
    /// The default object to used in ETL process and create the Final Schema Data.
    /// </summary>
    public class MyDataLogs
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } //Date Created Based on Profile TimeZone.
        public string ProfileName { get; set; }
        public string FileName { get; set; }
        public string fl1 { get; set; }
        public string fl2 { get; set; }
        public string fl3 { get; set; }
        public string fl4 { get; set; }
        public string fl5 { get; set; }
        public string fl6 { get; set; }
        public string fl7 { get; set; }
        public string fl8 { get; set; }
        public string fl9 { get; set; }
        public string fl10 { get; set; }
        public string fl11 { get; set; }
        public string fl12 { get; set; }
        public string fl13 { get; set; }
        public string fl14 { get; set; }
        public string fl15 { get; set; }
        public string fl16 { get; set; }
        public string fl17 { get; set; }
        public string fl18 { get; set; }
        public string fl19 { get; set; }
        public string fl20 { get; set; }
        public Boolean ETLComplete { get; set; } //Default false;
        public string oFileName { get; set; }
        public string oProfileName { get; set; }
    }



    public class OperationLogs
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string FileName { get; set; }
        public string profileName { get; set; }
        public int RowsCount { get; set; }
    }

    public class MySettings
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string TimeZone { get; set; }
        public int TimeFromUTC { get; set; }

        public string ftphost { get; set; }
        public string ftpuname { get; set; }
        public string ftppass { get; set; }
        public int ftpPort { get; set; }
        public string FtpFolder { get; set; } 
        public Boolean UseProxy { get; set; }
        public string ProxyURL { get; set; }
    }

    public class myFGO1minuteTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double PT_G1_EU { get; set; }
        public double PT_G2_EU { get; set; }
        public double FT_L_1_EU { get; set; }
        public double FT_G1_EU { get; set; }
        public double FT_CHP_EU { get; set; }
        public double FT_GF_EU { get; set; }
        public double VT_GT { get; set; }
        public double PT_GT_EU { get; set; }
        public double WM_PC_EU { get; set; }
        public double WM_PD_EU { get; set; }
    }

    public class myFGO1HourTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } 
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double TT_H1_1_EU { get; set; }
        public double TT_H1_3_EU { get; set; }
        public double TT_H2_1_EU { get; set; }
        public double TT_H2_3_EU { get; set; }
        public double TT_L1_1_EU { get; set; }
        public double TT_L1_2_EU { get; set; }
        public double TT_L2_1_EU { get; set; }
        public double TT_L2_2_EU {get;set;}
    }

    public class myAlarm
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } //Date Created Based on Profile TimeZone.
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public string message { get; set; }
    }


    public class myFGO24HourTable1
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } 
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double EV3_DAILY_LOG { get; set; }
        public double EV4_DAILY_LOG { get; set; }
        public double MF3_DAILY_LOG { get; set; }
        public double MF4_DAILY_LOG { get; set; }
        public double VC4_DAILY_LOG { get; set; }
        public double VC5_DAILY_LOG { get; set; }
        public double VC6_DAILY_LOG { get; set; }
        public double VC7_DAILY_LOG { get; set; }
        public double DELTA_VOLUME_BIODOME { get; set; }
    }


    public class myDateDatas
    {
     [Key]
     public int   Id { get; set; }
     public DateTime RealDate { get; set; }
     public int WeekOfYear { get; set; }
     public string WeekString { get; set; }
     public string WeekStr { get; set; }
     public int MonthId { get; set; }
     public string MonthString { get; set; }
     public int MWeeksCount { get; set; }
     public int DMonthCount { get; set; }
     public int YearId { get; set; }
     public string YearString { get; set; }
    }

    public class myWeekDataLogs
    {
        [Key]
        public int Id { get; set; }
        public int yearConcern { get; set; }
        public int mId { get; set; }
        public string WeekNo { get; set; }
        public string weekStr { get; set; }
        public int NoOfWeeks { get; set; }
    }


    public class myFGO24HourTable2
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } //Date Created Based on Profile TimeZone.
        public string ProfileName { get; set; }
        public DateTime DateRec { get; set; }
        public double OC1 { get; set; }
        public double GF_DAILY_LOG { get; set; }
        public double GCHP_DAILY_LOG { get; set; }
        public double ECHP_DAILY_LOG { get; set; }
        public double TECHP { get; set; }
        public double THCHP { get; set; }
        public double CPLE_DAILY_LOG { get; set; }
        public double EPARA_DAILY_LOG { get; set; }
        public double CPLD_DAILY_LOG { get; set; }
    }

}
