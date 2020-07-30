using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICJobs.Provider
{
    public class DataProvider : IDisposable
    {
        public DataSet GetCandidateTestData(int testId, Int32 regId = 0)
        {
            var db = DatabaseFactory.CreateDatabase();

            try
            {
                System.Data.Common.DbCommand dbCommandWrapper = db.GetStoredProcCommand("stored_procedure_name");
                db.AddInParameter(dbCommandWrapper, "@TestId", DbType.Int32, testId);
                db.AddInParameter(dbCommandWrapper, "@RegId", DbType.Int32, regId);
                return db.ExecuteDataSet(dbCommandWrapper);
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
