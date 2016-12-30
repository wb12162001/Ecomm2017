using EFCache;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;

namespace Quick.Framework.EFData
{
    public class Configuration : DbConfiguration
    {
        internal static readonly InMemoryCache Cache = new InMemoryCache();

        public Configuration()
        {
            var transactionHandler = new CacheTransactionHandler(Cache);

            AddInterceptor(transactionHandler);

            var cachingPolicy = new CachingPolicy();

            Loaded += (sender, args) => args.ReplaceService<DbProviderServices>(
                        (s, _) => new CachingProviderServices(s, transactionHandler, cachingPolicy));

        }

        public static int GetCountOfCache()
        {
            return Cache.Count;
        }
    }
}
