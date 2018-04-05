
using Microsoft.AspNetCore.Blazor.Browser.Interop;

public static class RegisteredFunctionExtension
{
    public static bool TryInvoke<TRes>(out TRes result, string identifier, params object[] args)
    {
        try
        {
            result = RegisteredFunction.Invoke<TRes>(identifier, args);
            return true;
        }
        catch (System.Exception)
        {
            result = default(TRes);
            return false;
        }
    }
}