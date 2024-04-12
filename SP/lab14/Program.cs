using System;
using System.Runtime.InteropServices;

class Program
{
    private const int WH_MOUSE_LL = 14;
    private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
    private static HookProc proc = HookCallback;
    private static IntPtr hook = IntPtr.Zero;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll")]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            // Обработка сообщений мыши
            Console.WriteLine("хук присутствует");
        }
        return CallNextHookEx(hook, nCode, wParam, lParam);
    }

    static void Main()
    {
        hook = SetWindowsHookEx(WH_MOUSE_LL, proc, IntPtr.Zero, 0);
        Console.WriteLine("программа начата, бегите");
        Console.ReadKey();

        UnhookWindowsHookEx(hook);
        Console.WriteLine("выдыхайте, прога завершилась");
    }
}
