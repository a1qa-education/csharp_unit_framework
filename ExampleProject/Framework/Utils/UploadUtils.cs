using System.Runtime.InteropServices;
using System.Text;

namespace ExampleProject.Framework.Utils;

public static class UploadUtils
{
    private const uint WM_SETTEXT = 0x000C;
    private const uint BM_CLICK = 0x00F5;

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr FindWindow(
        string? lpClassName,
        string? lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr FindWindowEx(
        IntPtr hwndParent,
        IntPtr hwndChildAfter,
        string? lpszClass,
        string? lpszWindow);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(
        IntPtr hWnd,
        uint msg,
        IntPtr wParam,
        string lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(
        IntPtr hWnd,
        uint msg,
        IntPtr wParam,
        IntPtr lParam);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetClassName(
    IntPtr hWnd,
    StringBuilder lpClassName,
    int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowText(
        IntPtr hWnd,
        StringBuilder lpString,
        int nMaxCount);

    private delegate bool EnumChildProc(
        IntPtr hwnd,
        IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool EnumChildWindows(
        IntPtr hWndParent,
        EnumChildProc lpEnumFunc,
        IntPtr lParam);

    private static IntPtr WaitForDialog(int timeoutSeconds)
    {
        var end = DateTime.Now.AddSeconds(timeoutSeconds);

        while (DateTime.Now < end)
        {
            var dialog = FindWindow("#32770", "Open");

            if (dialog != IntPtr.Zero)
                return dialog;

            Thread.Sleep(1000);
        }

        throw new TimeoutException("Open dialog not found.");
    }
    private static IntPtr FindOpenButton(IntPtr dialog)
    {
        IntPtr result = IntPtr.Zero;

        EnumChildWindows(dialog, (hwnd, _) =>
        {
            var className = new StringBuilder(256);
            var text = new StringBuilder(256);

            GetClassName(hwnd, className, className.Capacity);
            GetWindowText(hwnd, text, text.Capacity);

            if (className.ToString() == "Button" &&
                (text.ToString() == "&Open" ||
                 text.ToString() == "Open"))
            {
                result = hwnd;
                return false;
            }

            return true;
        }, IntPtr.Zero);

        return result;
    }

    public static void UploadFile(string filePath, int timeoutSeconds = 10)
    {
        var absolutePath = Path.GetFullPath(filePath);

        var dialog = WaitForDialog(timeoutSeconds);

        // ComboBoxEx32 -> ComboBox -> Edit
        var comboEx = FindWindowEx(
            dialog,
            IntPtr.Zero,
            "ComboBoxEx32",
            null);

        var combo = FindWindowEx(
            comboEx,
            IntPtr.Zero,
            "ComboBox",
            null);

        var edit = FindWindowEx(
            combo,
            IntPtr.Zero,
            "Edit",
            null);

        if (edit == IntPtr.Zero)
        {
            throw new InvalidOperationException(
                "File name textbox was not found.");
        }

        SendMessage(
            edit,
            WM_SETTEXT,
            IntPtr.Zero,
            absolutePath);

        var openButton = FindOpenButton(dialog);

        if (openButton == IntPtr.Zero)
        {
            throw new InvalidOperationException(
                "Open button was not found.");
        }

        SendMessage(
            openButton,
            BM_CLICK,
            IntPtr.Zero,
            IntPtr.Zero);
    }

    public static void UploadFileFromResources(string fileName)
    {
        var resourcesPath = Path.Combine(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..")), "Resources");

        UploadFile(Path.Combine(resourcesPath, fileName));
    }

}