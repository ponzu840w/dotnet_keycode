using System;
using System.Windows.Forms;

namespace KeyInspector
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new KeyForm());
    }
  }

  class KeyForm : Form
  {
    private const int WM_KEYDOWN    = 0x0100;
    private const int WM_SYSKEYDOWN = 0x0104;
    private const int WM_CHAR       = 0x0102;

    public KeyForm()
    {
      Text = "Key & Scan Code Inspector";
      Width = 400; Height = 200;
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
      case WM_KEYDOWN:
      case WM_SYSKEYDOWN:
        {
          int vkey = m.WParam.ToInt32() & 0xFFFF;
          int lparam = m.LParam.ToInt32();
          int scanCode = (lparam >> 16) & 0xFF;
          var keyName = (Keys)vkey;
          Console.WriteLine($"KeyDown  : VKey=0x{vkey:X2} ({keyName}), ScanCode=0x{scanCode:X2}");
          break;
        }
      case WM_CHAR:
        {
          char ch = (char)(m.WParam.ToInt32() & 0xFFFF);
          Console.WriteLine($"KeyPress : Char='{ch}' (U+{(int)ch:X4})\n");
          break;
        }
      }
      base.WndProc(ref m);
    }
  }
}
