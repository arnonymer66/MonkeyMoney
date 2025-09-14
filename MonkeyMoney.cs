using MelonLoader;
using BTD_Mod_Helper;
using MonkeyMoney;

[assembly: MelonInfo(typeof(MonkeyMoney.MonkeyMoney), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MonkeyMoney;

public class MonkeyMoney : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<MonkeyMoney>("MonkeyMoney loaded!");
    }
}