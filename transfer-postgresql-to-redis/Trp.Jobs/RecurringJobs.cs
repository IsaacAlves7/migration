using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trp.Service;

namespace Trp.Jobs
{
    public static class RecurringJobs
    {
        public static void RecurringJobList()
        {
            RecurringJob.RemoveIfExists(nameof(Transfer));
            RecurringJob.AddOrUpdate<Transfer>(nameof(Transfer), job => job.TransferPostgresqlToRedis(), "*/15 * * * * *");
        }
    }
}
