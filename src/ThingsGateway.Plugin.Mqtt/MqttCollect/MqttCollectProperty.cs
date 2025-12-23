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
using Microsoft.AspNetCore.Components.Forms;
using MQTTnet.Formatter;
using System.Security.Authentication;

namespace ThingsGateway.Plugin.Mqtt;

/// <summary>
/// <inheritdoc/>
/// </summary>
public class MqttCollectProperty : CollectPropertyBase
{
    /// <summary>
    /// IP
    /// </summary>
    [DynamicProperty]
    public string IP { get; set; } = "127.0.0.1";

    /// <summary>
    /// 是否显示详细日志
    /// </summary>
    [DynamicProperty]
    public bool DetailLog { get; set; } = false;

    /// <summary>
    /// 端口
    /// </summary>
    [DynamicProperty]
    public int Port { get; set; } = 1883;

    [DynamicProperty]
    public MqttProtocolVersion MqttProtocolVersion { get; set; } = MqttProtocolVersion.V311;



    [DynamicProperty]
    public bool TLS { get; set; } = false;

    [DynamicProperty]
    [AutoGenerateColumn(ComponentType = typeof(MultiSelect<SslProtocols>))]
#pragma warning disable CA5398 // 避免硬编码的 SslProtocols 值
    public SslProtocols SslProtocols { get; set; } = SslProtocols.Tls12 | SslProtocols.Tls13;
#pragma warning restore CA5398 // 避免硬编码的 SslProtocols 值

    [AutoGenerateColumn(Ignore = true)]
    [DynamicProperty]
    public string CAFile { get; set; }

    [FileValidation(Extensions = [".txt", ".pem"], FileSize = 1024 * 1024)]
    internal IBrowserFile CAFile_BrowserFile { get; set; }

    [DynamicProperty]
    [AutoGenerateColumn(Ignore = true)]
    public string ClientCertificateFile { get; set; }

    [FileValidation(Extensions = [".txt", ".pem"], FileSize = 1024 * 1024)]
    internal IBrowserFile ClientCertificateFile_BrowserFile { get; set; }

    [DynamicProperty]
    [AutoGenerateColumn(Ignore = true)]
    public string ClientKeyFile { get; set; }

    [FileValidation(Extensions = [".txt", ".pem"], FileSize = 1024 * 1024)]
    internal IBrowserFile ClientKeyFile_BrowserFile { get; set; }

    /// <summary>
    /// 是否websocket连接
    /// </summary>
    [DynamicProperty]
    public bool IsWebSocket { get; set; } = false;

    /// <summary>
    /// WebSocketUrl
    /// </summary>
    [DynamicProperty]
    public string? WebSocketUrl { get; set; } = "ws://127.0.0.1:8083/mqtt";

    /// <summary>
    /// 账号
    /// </summary>
    [DynamicProperty]
    public string? UserName { get; set; } = "admin";

    /// <summary>
    /// 密码
    /// </summary>
    [DynamicProperty]
    public string? Password { get; set; } = "111111";

    /// <summary>
    /// 连接Id
    /// </summary>
    [DynamicProperty]
    public string ConnectId { get; set; } = "ThingsGatewayId";

    /// <summary>
    /// 连接超时时间
    /// </summary>
    [DynamicProperty]
    public int ConnectTimeout { get; set; } = 3000;

    [DynamicProperty]
    public int CheckClearTime { get; set; } = 60000;
}
