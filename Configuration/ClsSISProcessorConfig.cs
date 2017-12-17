using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Configuration
{
    abstract class SISProcessor
    {
        public abstract bool Insert(object obj);
        //public abstract bool Update(object obj);
        //public abstract bool Delete(object obj);
        //public abstract bool Query(object obj);

        ~SISProcessor()
        {
        }
    }

    class PurchaseProcessor : SISProcessor
    {
        public override bool Insert(object CPC)
        {
            try
            {

                SIS.DBClass.DBClassPurchaseMaster dbcPurchaseMaster = new DBClass.DBClassPurchaseMaster();
                dbcPurchaseMaster.InsertData((ClsPurchaseConfig)CPC);
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }

    class StockProcessor : SISProcessor
    {
        public override bool Insert(object CSC)
        {
            try
            {
                SIS.DBClass.DBClassStockMaster dbcStockMaster = new DBClass.DBClassStockMaster();
                dbcStockMaster.InsertData((ClsStockConfig)CSC);
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }

    public enum SISOperating
    {
        Purchase,
        Stock,
        Ship,
        RMA,
        TakeStock,
        Reversal
    }

    static class SISProcessorFactory
    {
        public static SISProcessor getInstance(SISOperating sisType)
        {
            switch (sisType)
            {
                case SISOperating.Purchase:
                    return new PurchaseProcessor();
                case SISOperating.Stock:
                    return new StockProcessor();
                //case SISOperating.Ship:
                //return new ShipProcessor();
                default:
                    return new PurchaseProcessor();
            }

        }
    }
}
