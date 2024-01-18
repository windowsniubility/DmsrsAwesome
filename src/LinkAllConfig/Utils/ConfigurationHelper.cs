using Microsoft.Extensions.Configuration;

namespace LinkAllConfig.Utils;

internal sealed class ConfigurationHelper
{
	public Conifg GetConfig()
	{
		using var cfgmgr = new ConfigurationManager();
		cfgmgr.AddIniFile("xx.json");
		cfgmgr.GetValue<Conifg>("ss");

		return new Conifg();
	}
}