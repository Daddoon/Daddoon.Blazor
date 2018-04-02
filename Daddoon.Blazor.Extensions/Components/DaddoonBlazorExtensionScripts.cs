namespace Daddoon.Blazor.Extensions
                        {
                            public class DaddoonBlazorExtensionScripts : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
                            {
                                protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
                                {
                                    builder.OpenElement(0, "script");
                                    builder.AddContent(1, @"Blazor.registerFunction(""daddoon_Alert"", (message) => { alert(message); });
");
                                        builder.CloseElement();
                                }
                            }
                        }
