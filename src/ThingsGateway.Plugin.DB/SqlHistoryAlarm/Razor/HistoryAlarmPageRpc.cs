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

using TouchSocket.Dmtp.Rpc;
using TouchSocket.Rpc;

namespace ThingsGateway.Plugin.DB;

[GeneratorRpcProxy(GeneratorFlag = GeneratorFlag.ExtensionAsync)]
internal interface IHistoryAlarmPageRpc : IRpcServer
{
    [DmtpRpc]
    public Task<QueryData<HistoryAlarm>> OnHistoryAlarmQueryAsync(long deviceId, QueryPageOptions options);
}
public partial class HistoryAlarmPageRpc : SingletonRpcServer, IPluginRpcServer, IHistoryAlarmPageRpc
{

    [DmtpRpc]
    public async Task<QueryData<HistoryAlarm>> OnHistoryAlarmQueryAsync(long deviceId, QueryPageOptions options)
    {
        SqlHistoryAlarm SqlHistoryAlarmProducer = GlobalData.ReadOnlyIdDevices.TryGetValue(deviceId, out DeviceRuntime deviceRuntime) ? deviceRuntime.Driver as SqlHistoryAlarm : null;
        if (SqlHistoryAlarmProducer == null) throw new Exception("Driver not found");
        var query = await SqlHistoryAlarmProducer.QueryData(options).ConfigureAwait(false);
        return query;
    }
}
