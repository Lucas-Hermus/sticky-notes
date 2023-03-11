using System.Windows.Forms;
using System.Drawing;

namespace Holy_Guacamole
{
    class BorderlessButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.DrawRectangle(new Pen(this.BackColor, 10), this.ClientRectangle);
        }
    }
}