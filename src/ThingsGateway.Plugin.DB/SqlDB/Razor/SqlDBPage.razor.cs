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
using ThingsGateway.Plugin.DB;
using ThingsGateway.Plugin.QuestDB;

using TouchSocket.Core;
using TouchSocket.Dmtp.Rpc;
using TouchSocket.Rpc;
using TouchSocket.Rpc.DmtpRpc.Generators;

namespace ThingsGateway.Plugin.SqlDB;

public partial class SqlDBPage : IDriverUIBase
{
    private readonly SqlDBPageInput _searchHistory = new();
    private readonly SqlDBPageInput _searchReal = new();

    [Parameter, EditorRequired]
    public long DeviceId { get; set; }



    [Inject]
    private IServiceProvider ServiceProvider { get; set; }

    private DmtpInvokeOption invokeOption = new DmtpInvokeOption(60000)//调用配置
    {
        FeedbackType = FeedbackType.WaitInvoke,//调用反馈类型
        SerializationType = SerializationType.Json,//序列化类型
    };
 
            private async Task<QueryData<SQLNumberHistoryValue>> OnQueryHistoryAsync(QueryPageOptions options)
    {
        var dmtpActorContext = ServiceProvider.GetService<DmtpActorContext>();
        if (dmtpActorContext != null)
        {
            return await dmtpActorContext.Current.GetDmtpRpcActor().OnSqlDBQueryHistoryAsync(DeviceId, options, invokeOption).ConfigureAwait(false);
        }
        else
        {
            SqlDBProducer SqlDBProducer = GlobalData.ReadOnlyIdDevices.TryGetValue(DeviceId, out DeviceRuntime deviceRuntime) ? deviceRuntime.Driver as SqlDBProducer : null;
        if (SqlDBProducer == null) throw new Exception("Driver not found");
        var query = await SqlDBProducer.QueryHistoryData(options).ConfigureAwait(false);
        return query;
        }
    }

    private async Task<QueryData<SQLRealValue>> OnQueryRealAsync(QueryPageOptions options)
    {
        var dmtpActorContext = ServiceProvider.GetService<DmtpActorContext>();
        if (dmtpActorContext != null)
        {
            return await dmtpActorContext.Current.GetDmtpRpcActor().OnSqlDBQueryRealAsync(DeviceId, options, invokeOption).ConfigureAwait(false);
        }
        else
        {
            SqlDBProducer SqlDBProducer = GlobalData.ReadOnlyIdDevices.TryGetValue(DeviceId, out DeviceRuntime deviceRuntime) ? deviceRuntime.Driver as SqlDBProducer : null;
        if (SqlDBProducer == null) throw new Exception("Driver not found");
        var query = await SqlDBProducer.QueryRealData(options).ConfigureAwait(false);
        return query;
    }
    }
}
