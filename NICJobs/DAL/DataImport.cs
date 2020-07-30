using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICJobs.DAL
{
    public class DataImport : IDisposable
    {
        public int ImportDatatoDatabase( string Unique_BenID, string StateName, string StateCode, string DistrictName, 
                                         string DistrictCode, string SubDistrictName , string SubDistrictCode,string VillageName,
                                         string VillageCode, string Farmer_Name, string Father_Name)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            var db = factory.Create("dbconnection");

            try
            {
                System.Data.Common.DbCommand dbCommandWrapper = db.GetStoredProcCommand("uasp_FarmerData");
                db.AddInParameter(dbCommandWrapper, "@Unique_BenID", DbType.String, Unique_BenID);
                db.AddInParameter(dbCommandWrapper, "@StateName", DbType.String, StateName);
                db.AddInParameter(dbCommandWrapper, "@StateCode", DbType.String, StateCode);
                db.AddInParameter(dbCommandWrapper, "@DistrictName", DbType.String, DistrictName);
                db.AddInParameter(dbCommandWrapper, "@DistrictCode", DbType.String, DistrictCode);
                db.AddInParameter(dbCommandWrapper, "@SubDistrictName", DbType.String, SubDistrictName);
                db.AddInParameter(dbCommandWrapper, "@SubDistrictCode", DbType.String, SubDistrictCode);
                db.AddInParameter(dbCommandWrapper, "@VillageName", DbType.String, VillageName);
                db.AddInParameter(dbCommandWrapper, "@VillageCode", DbType.String, VillageCode);
                db.AddInParameter(dbCommandWrapper, "@Farmer_Name", DbType.String, Farmer_Name);
                db.AddInParameter(dbCommandWrapper, "@Father_Name", DbType.String, Father_Name);

                return db.ExecuteNonQuery(dbCommandWrapper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
