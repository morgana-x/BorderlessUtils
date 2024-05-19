
// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class Program
{
    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, long dwNewLong);

    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern int GetSystemMetrics(int nIndex);

    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern long GetWindowLongA(IntPtr hWnd, int nIndex);


    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern long SetWindowLongA(IntPtr hWnd, int nIndex, long dwNewLong);


    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern bool SetWindowPlacement(IntPtr hWnd, IntPtr WINDOWPLACEMENT);
    [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
    public static extern bool GetWindowPlacement(IntPtr hWnd, ref IntPtr WINDOWPLACEMENT);


    public static void Main(string[] args)
    {
        string programName = "FalloutNV";

        Process proc = Process.GetProcessesByName(programName)[0];

        nint windowHandle = proc.MainWindowHandle;

        Console.WriteLine("Handle: " + windowHandle);
        long WS_POPUP = 0x80000000L;
        //long WS_OVERLAPPED = 0x00000000L;
        long WS_VISIBLE = 0x10000000L;
        //long WS_EX_WINDOWEDGE = 0x00000100L;
        int GWL_STYLE = -16;
        int GWL_EXSTYLE = -20;
        long WS_EX_TOPMOST = 0x00000008L;
        int SM_CXSCREEN = 0;
        int SM_CYSCREEN = 1;
        int SW_SHOWMAXIMIZED = 3;
        //int SW_SHOWNORMAL = 1;
        int HWND_TOP = 0;
        uint SWP_FRAMECHANGED = 0x0020;
        int w = GetSystemMetrics(SM_CXSCREEN);
        int h = GetSystemMetrics(SM_CYSCREEN);
       // long HWNDStyleEx = GetWindowLongA(windowHandle, GWL_EXSTYLE);
        //IntPtr WindowPlacement = IntPtr.Zero;





        //GetWindowPlacement(windowHandle, ref WindowPlacement);
        SetWindowLongPtr(windowHandle, GWL_STYLE, WS_VISIBLE | WS_POPUP);
        SetWindowLongPtr(windowHandle, GWL_EXSTYLE, WS_VISIBLE | WS_EX_TOPMOST);
        SetWindowPos(windowHandle, HWND_TOP, 0, 0, w, h, SWP_FRAMECHANGED);
        ShowWindow(windowHandle, SW_SHOWMAXIMIZED);
        //SetWindowPlacement(windowHandle, WindowPlacement);
    }
}
