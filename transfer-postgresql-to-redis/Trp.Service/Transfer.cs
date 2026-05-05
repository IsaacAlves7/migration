using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trp.Domain;
using Trp.Service.Cache;
using Trp.Service.Interface;
using Trp.Service.Const;
using Trp.Service.ViewModel;
using Microsoft.Extensions.Logging;

namespace Trp.Service
{
    public class Transfer : ITransfer
    {
        private readonly IRedisCacheService redisCacheService;

        private readonly TrpDbContext trpDbContext;


        public Transfer(IRedisCacheService redisCacheService , TrpDbContext trpDbContext)
        {
            this.redisCacheService = redisCacheService;
            this.trpDbContext = trpDbContext;   
        }

        public void TransferPostgresqlToRedis()
        {
            var urlResult = trpDbContext.Url.ToList();

            if (urlResult == default || !urlResult.Any())
            {
                throw new Exception(ErrorConst.URL_LIST_EMPTY_ERROR);
            }

            foreach (var item in urlResult)
            {
                if (string.IsNullOrWhiteSpace(item.UrlKey))
                {
                    throw new Exception(ErrorConst.URL_KEY_EMPTY_ERROR);
                }

                var urlIsSet = redisCacheService.IsSet(item.UrlKey);

                if (urlIsSet) 
                {
                    Console.WriteLine($"Urlkey already set: {item.UrlKey}");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(item.UrlContent))
                {
                    throw new Exception(ErrorConst.URL_CONTENT_EMPTY_ERROR);
                }

                UrlFilterContentViewModel urlFilter = new()
                {
                    AllPortsBlocked = item.AllPortsBlocked,
                    NonSecureAccess = item.NonSecureAccess,
                    SecureAccess = item.SecureAccess,
                    DomainBlocked = item.DomainBlocked,
                    Url = item.UrlContent
                };

                redisCacheService.SetAsync(item.UrlKey, urlFilter, TimeSpan.FromDays(1));
            }

        }
    }
}
