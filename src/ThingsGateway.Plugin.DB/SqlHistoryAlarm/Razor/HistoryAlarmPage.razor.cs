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

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

using ThingsGateway.Common;
using ThingsGateway.Plugin.QuestDB;
using ThingsGateway.Plugin.SqlDB;

using TouchSocket.Core;

using TouchSocket.Dmtp.Rpc;

using TouchSocket.Rpc;
using TouchSocket.Rpc.DmtpRpc.Generators;

namespace ThingsGateway.Plugin.DB;

/// <summary>
/// HistoryAlarmPage
/// </summary>
public partial class HistoryAlarmPage : IDriverUIBase
{
    [Parameter, EditorRequired]
    public long DeviceId { get; set; }



    private HistoryAlarmPageInput CustomerSearchModel { get; set; } = new();


    [Inject]
    private IServiceProvider ServiceProvider { get; set; }

    private DmtpInvokeOption invokeOption = new DmtpInvokeOption(60000)//调用配置
    {
        FeedbackType = FeedbackType.WaitInvoke,//调用反馈类型
        SerializationType = SerializationType.Json,//序列化类型
    };


    private async Task<QueryData<HistoryAlarm>> OnQueryAsync(QueryPageOptions options)
    {

        var dmtpActorContext = ServiceProvider.GetService<DmtpActorContext>();
        if (dmtpActorContext != null)
        {
            return await dmtpActorContext.Current.GetDmtpRpcActor().OnHistoryAlarmQueryAsync(DeviceId, options, invokeOption).ConfigureAwait(false);
        }
        else
        {
            SqlHistoryAlarm SqlHistoryAlarmProducer = GlobalData.ReadOnlyIdDevices.TryGetValue(DeviceId, out DeviceRuntime deviceRuntime) ? deviceRuntime.Driver as SqlHistoryAlarm : null;
            if (SqlHistoryAlarmProducer == null) throw new Exception("Driver not found");
            var query = await SqlHistoryAlarmProducer.QueryData(options).ConfigureAwait(false);
            return query;
        }
    }
}
