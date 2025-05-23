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
        public KeyForm()
        {
            Text = "Key Code Inspector";
            Width = 400; Height = 200;
            KeyPreview = true;
            KeyDown += OnKeyDown;
            KeyPress += OnKeyPress;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine( $"KeyDown  : VKey=0x{e.KeyValue:X2} ({e.KeyCode})");
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine( $"KeyPress : Char='{e.KeyChar}' (U+{(int)e.KeyChar:X4})\n");
        }
    }
}
