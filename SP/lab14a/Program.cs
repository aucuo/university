using System;
using System.Runtime.InteropServices;

class Program
{
    private const int WH_GETMESSAGE = 3;
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

    [DllImport("kernel32.dll")]
    private static extern uint GetCurrentThreadId();

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            // Логируйте или обрабатывайте сообщения здесь
            Console.WriteLine("Window message captured!");
        }
        return CallNextHookEx(hook, nCode, wParam, lParam);
    }

    static void Main()
    {
        uint currentThreadId = GetCurrentThreadId();
        hook = SetWindowsHookEx(WH_GETMESSAGE, proc, IntPtr.Zero, currentThreadId);
        Console.WriteLine("GetMessage hook is set. Press any key to unhook and exit.");
        Console.ReadKey();

        UnhookWindowsHookEx(hook);
        Console.WriteLine("GetMessage hook is removed.");
    }
}
