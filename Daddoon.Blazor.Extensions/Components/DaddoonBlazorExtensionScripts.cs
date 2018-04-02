namespace Daddoon.Blazor
                        {
                            public class DaddoonBlazorExtensionScripts : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
                            {
                                protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
                                {
                                    builder.OpenElement(0, "script");
                                    builder.AddContent(1, @"//Trying to respect IE11 limitation / Avoiding () => , using function () {} instead

Blazor.registerFunction(""daddoon_Alert"", function (message) { alert(message); });
");
                                        builder.CloseElement();
                                }
                            }
                        }
