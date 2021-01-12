using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Skillz.Data
{
    public static class ConfigurationExtensions
    {
        public static void ApplyAllConfigurations<T>(this ModelBuilder modelBuilder)
            where T : DbContext
        {
            var applyConfigurationMethodInfo = modelBuilder.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).First(m => m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));
            var ret = typeof(T).Assembly.GetTypes().Select(t => (t, i: t.GetInterfaces()
                                        .FirstOrDefault(i => i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name, StringComparison.Ordinal))))
                                        .Where(it => it.i != null)
                                        .Select(it => (et: it.i.GetGenericArguments()[0], cfgObj: Activator.CreateInstance(it.t)))
                                        .Select(it => applyConfigurationMethodInfo.MakeGenericMethod(it.et).Invoke(modelBuilder, new[] { it.cfgObj })).ToList();
        }
    }
}
