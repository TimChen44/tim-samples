using BlazorDemo;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

IServiceCollection services = new ServiceCollection();
services.AddLogging();

IServiceProvider serviceProvider = services.BuildServiceProvider();
ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);

var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var dictionary = new Dictionary<string, object?>
    {
        { "Message", @"内容""你好""来自渲染组件" }
    };

    var parameters = ParameterView.FromDictionary(dictionary);
    var output = await htmlRenderer.RenderComponentAsync<SharedMessage>(parameters);

    return output.ToHtmlString();
});

Console.WriteLine(html);

System.IO.File.WriteAllText("message.html", html);

Console.ReadLine();