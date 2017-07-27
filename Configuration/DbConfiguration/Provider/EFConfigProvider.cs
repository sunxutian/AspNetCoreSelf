using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AspNetCore.Configuration.DbConfiguration.Context;
using System.Linq;
using System.Collections.Generic;

namespace AspNetCore.Configuration.DbConfiguration.Provider
{
    internal class EFConfigProvider : ConfigurationProvider
    {
        private Action<DbContextOptionsBuilder> _optionsAction;

        public EFConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigurationContext>();
            _optionsAction(builder);

            using (var dbContext = new ConfigurationContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                Data = dbContext.MyOptions.Any() ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.MyOptions.ToDictionary(c => c.Key, c => c.Option);
            }
        }

        private IDictionary<string, string> CreateAndSaveDefaultValues(ConfigurationContext dbContext)
        {
            var configValues = new Dictionary<string, string>
                {
                    { "key1", "value_from_ef_1" },
                    { "key2", "value_from_ef_2" }
                };
            dbContext.MyOptions.AddRange(configValues.Select(c => new MyOption{
                Key = c.Key,
                Option = c.Value
            }).ToArray());
            
            dbContext.SaveChanges();

            return configValues;
        }
    }
}