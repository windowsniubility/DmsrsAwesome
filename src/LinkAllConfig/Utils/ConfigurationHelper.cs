using Microsoft.Extensions.Configuration;

namespace LinkAllConfig.Utils;

internal sealed class ConfigurationHelper
{
	public Conifg GetConfig()
	{
		IConfigurationManager cfgmgr = new ConfigurationManager();
		cfgmgr.AddIniFile("xx.json");
		cfgmgr.GetValue<Conifg>("ss");
	

		return new Conifg();
	}
}
