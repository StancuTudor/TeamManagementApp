using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TeamManagementApp.Utils
{
    internal static class Extensions
    {
        /// <summary>
        /// Bind the provided config with the section as required.
        /// </summary>
        public static OptionsBuilder<TOptions> BindConfigurationAsRequired<TOptions>(this OptionsBuilder<TOptions> optionsBuilder,
            string configSectionPath,
            Action<BinderOptions>? configureBinder = null)
            where TOptions : class
        {
            optionsBuilder.Configure<IConfiguration>((opts, config) =>
            {
                var useRootConfig = string.Equals("", configSectionPath, StringComparison.OrdinalIgnoreCase);
                IConfiguration section = useRootConfig ? config : config.GetRequiredSection(configSectionPath);

                section.Bind(opts, configureBinder);
            });

            optionsBuilder.Services.AddSingleton<IOptionsChangeTokenSource<TOptions>, ConfigurationChangeTokenSource<TOptions>>();
            return optionsBuilder;
        }
    }
}
