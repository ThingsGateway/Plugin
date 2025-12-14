//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using BootstrapBlazor.Components;

using ThingsGateway.Plugin.QuestDB;

using TouchSocket.Dmtp.Rpc;
using TouchSocket.Rpc;

namespace ThingsGateway.Plugin.DB;

[GeneratorRpcProxy(GeneratorFlag = GeneratorFlag.ExtensionAsync)]
internal interface IQuestDBPageRpc : IRpcServer
{
    [DmtpRpc]
    public Task<QueryData<QuestDBNumberHistoryValue>> OnQuestDBQueryAsync(long deviceId, QueryPageOptions options);
}
public partial class QuestDBPageRpc : SingletonRpcServer, IPluginRpcServer, IQuestDBPageRpc
{

    [DmtpRpc]
    public async Task<QueryData<QuestDBNumberHistoryValue>> OnQuestDBQueryAsync(long deviceId, QueryPageOptions options)
    {
        QuestDBProducer QuestDBProducer = GlobalData.ReadOnlyIdDevices.TryGetValue(deviceId, out DeviceRuntime deviceRuntime) ? deviceRuntime.Driver as QuestDBProducer : null;
        if (QuestDBProducer == null) throw new Exception("Driver not found");
        var query = await QuestDBProducer.QueryData(options).ConfigureAwait(false);
        return query;
    }
}
